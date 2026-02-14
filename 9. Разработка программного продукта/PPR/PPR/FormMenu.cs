using PPR;
using System;
using System.Windows.Forms;

namespace PPR
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            // Если зашел тех. персонал, скрываем кнопки админа
            if (FormLogin.CurrentUserRole == "TechnicalStaff")
            {
                // Можно добавить отдельные кнопки или полностью скрыть FormMenu и сразу перенаправить на FormStaffSchedule
                // В текущей логике FormLogin сразу перенаправляет тех. персонал.
                // Поэтому эта проверка здесь, возможно, не понадобится, если FormMenu не открывается для них.
                // Но если вы хотите, чтобы у тех. персонала было свое урезанное меню, то здесь можно скрывать кнопки.
                btnGuests.Visible = false;
                btnRooms.Visible = false;
                btnBookings.Visible = false;
                btnAnalytics.Visible = false;
                btnStaff.Visible = false; // Скрываем кнопку управления персоналом для самого персонала
                // И возможно, показать кнопку "Мой график"
            }
            else if (FormLogin.CurrentUserRole == "Admin")
            {
                // Убедимся, что для админа все кнопки видимы (если изначально они были скрыты дизайнером)
                btnGuests.Visible = true;
                btnRooms.Visible = true;
                btnBookings.Visible = true;
                btnAnalytics.Visible = true;
                btnStaff.Visible = true;
            }
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            FormGuests formGuests = new FormGuests();
            this.Hide();
            formGuests.Show();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            FormRooms formRooms = new FormRooms();
            this.Hide();
            formRooms.Show();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            FormBookings formBookings = new FormBookings();
            this.Hide();
            formBookings.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из приложения?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Этот метод можно удалить, если он пуст и не используется
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            FormAnalytics formAnalytics = new FormAnalytics();
            this.Hide();
            formAnalytics.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e) // !!! НОВАЯ КНОПКА !!!
        {
            FormStaff formStaff = new FormStaff();
            this.Hide();
            formStaff.Show();
        }

        private void btnStaffSchedule_Click(object sender, EventArgs e) // !!! НОВАЯ КНОПКА !!!
        {
            FormStaffSchedule formStaffSchedule = new FormStaffSchedule(readOnly: false); // Админ может редактировать
            this.Hide();
            formStaffSchedule.Show();
        }
    }
}