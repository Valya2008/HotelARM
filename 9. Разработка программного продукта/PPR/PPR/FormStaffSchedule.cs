using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace PPR
{
    public partial class FormStaffSchedule : Form
    {
        private bool _readOnlyMode;
        // Словарь для хранения изменений: ключ "IDСотрудника_Дата", значение "ТипСмены"
        private Dictionary<string, string> changedCells = new Dictionary<string, string>();

        // Список смен (теперь только то, что нужно)
        private List<string> shiftTypes = new List<string> { "", "Выходной", "Утро", "День", "Вечер" };

        public FormStaffSchedule(bool readOnly = false)
        {
            InitializeComponent();
            _readOnlyMode = readOnly;

            // Настройка таблицы
            dgvSchedule.ReadOnly = _readOnlyMode;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Устанавливаем дату на начало месяца
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            // Если зашел тех. персонал
            if (_readOnlyMode)
            {
                btnSaveSchedule.Visible = false; // Скрываем кнопку "Сохранить"
                dtpStartDate.Visible = false;    // Скрываем выбор даты
                cmbPositionFilter.Visible = false; // Скрываем фильтр
            }
            else
            {
                PopulatePositionFilter();
            }
        }

        private void FormStaffSchedule_Load(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        // Заполнение фильтра должностей
        private void PopulatePositionFilter()
        {
            try
            {
                string query = "SELECT DISTINCT Position FROM TechnicalStaff";
                DataTable dt = DbHelper.GetDataTable(query);
                DataRow dr = dt.NewRow();
                dr["Position"] = "Все должности";
                dt.Rows.InsertAt(dr, 0);

                cmbPositionFilter.DataSource = dt;
                cmbPositionFilter.DisplayMember = "Position";
                cmbPositionFilter.ValueMember = "Position";
            }
            catch { }
        }

        // Загрузка графика в таблицу
        private void LoadSchedule()
        {
            dgvSchedule.CellValueChanged -= DgvSchedule_CellValueChanged;
            dgvSchedule.Columns.Clear();
            changedCells.Clear();

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            // 1. Создаем колонку с именами
            dgvSchedule.Columns.Add("FullName", "Сотрудник");
            dgvSchedule.Columns["FullName"].Frozen = true;
            dgvSchedule.Columns["FullName"].ReadOnly = true;

            // 2. Создаем колонки для дней месяца
            for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
            {
                string colName = d.ToString("dd.MM");
                if (_readOnlyMode)
                {
                    dgvSchedule.Columns.Add(colName, d.Day.ToString());
                }
                else
                {
                    // Для админа - выпадающий список (ComboBox)
                    DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                    comboCol.Name = colName;
                    comboCol.HeaderText = d.Day.ToString();
                    comboCol.DataSource = shiftTypes; // Используем наш список (Выходной, Утро и т.д.)
                    dgvSchedule.Columns.Add(comboCol);
                }
                dgvSchedule.Columns[colName].Width = 45;
            }

            // Скрытая колонка для ID
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "StaffID", Visible = false });

            // 3. Загружаем персонал
            string query = "SELECT StaffID, LastName || ' ' || FirstName AS Name FROM TechnicalStaff";
            if (_readOnlyMode)
            {
                // Тех. персонал видит только себя
                object myId = DbHelper.ExecuteScalar("SELECT StaffID FROM TechnicalStaff WHERE Login = @log",
                    new SQLiteParameter[] { new SQLiteParameter("@log", FormLogin.CurrentUsername) });
                if (myId != null) query += " WHERE StaffID = " + myId.ToString();
            }
            else if (cmbPositionFilter.Text != "Все должности" && !string.IsNullOrEmpty(cmbPositionFilter.Text))
            {
                query += $" WHERE Position = '{cmbPositionFilter.Text}'";
            }

            DataTable staffTable = DbHelper.GetDataTable(query);
            foreach (DataRow row in staffTable.Rows)
            {
                int rIdx = dgvSchedule.Rows.Add();
                dgvSchedule.Rows[rIdx].Cells["FullName"].Value = row["Name"];
                dgvSchedule.Rows[rIdx].Cells["StaffID"].Value = row["StaffID"];

                // Подгружаем сохраненные смены из БД
                for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
                {
                    string dbDate = d.ToString("yyyy-MM-dd");
                    object val = DbHelper.ExecuteScalar("SELECT ShiftType FROM StaffSchedules WHERE StaffID=@sid AND ScheduleDate=@date",
                        new SQLiteParameter[] {
                            new SQLiteParameter("@sid", row["StaffID"]),
                            new SQLiteParameter("@date", dbDate)
                        });
                    dgvSchedule.Rows[rIdx].Cells[d.ToString("dd.MM")].Value = val?.ToString() ?? "";
                }
            }

            dgvSchedule.CellValueChanged += DgvSchedule_CellValueChanged;
        }

        private void DgvSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvSchedule.Columns[e.ColumnIndex].Name != "FullName")
            {
                string staffId = dgvSchedule.Rows[e.RowIndex].Cells["StaffID"].Value.ToString();
                string colName = dgvSchedule.Columns[e.ColumnIndex].Name;
                DateTime dValue = DateTime.ParseExact(colName + "." + dtpStartDate.Value.Year, "dd.MM.yyyy", null);
                string dbDate = dValue.ToString("yyyy-MM-dd");
                string cellValue = dgvSchedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                string key = $"{staffId}_{dbDate}";
                changedCells[key] = cellValue;
            }
        }

        // Кнопка Сохранить
        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var entry in changedCells)
                {
                    string[] parts = entry.Key.Split('_');
                    DbHelper.ExecuteNonQuery("INSERT OR REPLACE INTO StaffSchedules (StaffID, ScheduleDate, ShiftType) VALUES (@sid, @date, @type)",
                        new SQLiteParameter[] {
                            new SQLiteParameter("@sid", parts[0]),
                            new SQLiteParameter("@date", parts[1]),
                            new SQLiteParameter("@type", entry.Value)
                        });
                }
                MessageBox.Show("Изменения сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                changedCells.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Ошибка сохранения: " + ex.Message); }
        }

        // Кнопка "хэшка" (по твоему скрину - средняя) - допустим, это Обновить
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        // Кнопка Отменить / Назад
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_readOnlyMode)
            {
                FormLogin login = new FormLogin();
                login.Show();
                this.Close();
            }
            else
            {
                FormMenu menu = new FormMenu();
                menu.Show();
                this.Close();
            }
        }

        private void cmbPositionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchedule();
        }
    }
}
