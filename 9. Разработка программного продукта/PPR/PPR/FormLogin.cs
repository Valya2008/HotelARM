using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PPR
{
    public partial class FormLogin : Form
    {
        // Вот эти свойства нужны, чтобы другие формы знали, кто вошел
        public static string CurrentUserRole { get; private set; } = "";
        public static string CurrentUsername { get; private set; } = "";

        public FormLogin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password, "Admin"))
            {
                CurrentUserRole = "Admin";
                CurrentUsername = username;
                FormMenu mainMenu = new FormMenu();
                this.Hide();
                mainMenu.Show();
            }
            else if (AuthenticateUser(username, password, "TechnicalStaff"))
            {
                CurrentUserRole = "TechnicalStaff";
                CurrentUsername = username;
                // Сразу открываем график для тех.персонала в режиме чтения
                FormStaffSchedule staffForm = new FormStaffSchedule(true);
                this.Hide();
                staffForm.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password, string role)
        {
            string query = (role == "Admin")
                ? "SELECT PasswordHash FROM Admins WHERE Username = @user"
                : "SELECT PasswordHash FROM TechnicalStaff WHERE Login = @user";

            try
            {
                SQLiteParameter[] p = { new SQLiteParameter("@user", username) };
                object result = DbHelper.ExecuteScalar(query, p);

                if (result != null)
                {
                    return PasswordHasher.VerifyPassword(password, result.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка БД: " + ex.Message);
            }
            return false;
        }
    }
}