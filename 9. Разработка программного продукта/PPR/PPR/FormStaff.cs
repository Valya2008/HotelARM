using PPR;
using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PPR
{
    public partial class FormStaff : Form
    {
        private int selectedStaffId = -1;

        public FormStaff()
        {
            InitializeComponent();

            // Настройка таблицы dgvStaff
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.MultiSelect = false;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Заполнять ширину автоматически

            LoadStaff(); // Первичная загрузка данных
            ClearStaffDetails(); // Очистка правой панели

            // Привязка событий (если они не привязаны в дизайнере)
            dgvStaff.CellClick += dgvStaff_CellClick;
            txtSearchStaff.TextChanged += txtSearchStaff_TextChanged;
        }

        // Загрузка списка сотрудников в таблицу dgvStaff
        private void LoadStaff(string searchTerm = "")
        {
            // Выбираем только StaffID (скрытый), ФИО и Должность для отображения в таблице слева
            string query = "SELECT StaffID, LastName || ' ' || FirstName || ' ' || Patronymic AS FullName, Position FROM TechnicalStaff";

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Поиск по ФИО, Должности и Логину
                query += " WHERE (LastName || ' ' || FirstName || ' ' || Patronymic) LIKE @searchTerm " +
                         "OR Position LIKE @searchTerm OR Login LIKE @searchTerm";
            }

            try
            {
                SQLiteParameter[] parameters = null;
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    parameters = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@searchTerm", $"%{searchTerm}%")
                    };
                }

                DataTable staffTable = DbHelper.GetDataTable(query, parameters);
                dgvStaff.DataSource = staffTable;

                // Настройка заголовков и видимости колонок
                if (dgvStaff.Columns.Contains("StaffID"))
                    dgvStaff.Columns["StaffID"].Visible = false; // Скрываем ID

                if (dgvStaff.Columns.Contains("FullName"))
                    dgvStaff.Columns["FullName"].HeaderText = "ФИО Сотрудника"; // Заголовок для ФИО

                if (dgvStaff.Columns.Contains("Position"))
                    dgvStaff.Columns["Position"].HeaderText = "Должность"; // Заголовок для Должности

                // Скрываем все остальные колонки, если они вдруг появятся
                foreach (DataGridViewColumn col in dgvStaff.Columns.Cast<DataGridViewColumn>().ToList())
                {
                    if (col.Name != "FullName" && col.Name != "Position" && col.Name != "StaffID")
                    {
                        col.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных персонала: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод очистки всех текстовых полей справа
        private void ClearStaffDetails()
        {
            // Убедись, что имена Textbox в дизайнере формы FormStaff совпадают с этими
            txtStaffFio.Text = "";
            txtPosition.Text = "";
            txtLogin.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

            selectedStaffId = -1;
            btnEditStaff.Enabled = false;
            btnDeleteStaff.Enabled = false;
        }

        // Метод отображения полной информации при клике на сотрудника
        private void DisplayStaffDetails(int staffId)
        {
            // Этот запрос выбирает ВСЕ данные, так как они нужны для правой панели
            string query = "SELECT FirstName, LastName, Patronymic, Position, Login, PhoneNumber, Email, Address FROM TechnicalStaff WHERE StaffID = @staffId";
            try
            {
                SQLiteParameter[] parameters = new SQLiteParameter[] { new SQLiteParameter("@staffId", staffId) };

                using (SQLiteDataReader reader = DbHelper.ExecuteReader(query, parameters))
                {
                    if (reader.Read())
                    {
                        // Убедись, что имена Textbox в дизайнере формы FormStaff совпадают с этими
                        txtStaffFio.Text = $"{reader["LastName"]} {reader["FirstName"]} {reader["Patronymic"]}";
                        txtPosition.Text = reader["Position"].ToString();
                        txtLogin.Text = reader["Login"].ToString();
                        txtPhone.Text = reader["PhoneNumber"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtAddress.Text = reader["Address"].ToString();

                        selectedStaffId = staffId;
                        btnEditStaff.Enabled = true;
                        btnDeleteStaff.Enabled = true;
                    }
                    else
                    {
                        ClearStaffDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке деталей: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearStaffDetails();
            }
        }

        // Обработчик клика по ячейке таблицы
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvStaff.Rows.Count) // Проверяем, что индекс строки корректен
            {
                // ИСПРАВЛЕНО: Проверяем наличие колонки "StaffID" в DataGridView в целом
                if (dgvStaff.Columns.Contains("StaffID"))
                {
                    // И теперь безопасно получаем значение
                    object staffIdValue = dgvStaff.Rows[e.RowIndex].Cells["StaffID"].Value;
                    if (staffIdValue != null && int.TryParse(staffIdValue.ToString(), out int staffId))
                    {
                        DisplayStaffDetails(staffId);
                    }
                }
            }
        }

        // Обработчик изменения текста в поле поиска
        private void txtSearchStaff_TextChanged(object sender, EventArgs e)
        {
            LoadStaff(txtSearchStaff.Text);
        }

        // Кнопка "Добавить сотрудника"
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            FormStaffDetails staffDetailsForm = new FormStaffDetails();
            if (staffDetailsForm.ShowDialog() == DialogResult.OK)
            {
                LoadStaff();
                ClearStaffDetails();
            }
        }

        // Кнопка "Редактировать сотрудника"
        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            if (selectedStaffId != -1)
            {
                FormStaffDetails staffDetailsForm = new FormStaffDetails(selectedStaffId);
                if (staffDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadStaff();
                    DisplayStaffDetails(selectedStaffId);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Кнопка "Удалить сотрудника"
        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            if (selectedStaffId != -1)
            {
                // Проверка графика (чтобы не удалить того, кто работает)
                string checkScheduleQuery = "SELECT COUNT(*) FROM StaffSchedules WHERE StaffID = @staffId AND ScheduleDate >= @currentDate";
                SQLiteParameter[] checkParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@staffId", selectedStaffId),
                    new SQLiteParameter("@currentDate", DateTime.Today.ToString("yyyy-MM-dd"))
                };

                int activeScheduleCount = Convert.ToInt32(DbHelper.ExecuteScalar(checkScheduleQuery, checkParams));

                if (activeScheduleCount > 0)
                {
                    MessageBox.Show("Невозможно удалить сотрудника, так как у него есть смены в графике.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Удалить выбранного сотрудника?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM TechnicalStaff WHERE StaffID = @staffId";
                    DbHelper.ExecuteNonQuery(deleteQuery, new SQLiteParameter[] { new SQLiteParameter("@staffId", selectedStaffId) });

                    MessageBox.Show("Сотрудник успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaff();
                    ClearStaffDetails();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Кнопка "Назад"
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMenu mainMenu = new FormMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
