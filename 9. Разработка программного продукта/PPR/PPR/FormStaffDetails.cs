using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PPR
{
    public partial class FormStaffDetails : Form
    {
        private int staffIdToEdit = -1;

        public FormStaffDetails() // Конструктор для добавления нового сотрудника
        {
            InitializeComponent();
            PopulatePositionsComboBox();
            this.Text = "Добавить сотрудника"; // Устанавливаем заголовок окна
        }

        public FormStaffDetails(int staffId) : this() // Конструктор для редактирования существующего
        {
            this.Text = "Редактировать сотрудника"; // Меняем заголовок окна
            staffIdToEdit = staffId;
            LoadStaffDataForEdit();
        }

        // Заполнение выпадающего списка должностей
        private void PopulatePositionsComboBox()
        {
            // Убедись, что на форме есть ComboBox с именем cmbPosition
            cmbPosition.Items.Clear();
            cmbPosition.Items.Add("Уборщица");
            cmbPosition.Items.Add("Ремонтник");
            cmbPosition.SelectedIndex = 0; // Выбираем первый элемент по умолчанию
        }

        // Загрузка данных сотрудника для редактирования
        private void LoadStaffDataForEdit()
        {
            string query = "SELECT * FROM TechnicalStaff WHERE StaffID = @id";
            SQLiteParameter[] ps = { new SQLiteParameter("@id", staffIdToEdit) };

            try
            {
                using (SQLiteDataReader reader = DbHelper.ExecuteReader(query, ps))
                {
                    if (reader.Read())
                    {
                        // Заполняем текстовые поля (убедись, что имена Textbox совпадают с дизайнером!)
                        txtLastName.Text = reader["LastName"].ToString();
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtPatronymic.Text = reader["Patronymic"].ToString();
                        txtLogin.Text = reader["Login"].ToString();
                        cmbPosition.SelectedItem = reader["Position"].ToString();
                        txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                        txtEmail.Text = reader["Email"].ToString(); // Здесь должно быть txtEmail
                        txtAddress.Text = reader["Address"].ToString();

                        // Информация про пароль
                        lblPasswordInfo.Text = "Оставьте пустым, чтобы не менять пароль";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных сотрудника: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки "Сохранить"
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка обязательных полей (можно добавить больше)
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Пожалуйста, заполните Фамилию, Имя и Логин.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;
            SQLiteParameter[] ps;

            if (staffIdToEdit == -1) // Если это добавление нового сотрудника
            {
                query = @"INSERT INTO TechnicalStaff (LastName, FirstName, Patronymic, Login, PasswordHash, Position, PhoneNumber, Email, Address) 
                          VALUES (@ln, @fn, @pn, @log, @pass, @pos, @phone, @email, @addr)";

                // Для нового сотрудника пароль обязателен
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Пожалуйста, введите пароль для нового сотрудника.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ps = new SQLiteParameter[] {
                    new SQLiteParameter("@ln", txtLastName.Text),
                    new SQLiteParameter("@fn", txtFirstName.Text),
                    new SQLiteParameter("@pn", txtPatronymic.Text),
                    new SQLiteParameter("@log", txtLogin.Text),
                    new SQLiteParameter("@pass", PasswordHasher.HashPassword(txtPassword.Text)), // Хэшируем пароль
                    new SQLiteParameter("@pos", cmbPosition.Text),
                    new SQLiteParameter("@phone", txtPhoneNumber.Text),
                    new SQLiteParameter("@email", txtEmail.Text),
                    new SQLiteParameter("@addr", txtAddress.Text)
                };
            }
            else // Если это редактирование существующего сотрудника
            {
                query = @"UPDATE TechnicalStaff SET LastName=@ln, FirstName=@fn, Patronymic=@pn, Login=@log, 
                          Position=@pos, PhoneNumber=@phone, Email=@email, Address=@addr";

                // Обновляем пароль, только если он был введен
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    query += ", PasswordHash='" + PasswordHasher.HashPassword(txtPassword.Text) + "'";
                }

                query += " WHERE StaffID = " + staffIdToEdit;

                ps = new SQLiteParameter[] {
                    new SQLiteParameter("@ln", txtLastName.Text),
                    new SQLiteParameter("@fn", txtFirstName.Text),
                    new SQLiteParameter("@pn", txtPatronymic.Text),
                    new SQLiteParameter("@log", txtLogin.Text),
                    new SQLiteParameter("@pos", cmbPosition.Text),
                    new SQLiteParameter("@phone", txtPhoneNumber.Text),
                    new SQLiteParameter("@email", txtEmail.Text),
                    new SQLiteParameter("@addr", txtAddress.Text)
                };
            }

            try
            {
                if (DbHelper.ExecuteNonQuery(query, ps) > 0)
                {
                    MessageBox.Show("Данные сотрудника успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Сигнал родительской форме, что сохранение прошло успешно
                    this.Close(); // Закрываем окно редактирования/добавления
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить данные. Попробуйте позже.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Просто закрываем окно без сохранения
        }
    }
}
