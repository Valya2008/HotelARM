using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PPR
{
    public partial class FormGuestDetails : Form
    {
        private int guestIdToEdit = -1;

        public FormGuestDetails()
        {
            InitializeComponent();
            this.Text = "Добавить нового гостя";
        }

        public FormGuestDetails(int guestId) : this()
        {
            this.Text = "Редактировать гостя";
            guestIdToEdit = guestId;
            LoadGuestDataForEdit();
        }

        private void LoadGuestDataForEdit()
        {
            string query = "SELECT * FROM Guests WHERE GuestID = @guestId";
            try
            {
                SQLiteParameter[] parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@guestId", guestIdToEdit)
                };

                using (SQLiteDataReader reader = DbHelper.ExecuteReader(query, parameters))
                {
                    if (reader.Read())
                    {
                        txtLastName.Text = reader["LastName"].ToString();
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtPatronymic.Text = reader["Patronymic"].ToString();
                        txtPassportSeries.Text = reader["PassportSeries"].ToString();
                        txtPassportNumber.Text = reader["PassportNumber"].ToString();
                        txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных гостя: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Пожалуйста, заполните обязательные поля: Фамилия, Имя, Телефон.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;
            SQLiteParameter[] parameters;

            if (guestIdToEdit == -1)
            {
                query = "INSERT INTO Guests (LastName, FirstName, Patronymic, PassportSeries, PassportNumber, PhoneNumber, Email, Address) " +
                        "VALUES (@lastName, @firstName, @patronymic, @passportSeries, @passportNumber, @phoneNumber, @email, @address)";
                parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@lastName", txtLastName.Text),
                    new SQLiteParameter("@firstName", txtFirstName.Text),
                    new SQLiteParameter("@patronymic", txtPatronymic.Text),
                    new SQLiteParameter("@passportSeries", txtPassportSeries.Text),
                    new SQLiteParameter("@passportNumber", txtPassportNumber.Text),
                    new SQLiteParameter("@phoneNumber", txtPhoneNumber.Text),
                    new SQLiteParameter("@email", txtEmail.Text),
                    new SQLiteParameter("@address", txtAddress.Text)
                };
            }
            else
            {
                query = "UPDATE Guests SET LastName = @lastName, FirstName = @firstName, Patronymic = @patronymic, " +
                        "PassportSeries = @passportSeries, PassportNumber = @passportNumber, " +
                        "PhoneNumber = @phoneNumber, Email = @email, Address = @address " +
                        "WHERE GuestID = @guestId";
                parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@lastName", txtLastName.Text),
                    new SQLiteParameter("@firstName", txtFirstName.Text),
                    new SQLiteParameter("@patronymic", txtPatronymic.Text),
                    new SQLiteParameter("@passportSeries", txtPassportSeries.Text),
                    new SQLiteParameter("@passportNumber", txtPassportNumber.Text),
                    new SQLiteParameter("@phoneNumber", txtPhoneNumber.Text),
                    new SQLiteParameter("@email", txtEmail.Text),
                    new SQLiteParameter("@address", txtAddress.Text),
                    new SQLiteParameter("@guestId", guestIdToEdit)
                };
            }

            try
            {
                DbHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Данные гостя успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных гостя: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
