using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PPR
{
    public partial class FormRoomDetails : Form
    {
        private int _roomId;
        private bool _isEditMode;

        public FormRoomDetails(int roomId = 0)
        {
            InitializeComponent();
            _roomId = roomId;
            _isEditMode = (_roomId > 0);
        }

        private void FormRoomDetails_Load(object sender, EventArgs e)
        {
            PopulateRoomTypesComboBox();
            PopulateStatusComboBox();

            if (_isEditMode)
            {
                this.Text = "Редактировать номер";
                LoadRoomData();
            }
            else
            {
                this.Text = "Добавить новый номер";
                // Исправлено: у нас статусы на русском, ставим "Свободен"
                cmbStatus.SelectedItem = "Свободен";
            }
        }

        private void PopulateRoomTypesComboBox()
        {
            string query = "SELECT RoomTypeID, TypeName FROM RoomTypes ORDER BY TypeName";
            DataTable roomTypes = DbHelper.GetDataTable(query);

            cmbRoomType.DataSource = roomTypes;
            cmbRoomType.DisplayMember = "TypeName";
            cmbRoomType.ValueMember = "RoomTypeID";
        }

        private void PopulateStatusComboBox()
        {
            cmbStatus.Items.Add("Свободен");
            cmbStatus.Items.Add("Занят");
            cmbStatus.Items.Add("На ремонте");
            cmbStatus.Items.Add("На уборке");
        }


        private void LoadRoomData()
        {
            string query = @"
                SELECT 
                    RoomNumber, 
                    RoomTypeID, 
                    Capacity, 
                    PricePerNight, 
                    Floor, 
                    Status
                FROM Rooms 
                WHERE RoomID = @roomId";

            SQLiteParameter[] parameters = { new SQLiteParameter("@roomId", _roomId) };

            using (SQLiteDataReader reader = DbHelper.ExecuteReader(query, parameters))
            {
                if (reader.Read())
                {
                    txtRoomNumber.Text = reader["RoomNumber"].ToString();
                    cmbRoomType.SelectedValue = Convert.ToInt32(reader["RoomTypeID"]);
                    txtCapacity.Text = reader["Capacity"].ToString();
                    txtPricePerNight.Text = reader["PricePerNight"].ToString();
                    txtFloor.Text = reader["Floor"].ToString();
                    cmbStatus.SelectedItem = reader["Status"].ToString();
                }
                else
                {
                    MessageBox.Show("Номер не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text) ||
                cmbRoomType.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtCapacity.Text) ||
                string.IsNullOrWhiteSpace(txtPricePerNight.Text) ||
                string.IsNullOrWhiteSpace(txtFloor.Text) ||
                cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCapacity.Text, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Вместимость должна быть положительным числом.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtPricePerNight.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Цена за ночь должна быть положительным числом.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtFloor.Text, out int floor) || floor <= 0)
            {
                MessageBox.Show("Этаж должен быть положительным числом.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string roomNumber = txtRoomNumber.Text.Trim();
            int roomTypeID = Convert.ToInt32(cmbRoomType.SelectedValue);
            string status = cmbStatus.SelectedItem.ToString();

            string query;
            SQLiteParameter[] parameters;

            if (_isEditMode)
            {
                query = @"
                    UPDATE Rooms 
                    SET 
                        RoomNumber = @roomNumber, 
                        RoomTypeID = @roomTypeID, 
                        Capacity = @capacity, 
                        PricePerNight = @pricePerNight, 
                        Floor = @floor, 
                        Status = @status
                    WHERE RoomID = @roomId";
                parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@roomNumber", roomNumber),
                    new SQLiteParameter("@roomTypeID", roomTypeID),
                    new SQLiteParameter("@capacity", capacity),
                    new SQLiteParameter("@pricePerNight", price),
                    new SQLiteParameter("@floor", floor),
                    new SQLiteParameter("@status", status),
                    new SQLiteParameter("@roomId", _roomId)
                };
            }
            else
            {
                query = @"
                    INSERT INTO Rooms 
                        (RoomNumber, RoomTypeID, Capacity, PricePerNight, Floor, Status) 
                    VALUES 
                        (@roomNumber, @roomTypeID, @capacity, @pricePerNight, @floor, @status)";
                parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@roomNumber", roomNumber),
                    new SQLiteParameter("@roomTypeID", roomTypeID),
                    new SQLiteParameter("@capacity", capacity),
                    new SQLiteParameter("@pricePerNight", price),
                    new SQLiteParameter("@floor", floor),
                    new SQLiteParameter("@status", status)
                };
            }

            try
            {
                DbHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Номер успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SQLiteException ex)
            {
                if (ex.ErrorCode == 19)
                {
                    MessageBox.Show($"Номер комнаты '{roomNumber}' уже существует. Пожалуйста, введите другой номер.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при сохранении номера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelRoom_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
