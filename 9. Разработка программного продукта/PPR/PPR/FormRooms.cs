using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PPR
{
    public partial class FormRooms : Form
    {
        // --- ИЗМЕНЕНИЕ 1: Удаляем перегруженный конструктор, оставляем один ---
        // public FormRooms()
        // {
        //     InitializeComponent();
        //     LoadRooms();
        // }
        // --- КОНЕЦ ИЗМЕНЕНИЯ 1 ---

        // --- ИЗМЕНЕНИЕ 2: Новый конструктор, который будет вызван, и где мы инициализируем фильтр ---
        public FormRooms() // Этот конструктор останется, но его тело будет изменено
        {
            InitializeComponent();
            // Вызываем PopulateRoomTypeFilter() здесь, в конструкторе, который реально используется
            PopulateRoomTypeFilter();
            LoadRooms();
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.MultiSelect = false;
        }
        // --- КОНЕЦ ИЗМЕНЕНИЯ 2 ---


        private void PopulateRoomTypeFilter()
        {
            string query = "SELECT TypeName FROM RoomTypes";
            DataTable roomTypes = DbHelper.GetDataTable(query);

            // Создаем строку "Все типы" для ComboBox
            DataRow allRow = roomTypes.NewRow();
            allRow["TypeName"] = "Все типы";
            roomTypes.Rows.InsertAt(allRow, 0); // Вставляем строку "Все типы" в начало

            // Устанавливаем источник данных для ComboBox
            cmbRoomTypeFilter.DataSource = roomTypes;
            cmbRoomTypeFilter.DisplayMember = "TypeName";
            cmbRoomTypeFilter.ValueMember = "TypeName";
            cmbRoomTypeFilter.SelectedIndex = 0; // Выбираем "Все типы" по умолчанию

            // Подписываемся на событие изменения выбранного элемента
            cmbRoomTypeFilter.SelectedIndexChanged += cmbRoomTypeFilter_SelectedIndexChanged;
        }

        private void cmbRoomTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При изменении фильтра, перезагружаем список номеров
            LoadRooms(txtSearchRoom.Text);
        }

        // --- ИЗМЕНЕНИЕ 3: MODIFIED LoadRooms METHOD TO INCLUDE FILTER ---
        private void LoadRooms(string searchTerm = "")
        {
            // Получаем выбранный тип номера из фильтра
            string selectedType = cmbRoomTypeFilter.SelectedValue?.ToString();

            // Базовый SQL-запрос для получения номеров и их типов
            string query = @"
            SELECT 
                r.RoomID, 
                r.RoomNumber,
                rt.TypeName AS RoomType, 
                r.Capacity, 
                r.PricePerNight, 
                r.Floor, 
                r.Status
            FROM Rooms r
            JOIN RoomTypes rt ON r.RoomTypeID = rt.RoomTypeID";

            // Добавляем условие WHERE для поиска и фильтрации
            query += " WHERE r.RoomNumber LIKE @searchTerm OR rt.TypeName LIKE @searchTerm";

            // Если выбран конкретный тип номера (не "Все типы"), добавляем фильтр по типу
            if (selectedType != "Все типы" && !string.IsNullOrEmpty(selectedType))
            {
                query += " AND rt.TypeName = @selectedType";
            }

            // Добавляем сортировку
            query += " ORDER BY r.Floor, r.RoomNumber";

            // Формируем параметры для SQL-запроса
            SQLiteParameter[] parameters;
            if (selectedType != "Все типы" && !string.IsNullOrEmpty(selectedType))
            {
                parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@searchTerm", $"%{searchTerm}%"),
                    new SQLiteParameter("@selectedType", selectedType)
                };
            }
            else
            {
                // Если фильтр "Все типы", то параметр @selectedType не нужен в запросе
                parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@searchTerm", $"%{searchTerm}%")
                };
                // Удаляем из строки запроса условие с @selectedType, если оно не нужно
                // (Но текущая логика с IF и так делает условие WHERE правильным)
            }

            // --- Оптимизация: Убираем лишний параметр, если он не нужен ---
            // Более надежный способ: формировать строку запроса динамически
            string finalQuery = @"
            SELECT 
                r.RoomID, r.RoomNumber, rt.TypeName AS RoomType, r.Capacity, r.PricePerNight, r.Floor, r.Status
            FROM Rooms r
            JOIN RoomTypes rt ON r.RoomTypeID = rt.RoomTypeID";

            System.Collections.Generic.List<SQLiteParameter> queryParameters = new System.Collections.Generic.List<SQLiteParameter>();

            // Добавляем условие поиска
            finalQuery += " WHERE (r.RoomNumber LIKE @searchTerm OR rt.TypeName LIKE @searchTerm)";
            queryParameters.Add(new SQLiteParameter("@searchTerm", $"%{searchTerm}%"));

            // Добавляем условие фильтрации по типу
            if (selectedType != "Все типы" && !string.IsNullOrEmpty(selectedType))
            {
                finalQuery += " AND rt.TypeName = @selectedType";
                queryParameters.Add(new SQLiteParameter("@selectedType", selectedType));
            }

            finalQuery += " ORDER BY r.Floor, r.RoomNumber";

            DataTable roomsTable = DbHelper.GetDataTable(finalQuery, queryParameters.ToArray());
            // --- КОНЕЦ ОПТИМИЗАЦИИ ---

            dgvRooms.DataSource = roomsTable;

            // Скрываем ненужные колонки
            if (dgvRooms.Columns.Contains("RoomID")) dgvRooms.Columns["RoomID"].Visible = false;
            // Важно: Теперь у нас есть колонка "RoomType" из запроса, а не "RoomType" из соединения с RoomTypes
            if (dgvRooms.Columns.Contains("RoomType")) dgvRooms.Columns["RoomType"].Visible = false;
            if (dgvRooms.Columns.Contains("Capacity")) dgvRooms.Columns["Capacity"].Visible = false;
            if (dgvRooms.Columns.Contains("PricePerNight")) dgvRooms.Columns["PricePerNight"].Visible = false;
            if (dgvRooms.Columns.Contains("Floor")) dgvRooms.Columns["Floor"].Visible = false;
            if (dgvRooms.Columns.Contains("Status")) dgvRooms.Columns["Status"].Visible = false;

            // Настраиваем отображение видимых колонок
            dgvRooms.Columns["RoomNumber"].HeaderText = "Номер комнаты";
            dgvRooms.Columns["RoomNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ClearDetailsPanel(); // Очищаем панель деталей после загрузки
        }

        // --- ИЗМЕНЕНИЕ 4: Убедись, что у тебя есть дизайнер для FormRooms.cs ---
        // --- и в нем есть следующие элементы: ---
        // --- txtSearchRoom (TextBox) ---
        // --- cmbRoomTypeFilter (ComboBox) ---
        // --- dgvRooms (DataGridView) ---
        // --- txtRoomNumber, txtRoomType, txtCapacity, txtPricePerNight, txtFloor, txtStatus (TextBox) ---
        // --- btnEditRoom, btnDeleteRoom, btnBackRooms, btnAddRoom (Button) ---
        // --- И Убедись, что `InitializeComponent();` вызывается в конструкторе. ---

        // --- ОСТАЛЬНОЙ КОД FormRooms.cs БЕЗ ИЗМЕНЕНИЙ ---
        private void FormRooms_Load(object sender, EventArgs e)
        {
            // Этот метод, скорее всего, уже вызывается через InitializeComponent()
            // и содержит настройки DataGridView. Если он пуст, его можно удалить, 
            // или оставить для совместимости.
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvRooms.SelectedRows[0];
                txtRoomNumber.Text = selectedRow.Cells["RoomNumber"].Value?.ToString();
                // Теперь используем "RoomType" из запроса, а не "TypeName" (который скрыт)
                txtRoomType.Text = selectedRow.Cells["RoomType"].Value?.ToString();
                txtCapacity.Text = selectedRow.Cells["Capacity"].Value?.ToString();
                txtPricePerNight.Text = selectedRow.Cells["PricePerNight"].Value?.ToString();
                txtFloor.Text = selectedRow.Cells["Floor"].Value?.ToString();
                txtStatus.Text = selectedRow.Cells["Status"].Value?.ToString();
            }
            else
            {
                ClearDetailsPanel();
            }
        }

        private void ClearDetailsPanel()
        {
            txtRoomNumber.Text = "";
            txtRoomType.Text = "";
            txtCapacity.Text = "";
            txtPricePerNight.Text = "";
            txtFloor.Text = "";
            txtStatus.Text = "";
        }

        private void txtSearchRoom_TextChanged(object sender, EventArgs e)
        {
            LoadRooms(txtSearchRoom.Text);
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count > 0)
            {
                int roomId = Convert.ToInt32(dgvRooms.SelectedRows[0].Cells["RoomID"].Value);
                FormRoomDetails formDetails = new FormRoomDetails(roomId);
                if (formDetails.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите номер для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count > 0)
            {
                int roomId = Convert.ToInt32(dgvRooms.SelectedRows[0].Cells["RoomID"].Value);
                string roomNumber = dgvRooms.SelectedRows[0].Cells["RoomNumber"].Value.ToString();

                // !!! ВАЖНО: Нужно проверить, не занят ли номер активными бронированиями,
                // прежде чем удалять. Ты проверяешь BookingStatus, но в таблице Bookings
                // он называется просто Status. Исправь запрос.
                string checkBookingsQuery = "SELECT COUNT(*) FROM Bookings WHERE RoomID = @roomId AND Status IN ('Подтверждено', 'Ожидает')";
                SQLiteParameter[] checkParams = { new SQLiteParameter("@roomId", roomId) };
                long activeBookingsCount = (long)DbHelper.ExecuteScalar(checkBookingsQuery, checkParams);

                if (activeBookingsCount > 0)
                {
                    MessageBox.Show($"Номер {roomNumber} имеет активные бронирования и не может быть удален.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Вы уверены, что хотите удалить номер {roomNumber}?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Rooms WHERE RoomID = @roomId";
                    SQLiteParameter[] deleteParams = { new SQLiteParameter("@roomId", roomId) };

                    try
                    {
                        DbHelper.ExecuteNonQuery(deleteQuery, deleteParams);
                        MessageBox.Show("Номер успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRooms(); // Перезагружаем список после удаления
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении номера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите номер для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBackRooms_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menuForm = new FormMenu();
            menuForm.ShowDialog();
            this.Close();
        }

        private void btnAddRoom_Click_1(object sender, EventArgs e)
        {
            FormRoomDetails formDetails = new FormRoomDetails();
            if (formDetails.ShowDialog() == DialogResult.OK)
            {
                LoadRooms(); // Перезагружаем список после добавления
            }
        }
    }
}
