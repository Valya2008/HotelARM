using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using PPR;

namespace PPR
{
    public partial class FormBookings : Form
    {
        public FormBookings()
        {
            InitializeComponent();
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.MultiSelect = false;
            LoadBookings();
        }

        private void LoadBookings(string searchTerm = "")
        {
            string query = @"
            SELECT
                b.BookingID,
                'Бронирование №' || b.BookingID AS DisplayBookingID,
                g.LastName || ' ' || g.FirstName || ' ' || g.Patronymic AS GuestName,
                r.RoomNumber AS RoomNumber,
                r.RoomID, -- !!! ДОБАВЛЕНО: RoomID для обновления статуса номера при удалении
                b.CheckInDate,
                b.CheckOutDate,
                b.Status,
                b.TotalAmount,
                b.BookedRoomTypeName
            FROM Bookings b
            JOIN Guests g ON b.GuestID = g.GuestID
            JOIN Rooms r ON b.RoomID = r.RoomID
            WHERE (g.LastName || ' ' || g.FirstName) LIKE @searchTerm
               OR r.RoomNumber LIKE @searchTerm
            ORDER BY b.BookingID DESC";

            SQLiteParameter[] parameters = { new SQLiteParameter("@searchTerm", $"%{searchTerm}%") };

            try
            {
                DataTable bookingsTable = DbHelper.GetDataTable(query, parameters);
                dgvBookings.AutoGenerateColumns = true;

                dgvBookings.DataSource = bookingsTable;

                foreach (DataGridViewColumn col in dgvBookings.Columns)
                {
                    col.Visible = false;
                }
                if (dgvBookings.Columns.Contains("DisplayBookingID"))
                {
                    dgvBookings.Columns["DisplayBookingID"].Visible = true;
                    dgvBookings.Columns["DisplayBookingID"].HeaderText = "Список броней";
                    dgvBookings.Columns["DisplayBookingID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                // !!! ДОБАВЛЕНО: Показываем RoomID, но делаем его невидимым
                if (dgvBookings.Columns.Contains("RoomID"))
                    dgvBookings.Columns["RoomID"].Visible = false;

                ClearDetailsPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void dgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvBookings.SelectedRows[0];
                txtGuestName.Text = row.Cells["GuestName"].Value?.ToString();
                txtRoomDetails.Text = row.Cells["RoomNumber"].Value?.ToString();
                txtCheckInDate.Text = row.Cells["CheckInDate"].Value?.ToString();
                txtCheckOutDate.Text = row.Cells["CheckOutDate"].Value?.ToString();
                txtBookingStatus.Text = row.Cells["Status"].Value?.ToString();
                txtTotalAmount.Text = row.Cells["TotalAmount"].Value?.ToString();
                txtRoomTypeDisplay.Text = row.Cells["BookedRoomTypeName"].Value?.ToString();
            }
            else
            {
                ClearDetailsPanel();
            }
        }

        private void ClearDetailsPanel()
        {
            txtGuestName.Text = "";
            txtRoomDetails.Text = "";
            txtCheckInDate.Text = "";
            txtCheckOutDate.Text = "";
            txtBookingStatus.Text = "";
            txtTotalAmount.Text = "";
            txtRoomTypeDisplay.Text = "";
        }

        private void txtSearchBooking_TextChanged(object sender, EventArgs e)
        {
            LoadBookings(txtSearchBooking.Text);
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            FormBookingDetails formDetails = new FormBookingDetails();
            if (formDetails.ShowDialog() == DialogResult.OK)
            {
                LoadBookings();
            }
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                int bookingId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["BookingID"].Value);
                FormBookingDetails formDetails = new FormBookingDetails(bookingId);
                if (formDetails.ShowDialog() == DialogResult.OK)
                {
                    LoadBookings();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите бронирование для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                int bookingId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["BookingID"].Value);
                // !!! Получаем RoomID из выбранной строки DGV
                int roomId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["RoomID"].Value);
                string guestName = dgvBookings.SelectedRows[0].Cells["GuestName"].Value.ToString();
                string roomNumber = dgvBookings.SelectedRows[0].Cells["RoomNumber"].Value.ToString();

                if (MessageBox.Show($"Вы уверены, что хотите удалить бронирование для {guestName} в номере {roomNumber}?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Bookings WHERE BookingID = @bookingId";
                    SQLiteParameter[] deleteParams = { new SQLiteParameter("@bookingId", bookingId) };

                    try
                    {
                        DbHelper.ExecuteNonQuery(deleteQuery, deleteParams);
                        MessageBox.Show("Бронирование успешно удалено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // --- НОВЫЙ КОД ДЛЯ ОБНОВЛЕНИЯ СТАТУСА НОМЕРА В ТАБЛИЦЕ ROOMS ---
                        string checkOtherBookingsQuery = @"
                        SELECT COUNT(*)
                        FROM Bookings
                        WHERE RoomID = @roomId
                          AND Status IN ('Подтверждено', 'Ожидает')";

                        SQLiteParameter[] checkOtherBookingsParams = { new SQLiteParameter("@roomId", roomId) };
                        object otherBookingsCountResult = DbHelper.ExecuteScalar(checkOtherBookingsQuery, checkOtherBookingsParams);
                        int otherBookingsCount = Convert.ToInt32(otherBookingsCountResult);

                        if (otherBookingsCount == 0) // Если других активных броней нет для этого номера
                        {
                            // Устанавливаем статус "Свободен", если только номер не "На ремонте"
                            string updateRoomStatusQuery = "UPDATE Rooms SET Status = 'Свободен' WHERE RoomID = @roomId AND Status != 'На ремонте'";
                            SQLiteParameter[] roomParams = { new SQLiteParameter("@roomId", roomId) };
                            DbHelper.ExecuteNonQuery(updateRoomStatusQuery, roomParams);
                        }
                        // --- КОНЕЦ НОВОГО КОДА ---

                        LoadBookings(); // Перезагружаем список после удаления и обновления статуса
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении бронирования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите бронирование для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBackBookings_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menuForm = new FormMenu();
            menuForm.ShowDialog();
            this.Close();
        }
    }
}
