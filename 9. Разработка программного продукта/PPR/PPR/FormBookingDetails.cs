using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PPR
{
    public partial class FormBookingDetails : Form
    {
        private int _bookingId;
        private bool _isEditMode;
        private decimal _roomPricePerNight = 0;

        public FormBookingDetails(int bookingId = 0)
        {
            InitializeComponent();
            _bookingId = bookingId;
            _isEditMode = (_bookingId > 0);

            dtpCheckInDate.Value = DateTime.Today;
            dtpCheckOutDate.Value = DateTime.Today.AddDays(1);

            // Подписываем события, чтобы пересчитывать стоимость при изменении дат или выбора номера
            dtpCheckInDate.ValueChanged += DtpDates_ValueChanged;
            dtpCheckOutDate.ValueChanged += DtpDates_ValueChanged;
            cmbRoom.SelectedIndexChanged += CmbRoom_SelectedIndexChanged;
        }

        private void DtpDates_ValueChanged(object sender, EventArgs e)
        {
            // При изменении дат перезагружаем доступные номера и пересчитываем сумму
            LoadAvailableRooms();
            CalculateTotalAmount();
        }

        private void CmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обновляем цену за ночь в зависимости от выбранного номера
            if (cmbRoom.SelectedItem is DataRowView drv && drv.Row.Table.Columns.Contains("PricePerNight"))
            {
                if (decimal.TryParse(drv.Row["PricePerNight"].ToString(), out decimal price))
                {
                    _roomPricePerNight = price;
                }
                else
                {
                    _roomPricePerNight = 0;
                }
            }
            else
            {
                // Если cmbRoom не содержит PricePerNight (например, другой источник), пробуем получить из БД
                if (cmbRoom.SelectedValue != null)
                {
                    string roomPriceQuery = "SELECT PricePerNight FROM Rooms WHERE RoomID = @roomId";
                    object obj = DbHelper.ExecuteScalar(roomPriceQuery, new SQLiteParameter[] { new SQLiteParameter("@roomId", Convert.ToInt32(cmbRoom.SelectedValue)) });
                    if (obj != null && decimal.TryParse(obj.ToString(), out decimal price2))
                    {
                        _roomPricePerNight = price2;
                    }
                    else _roomPricePerNight = 0;
                }
            }

            CalculateTotalAmount();
        }

        // Обновлённый метод CalculateTotalAmount
        private void CalculateTotalAmount()
        {
            // Валидация дат
            if (dtpCheckOutDate.Value.Date <= dtpCheckInDate.Value.Date)
            {
                txtTotalAmount.Text = "0.00";
                return;
            }

            // Получение цены за ночь (из _roomPricePerNight, который обновляется в событии выбора номера)
            decimal pricePerNight = _roomPricePerNight;
            if (pricePerNight <= 0)
            {
                txtTotalAmount.Text = "0.00";
                return;
            }

            TimeSpan duration = dtpCheckOutDate.Value.Date - dtpCheckInDate.Value.Date;
            int days = duration.Days;
            if (days <= 0) days = 1;

            decimal total = pricePerNight * days;
            txtTotalAmount.Text = total.ToString("F2");
        }

        private void FormBookingDetails_Load(object sender, EventArgs e)
        {
            PopulateGuestsComboBox();
            PopulateBookingStatusComboBox();

            if (_isEditMode)
            {
                this.Text = "Редактировать бронирование";
                LoadBookingData();
            }
            else
            {
                this.Text = "Добавить новое бронирование";
                cmbBookingStatus.SelectedItem = "Подтверждено";
            }

            LoadAvailableRooms();
            CalculateTotalAmount();
        }

        private void LoadAvailableRooms()
        {
            cmbRoom.DataSource = null;

            DateTime checkIn = dtpCheckInDate.Value.Date;
            DateTime checkOut = dtpCheckOutDate.Value.Date;

            string query = @"
                SELECT
                    r.RoomID,
                    r.RoomNumber || ' (' || rt.TypeName || ') - ' || r.PricePerNight || ' руб/ночь' AS RoomDisplay,
                    r.PricePerNight,
                    rt.TypeName AS RoomTypeName
                FROM Rooms r
                JOIN RoomTypes rt ON r.RoomTypeID = rt.RoomTypeID
                WHERE (r.Status = 'Свободен' OR r.RoomID = @currentRoomIdForEdit)
                  AND r.RoomID NOT IN (
                      SELECT b.RoomID
                      FROM Bookings b
                      WHERE (b.CheckInDate < @checkOut AND b.CheckOutDate > @checkIn)
                        AND b.Status IN ('Подтверждено', 'Ожидает')
                        AND b.BookingID != @currentBookingId
                  )
                ORDER BY r.RoomNumber";

            int currentRoomIdForEdit = 0;
            if (_isEditMode && _bookingId > 0)
            {
                string currentRoomIdQuery = "SELECT RoomID FROM Bookings WHERE BookingID = @bookingId";
                object result = DbHelper.ExecuteScalar(currentRoomIdQuery, new SQLiteParameter[] { new SQLiteParameter("@bookingId", _bookingId) });
                if (result != null && int.TryParse(result.ToString(), out int v)) currentRoomIdForEdit = v;
            }

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@checkIn", checkIn.ToString("yyyy-MM-dd")),
                new SQLiteParameter("@checkOut", checkOut.ToString("yyyy-MM-dd")),
                new SQLiteParameter("@currentBookingId", _bookingId),
                new SQLiteParameter("@currentRoomIdForEdit", currentRoomIdForEdit)
            };

            DataTable availableRooms = DbHelper.GetDataTable(query, parameters);

            cmbRoom.DataSource = availableRooms;
            cmbRoom.DisplayMember = "RoomDisplay";
            cmbRoom.ValueMember = "RoomID";

            // Если есть доступные номера, выбираем первый и выставляем цену
            if (availableRooms.Rows.Count > 0)
            {
                cmbRoom.SelectedIndex = 0;
                if (cmbRoom.SelectedItem is DataRowView drv && drv.Row.Table.Columns.Contains("PricePerNight"))
                {
                    decimal.TryParse(drv.Row["PricePerNight"].ToString(), out _roomPricePerNight);
                }
            }
            else
            {
                cmbRoom.Text = "Нет доступных номеров на эти даты";
                _roomPricePerNight = 0;
            }

            CalculateTotalAmount();
        }

        private void LoadBookingData()
        {
            string query = @"SELECT
                GuestID,
                RoomID,
                CheckInDate,
                CheckOutDate,
                Status,
                TotalAmount,
                BookedRoomTypeName
            FROM Bookings
            WHERE BookingID = @bookingId";

            SQLiteParameter[] parameters = { new SQLiteParameter("@bookingId", _bookingId) };

            using (SQLiteDataReader reader = DbHelper.ExecuteReader(query, parameters))
            {
                if (reader.Read())
                {
                    cmbGuest.SelectedValue = Convert.ToInt32(reader["GuestID"]);

                    dtpCheckInDate.Value = DateTime.Parse(reader["CheckInDate"].ToString());
                    dtpCheckOutDate.Value = DateTime.Parse(reader["CheckOutDate"].ToString());

                    // Сначала загружаем доступные номера (LoadAvailableRooms будет учтёт текущую бронь)
                    LoadAvailableRooms();

                    int bookedRoomId = Convert.ToInt32(reader["RoomID"]);
                    // Пытаемся выбрать забронированный номер в ComboBox
                    try
                    {
                        cmbRoom.SelectedValue = bookedRoomId;
                    }
                    catch
                    {
                        // Если не получилось — предупреждаем, но продолжаем
                        MessageBox.Show("Предупреждение: выбранный ранее номер сейчас недоступен в списке.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    cmbBookingStatus.SelectedItem = reader["Status"].ToString();
                    txtTotalAmount.Text = reader["TotalAmount"].ToString();

                    // Получаем цену на момент редактирования (вдруг номер изменился)
                    string roomPriceQuery = "SELECT PricePerNight FROM Rooms WHERE RoomID = @roomId";
                    object priceObj = DbHelper.ExecuteScalar(roomPriceQuery, new SQLiteParameter[] { new SQLiteParameter("@roomId", bookedRoomId) });
                    if (priceObj != null && decimal.TryParse(priceObj.ToString(), out decimal p))
                    {
                        _roomPricePerNight = p;
                    }
                    else
                    {
                        _roomPricePerNight = 0;
                    }

                    // После установки _roomPricePerNight пересчитываем итог
                    CalculateTotalAmount();
                }
                else
                {
                    MessageBox.Show("Бронирование не найдено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }
        private void PopulateGuestsComboBox()
        {
            string query = "SELECT GuestID, LastName || ' ' || FirstName || ' ' || Patronymic AS FullName FROM Guests ORDER BY LastName, FirstName";
            DataTable guests = DbHelper.GetDataTable(query);

            cmbGuest.DataSource = guests;
            cmbGuest.DisplayMember = "FullName";
            cmbGuest.ValueMember = "GuestID";
        }

        private void PopulateBookingStatusComboBox()
        {
            cmbBookingStatus.Items.Clear();
            cmbBookingStatus.Items.Add("Подтверждено");
            cmbBookingStatus.Items.Add("Ожидает");
            cmbBookingStatus.Items.Add("Завершено");
            cmbBookingStatus.Items.Add("Отменено");
        }
        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            {
                // --- 1. ПРОВЕРКА ВАЛИДАЦИИ ОБЯЗАТЕЛЬНЫХ ПОЛЕЙ ---
                if (cmbGuest.SelectedValue == null ||
                    cmbRoom.SelectedValue == null ||
                    cmbBookingStatus.SelectedItem == null || dtpCheckInDate.Value >= dtpCheckOutDate.Value)
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля и убедитесь, что дата выезда позже даты заезда.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // --- 2. ПОЛУЧЕНИЕ ДАННЫХ ИЗ ФОРМЫ ---
                int guestId = Convert.ToInt32(cmbGuest.SelectedValue);
                int roomId = Convert.ToInt32(cmbRoom.SelectedValue);
                string checkInDate = dtpCheckInDate.Value.ToString("yyyy-MM-dd");
                string checkOutDate = dtpCheckOutDate.Value.ToString("yyyy-MM-dd");
                string bookingStatus = cmbBookingStatus.SelectedItem.ToString();
                decimal totalAmount = decimal.Parse(txtTotalAmount.Text);
                string bookingDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string bookedRoomTypeName = "";
                if (cmbRoom.SelectedValue != null)
                {
                    if (cmbRoom.SelectedItem is DataRowView selectedRoomRow)
                    {
                        bookedRoomTypeName = selectedRoomRow.Row["RoomTypeName"]?.ToString() ?? "";
                    }
                    else
                    {
                        string roomTypeQuery = "SELECT rt.TypeName FROM Rooms r JOIN RoomTypes rt ON r.RoomTypeID = rt.RoomTypeID WHERE r.RoomID = @roomId";
                        bookedRoomTypeName = DbHelper.ExecuteScalar(roomTypeQuery, new SQLiteParameter[] { new SQLiteParameter("@roomId", roomId) })?.ToString() ?? "";
                    }
                }

                // --- 3. ПРОВЕРКА НА ПЕРЕСЕЧЕНИЕ БРОНИРОВАНИЙ (НОВЫЙ КОД) ---
                string conflictQuery = @"
                SELECT COUNT(*)
                FROM Bookings
                WHERE RoomID = @roomId
                  AND Status IN ('Подтверждено', 'Ожидает')
                  AND BookingID != @currentBookingId -- Исключаем текущую бронь при редактировании
                  AND (
                        (CheckInDate < @checkOutDate AND CheckOutDate > @checkInDate) -- Стандартная логика пересечения
                      )";

                SQLiteParameter[] conflictParams = new SQLiteParameter[]
                {
                new SQLiteParameter("@roomId", roomId),
                new SQLiteParameter("@checkInDate", checkInDate),
                new SQLiteParameter("@checkOutDate", checkOutDate),
                new SQLiteParameter("@currentBookingId", _bookingId) // Передаем _bookingId, если редактируем, иначе 0
                };

                object conflictCountResult = DbHelper.ExecuteScalar(conflictQuery, conflictParams);
                int conflictCount = Convert.ToInt32(conflictCountResult);

                if (conflictCount > 0)
                {
                    MessageBox.Show("Выбранный номер уже занят или забронирован на указанные даты! Пожалуйста, выберите другой номер или измените даты.", "Ошибка бронирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Прерываем сохранение
                }
                // --- КОНЕЦ НОВОГО КОДА ПРОВЕРКИ ---


                // --- 4. ПОДГОТОВКА SQL-ЗАПРОСА (INSERT ИЛИ UPDATE) ---
                string query;
                SQLiteParameter[] parameters;

                if (_isEditMode)
                {
                    query = @"
                    UPDATE Bookings
                    SET
                        GuestID = @guestId,
                        RoomID = @roomId,
                        CheckInDate = @checkInDate,
                        CheckOutDate = @checkOutDate,
                        Status = @status,
                        TotalAmount = @totalAmount,
                        BookedRoomTypeName = @bookedRoomTypeName
                    WHERE BookingID = @bookingId";
                    parameters = new SQLiteParameter[]
                    {
                    new SQLiteParameter("@guestId", guestId),
                    new SQLiteParameter("@roomId", roomId),
                    new SQLiteParameter("@checkInDate", checkInDate),
                    new SQLiteParameter("@checkOutDate", checkOutDate),
                    new SQLiteParameter("@status", bookingStatus),
                    new SQLiteParameter("@totalAmount", totalAmount),
                    new SQLiteParameter("@bookedRoomTypeName", bookedRoomTypeName),
                    new SQLiteParameter("@bookingId", _bookingId)
                    };
                }
                else
                {
                    query = @"
                    INSERT INTO Bookings
                        (GuestID, RoomID, CheckInDate, CheckOutDate, BookingDate, Status, TotalAmount, BookedRoomTypeName)
                    VALUES
                        (@guestId, @roomId, @checkInDate, @checkOutDate, @bookingDate, @status, @totalAmount, @bookedRoomTypeName)";
                    parameters = new SQLiteParameter[]
                    {
                    new SQLiteParameter("@guestId", guestId),
                    new SQLiteParameter("@roomId", roomId),
                    new SQLiteParameter("@checkInDate", checkInDate),
                    new SQLiteParameter("@checkOutDate", checkOutDate),
                    new SQLiteParameter("@bookingDate", bookingDate),
                    new SQLiteParameter("@status", bookingStatus),
                    new SQLiteParameter("@totalAmount", totalAmount),
                    new SQLiteParameter("@bookedRoomTypeName", bookedRoomTypeName)
                    };
                }

                // --- 5. ВЫПОЛНЕНИЕ ЗАПРОСА И ОБРАБОТКА РЕЗУЛЬТАТА ---
                try
                {
                    DbHelper.ExecuteNonQuery(query, parameters);

                    // --- НОВЫЙ КОД ДЛЯ ОБНОВЛЕНИЯ СТАТУСА НОМЕРА В ТАБЛИЦЕ ROOMS (НОВЫЙ КОД) ---
                    if (bookingStatus == "Завершено")
                    {
                        string updateRoomStatusQuery = "UPDATE Rooms SET Status = 'На уборке' WHERE RoomID = @roomId";
                        SQLiteParameter[] roomParams = { new SQLiteParameter("@roomId", roomId) };
                        DbHelper.ExecuteNonQuery(updateRoomStatusQuery, roomParams);
                    }
                    else if (bookingStatus == "Отменено")
                    {
                        // Если бронь отменена, номер должен стать свободным, если на него нет других активных броней
                        string checkOtherBookingsQuery = @"
                        SELECT COUNT(*)
                        FROM Bookings
                        WHERE RoomID = @roomId
                          AND Status IN ('Подтверждено', 'Ожидает')
                          AND BookingID != @currentBookingId"; // Исключаем только что отмененную бронь

                        SQLiteParameter[] checkOtherBookingsParams = { new SQLiteParameter("@roomId", roomId), new SQLiteParameter("@currentBookingId", _bookingId) };
                        object otherBookingsCountResult = DbHelper.ExecuteScalar(checkOtherBookingsQuery, checkOtherBookingsParams);
                        int otherBookingsCount = Convert.ToInt32(otherBookingsCountResult);

                        if (otherBookingsCount == 0) // Если других активных броней нет
                        {
                            string updateRoomStatusQuery = "UPDATE Rooms SET Status = 'Свободен' WHERE RoomID = @roomId";
                            SQLiteParameter[] roomParams = { new SQLiteParameter("@roomId", roomId) };
                            DbHelper.ExecuteNonQuery(updateRoomStatusQuery, roomParams);
                        }
                        // Если есть другие активные брони, статус номера останется "Занят"
                    }
                    else // Если статус "Подтверждено" или "Ожидает"
                    {
                        // Номер становится "Занят", если он не "На ремонте"
                        string updateRoomStatusQuery = "UPDATE Rooms SET Status = 'Занят' WHERE RoomID = @roomId AND Status != 'На ремонте'";
                        SQLiteParameter[] roomParams = { new SQLiteParameter("@roomId", roomId) };
                        DbHelper.ExecuteNonQuery(updateRoomStatusQuery, roomParams);
                    }
                    // --- КОНЕЦ НОВОГО КОДА ОБНОВЛЕНИЯ СТАТУСА ---

                    MessageBox.Show("Бронирование успешно сохранено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении бронирования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }// (Ваша существующая логика сохранения брони — оставляем без изменений, важно, чтобы перед сохранением CalculateTotalAmount уже дал корректную сумму)
}