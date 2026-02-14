using PPR;
using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace PPR
{
    public partial class FormGuests : Form
    {
        private int selectedGuestId = -1;

        public FormGuests()
        {
            InitializeComponent();

            // Настройки DataGridView по умолчанию
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.MultiSelect = false;
            dgvGuests.RowHeadersVisible = false;       // убираем левый "пустой" столбец со стрелкой
            dgvGuests.AllowUserToAddRows = false;      // отключаем пустую строку для добавления
            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadGuests();
            ClearGuestDetails();

            dgvGuests.CellClick += dgvGuests_CellClick;
            txtSearchGuest.TextChanged += txtSearchGuest_TextChanged;
        }

        private void LoadGuests(string searchTerm = "")
        {
            // Выбираем необходимые поля; PhoneNumber оставляем для поиска, но потом скрываем в таблице
            string query = "SELECT GuestID, LastName || ' ' || FirstName || ' ' || Patronymic AS FullName, PhoneNumber FROM Guests";

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Используем явное выражение, т.к. алиас FullName нельзя применять в WHERE на том же уровне
                query += " WHERE (LastName || ' ' || FirstName || ' ' || Patronymic) LIKE @searchTerm OR PhoneNumber LIKE @searchTerm";
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

                DataTable guestsTable = DbHelper.GetDataTable(query, parameters);
                dgvGuests.DataSource = guestsTable;

                // Скрываем ID
                if (dgvGuests.Columns.Contains("GuestID"))
                    dgvGuests.Columns["GuestID"].Visible = false;

                // Скрываем column с телефоном (видимый слева столбец)
                if (dgvGuests.Columns.Contains("PhoneNumber"))
                    dgvGuests.Columns["PhoneNumber"].Visible = false;

                // Переименовываем заголовок колонки с ФИО
                if (dgvGuests.Columns.Contains("FullName"))
                    dgvGuests.Columns["FullName"].HeaderText = "ФИО Гостя";

                // Дополнительно: скрываем любые колонки без имени/заголовка
                foreach (DataGridViewColumn col in dgvGuests.Columns.Cast<DataGridViewColumn>().ToList())
                {
                    if (string.IsNullOrWhiteSpace(col.Name) && string.IsNullOrWhiteSpace(col.HeaderText))
                    {
                        col.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных гостей: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearGuestDetails()
        {
            txtGuestFio.Text = "";
            txtPassportSeries.Text = "";
            txtPassportNumber.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            selectedGuestId = -1;
            btnEditGuest.Enabled = false;
            btnDeleteGuest.Enabled = false;
        }

        private void DisplayGuestDetails(int guestId)
        {
            string query = "SELECT FirstName, LastName, Patronymic, PassportSeries, PassportNumber, PhoneNumber, Email, Address FROM Guests WHERE GuestID = @guestId";
            try
            {
                SQLiteParameter[] parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@guestId", guestId)
                };

                using (SQLiteDataReader reader = DbHelper.ExecuteReader(query, parameters))
                {
                    if (reader.Read())
                    {
                        txtGuestFio.Text = $"{reader["LastName"]} {reader["FirstName"]} {reader["Patronymic"]}";
                        txtPassportSeries.Text = reader["PassportSeries"].ToString();
                        txtPassportNumber.Text = reader["PassportNumber"].ToString();
                        txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                        selectedGuestId = guestId;
                        btnEditGuest.Enabled = true;
                        btnDeleteGuest.Enabled = true;
                    }
                    else
                    {
                        ClearGuestDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке деталей гостя: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearGuestDetails();
            }
        }

        private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvGuests.Rows.Count > e.RowIndex)
            {
                int guestId = Convert.ToInt32(dgvGuests.Rows[e.RowIndex].Cells["GuestID"].Value);
                DisplayGuestDetails(guestId);
            }
        }

        private void txtSearchGuest_TextChanged(object sender, EventArgs e)
        {
            LoadGuests(txtSearchGuest.Text);
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            FormGuestDetails guestDetailsForm = new FormGuestDetails();
            if (guestDetailsForm.ShowDialog() == DialogResult.OK)
            {
                LoadGuests();
                ClearGuestDetails();
            }
        }

        private void btnEditGuest_Click(object sender, EventArgs e)
        {
            if (selectedGuestId != -1)
            {
                FormGuestDetails guestDetailsForm = new FormGuestDetails(selectedGuestId);
                if (guestDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadGuests();
                    DisplayGuestDetails(selectedGuestId);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите гостя для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            if (selectedGuestId != -1)
            {
                string checkBookingQuery = "SELECT COUNT(*) FROM Bookings WHERE GuestID = @guestId AND Status IN ('Подтверждено', 'Ожидает')";
                SQLiteParameter[] checkParams = new SQLiteParameter[] { new SQLiteParameter("@guestId", selectedGuestId) };
                object result = DbHelper.ExecuteScalar(checkBookingQuery, checkParams);
                int activeBookingsCount = Convert.ToInt32(result);

                if (activeBookingsCount > 0)
                {
                    MessageBox.Show("Невозможно удалить гостя, так как у него есть активные или ожидающие бронирования.", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Вы уверены, что хотите удалить выбранного гостя?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Guests WHERE GuestID = @guestId";
                    try
                    {
                        SQLiteParameter[] parameters = new SQLiteParameter[]
                        {
                            new SQLiteParameter("@guestId", selectedGuestId)
                        };
                        DbHelper.ExecuteNonQuery(deleteQuery, parameters);
                        MessageBox.Show("Гость успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGuests();
                        ClearGuestDetails();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении гостя: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите гостя для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMenu mainMenu = new FormMenu();
            this.Close();
            mainMenu.Show();
        }
    }
}
