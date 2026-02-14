using System;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms; // Необходимо для MessageBox

namespace PPR
{
    public class DbHelper
    {
        // База данных будет создаваться в той же папке, где находится исполняемый файл (.exe)
        private static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hotel_db.db");
        private static string connectionString = $"Data Source={databasePath};Version=3;";

        // Метод для получения соединения с базой данных
        public static SQLiteConnection GetConnection()
        {
            // Если файла базы данных нет, вызываем метод для ее инициализации
            if (!File.Exists(databasePath))
            {
                InitializeDatabase();
            }
            return new SQLiteConnection(connectionString);
        }

        // Метод для создания и заполнения базы данных
        public static void InitializeDatabase()
        {
            try
            {
                // Создаем новый файл базы данных
                SQLiteConnection.CreateFile(databasePath);
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open(); // Открываем соединение
                    using (var cmd = new SQLiteCommand(connection))
                    {
                        // --- СОЗДАНИЕ ТАБЛИЦ ---

                        // 1. Таблица Admins (Администраторы)
                        cmd.CommandText = @"CREATE TABLE Admins (
                            AdminID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            PasswordHash TEXT NOT NULL,
                            UserRole TEXT DEFAULT 'Admin')";
                        cmd.ExecuteNonQuery();

                        // 2. Таблица RoomTypes (Типы номеров)
                        cmd.CommandText = @"CREATE TABLE RoomTypes (
                            RoomTypeID INTEGER PRIMARY KEY AUTOINCREMENT,
                            TypeName TEXT NOT NULL UNIQUE)";
                        cmd.ExecuteNonQuery();

                        // 3. Таблица Rooms (Номера)
                        cmd.CommandText = @"CREATE TABLE Rooms (
                            RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                            RoomNumber TEXT NOT NULL UNIQUE,
                            RoomTypeID INTEGER NOT NULL,
                            Capacity INTEGER NOT NULL,
                            PricePerNight DECIMAL(10,2) NOT NULL,
                            Floor INTEGER NOT NULL,
                            Status TEXT NOT NULL DEFAULT 'Свободен', -- 'Свободен', 'Занят', 'Уборка', 'На ремонте'
                            FOREIGN KEY(RoomTypeID) REFERENCES RoomTypes(RoomTypeID))";
                        cmd.ExecuteNonQuery();

                        // 4. Таблица Guests (Гости)
                        cmd.CommandText = @"CREATE TABLE Guests (
                            GuestID INTEGER PRIMARY KEY AUTOINCREMENT,
                            LastName TEXT NOT NULL,
                            FirstName TEXT NOT NULL,
                            Patronymic TEXT,
                            PassportSeries TEXT,
                            PassportNumber TEXT,
                            PhoneNumber TEXT NOT NULL,
                            Email TEXT,
                            Address TEXT)";
                        cmd.ExecuteNonQuery();

                        // 5. Таблица Bookings (Бронирования)
                        cmd.CommandText = @"CREATE TABLE Bookings (
                            BookingID INTEGER PRIMARY KEY AUTOINCREMENT,
                            GuestID INTEGER NOT NULL,
                            RoomID INTEGER NOT NULL,
                            CheckInDate TEXT NOT NULL,
                            CheckOutDate TEXT NOT NULL,
                            BookingDate TEXT NOT NULL,
                            Status TEXT NOT NULL DEFAULT 'Ожидает', -- 'Ожидает', 'Подтверждено', 'Отменено', 'Завершено'
                            TotalAmount DECIMAL(12,2) NOT NULL,
                            BookedRoomTypeName TEXT,
                            FOREIGN KEY(GuestID) REFERENCES Guests(GuestID),
                            FOREIGN KEY(RoomID) REFERENCES Rooms(RoomID))";
                        cmd.ExecuteNonQuery();

                        // 6. Таблица TechnicalStaff (Технический персонал) - с полями Телефон, Email, Адрес
                        cmd.CommandText = @"CREATE TABLE TechnicalStaff (
                            StaffID INTEGER PRIMARY KEY AUTOINCREMENT,
                            LastName TEXT NOT NULL,
                            FirstName TEXT NOT NULL,
                            Patronymic TEXT,
                            Position TEXT NOT NULL,
                            Login TEXT UNIQUE NOT NULL,
                            PasswordHash TEXT NOT NULL,
                            PhoneNumber TEXT,
                            Email TEXT,
                            Address TEXT,
                            Salt TEXT)";
                        cmd.ExecuteNonQuery();

                        // 7. Таблица StaffSchedules (Графики персонала)
                        cmd.CommandText = @"CREATE TABLE StaffSchedules (
                            ScheduleID INTEGER PRIMARY KEY AUTOINCREMENT,
                            StaffID INTEGER NOT NULL,
                            ScheduleDate TEXT NOT NULL,
                            ShiftType TEXT NOT NULL, -- 'Выходной', 'Утро', 'День', 'Вечер'
                            FOREIGN KEY(StaffID) REFERENCES TechnicalStaff(StaffID) ON DELETE CASCADE,
                            UNIQUE(StaffID, ScheduleDate))"; // Чтобы не было двух смен на одну дату у одного сотрудника
                        cmd.ExecuteNonQuery();

                        // --- ЗАПОЛНЕНИЕ ТЕСТОВЫМИ ДАННЫМИ ---

                        // 1. Admins
                        cmd.CommandText = $"INSERT INTO Admins (Username, PasswordHash, UserRole) VALUES " +
                                          $"('admin', '{PasswordHasher.HashPassword("admin123")}', 'Admin'), " +
                                          $"('boss', '{PasswordHasher.HashPassword("boss777")}', 'Admin')";
                        cmd.ExecuteNonQuery();

                        // 2. RoomTypes
                        cmd.CommandText = "INSERT INTO RoomTypes (TypeName) VALUES ('Стандарт'), ('Люкс'), ('Президентский')";
                        cmd.ExecuteNonQuery();

                        // 3. Rooms
                        cmd.CommandText = @"INSERT INTO Rooms (RoomNumber, RoomTypeID, Capacity, PricePerNight, Floor, Status) VALUES 
                            ('101', 1, 1, 2500, 1, 'Занят'),
                            ('102', 1, 2, 3500, 1, 'Свободен'),
                            ('103', 1, 2, 3500, 1, 'Свободен'),
                            ('201', 2, 2, 5000, 2, 'Уборка'),
                            ('202', 2, 3, 6500, 2, 'Свободен'),
                            ('301', 3, 4, 8500, 3, 'На ремонте')";
                        cmd.ExecuteNonQuery();

                        // 4. Guests
                        cmd.CommandText = @"INSERT INTO Guests (LastName, FirstName, Patronymic, PassportSeries, PassportNumber, PhoneNumber, Email, Address) VALUES 
                            ('Иванов', 'Иван', 'Иванович', '4510', '123456', '+79001112233', 'ivanov@mail.ru', 'ул. Ленина, 10, кв. 1'),
                            ('Петрова', 'Анна', 'Сергеевна', '4512', '654321', '+79990005544', 'petrova@mail.ru', 'пр. Мира, 5, кв. 10'),
                            ('Сидоров', 'Павел', 'Андреевич', '4514', '987654', '+79151234567', 'sidorov@mail.ru', 'ул. Гагарина, 1, кв. 3')";
                        cmd.ExecuteNonQuery();

                        // 5. TechnicalStaff
                        cmd.CommandText = $@"INSERT INTO TechnicalStaff (LastName, FirstName, Patronymic, Position, Login, PasswordHash, PhoneNumber, Email, Address) VALUES 
                            ('Смирнова', 'Елена', 'Викторовна', 'Уборщица', 'elena', '{PasswordHasher.HashPassword("cleaner1")}', '+79201234567', 'elena.s@hotel.ru', 'ул. Цветочная, 8'),
                            ('Кузнецов', 'Дмитрий', 'Петрович', 'Ремонтник', 'dmitry', '{PasswordHasher.HashPassword("fixer2")}', '+79057654321', 'dmitry.k@hotel.ru', 'пер. Строителей, 3'),
                            ('Иванова', 'Мария', 'Александровна', 'Уборщица', 'maria', '{PasswordHasher.HashPassword("cleaner3")}', '+79109876543', 'maria.i@hotel.ru', 'ул. Садовая, 15')";
                        cmd.ExecuteNonQuery();

                        // 6. Bookings (для аналитики и отображения)
                        string today = DateTime.Today.ToString("yyyy-MM-dd");
                        string tomorrow = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
                        string nextWeek = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd");
                        string nextMonth = DateTime.Today.AddMonths(1).ToString("yyyy-MM-dd");

                        cmd.CommandText = $@"INSERT INTO Bookings (GuestID, RoomID, CheckInDate, CheckOutDate, BookingDate, Status, TotalAmount, BookedRoomTypeName) VALUES 
                            (1, 1, '{today}', '{tomorrow}', '{today}', 'Подтверждено', 2500, 'Стандарт'),
                            (2, 2, '{nextWeek}', '{nextWeek}', '{today}', 'Ожидает', 3500, 'Стандарт'),
                            (3, 4, '{nextMonth}', '{nextMonth}', '{today}', 'Ожидает', 5000, 'Люкс')";
                        cmd.ExecuteNonQuery();

                        // 7. StaffSchedules (немного графика для примера)
                        // Получим ID сотрудников для графика
                        object elenaId = DbHelper.ExecuteScalar("SELECT StaffID FROM TechnicalStaff WHERE Login = 'elena'");
                        object dmitryId = DbHelper.ExecuteScalar("SELECT StaffID FROM TechnicalStaff WHERE Login = 'dmitry'");

                        if (elenaId != null)
                        {
                            cmd.CommandText = $"INSERT OR REPLACE INTO StaffSchedules (StaffID, ScheduleDate, ShiftType) VALUES " +
                                $"({elenaId}, '{today}', 'Утро'), " +
                                $"({elenaId}, '{DateTime.Today.AddDays(1).ToString("yyyy-MM-dd")}', 'Выходной')";
                            cmd.ExecuteNonQuery();
                        }
                        if (dmitryId != null)
                        {
                            cmd.CommandText = $"INSERT OR REPLACE INTO StaffSchedules (StaffID, ScheduleDate, ShiftType) VALUES " +
                                $"({dmitryId}, '{today}', 'День')";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("База данных успешно создана и заполнена!", "Инициализация БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая ошибка при создании или заполнении базы данных: " + ex.Message, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ВЫПОЛНЕНИЯ ЗАПРОСОВ ---

        public static SQLiteDataReader ExecuteReader(string query, SQLiteParameter[] parameters = null)
        {
            var connection = GetConnection(); // Получаем соединение
            connection.Open(); // Открываем его
            var command = new SQLiteCommand(query, connection); // Создаем команду
            if (parameters != null) command.Parameters.AddRange(parameters); // Добавляем параметры
            // ExecuteReader с CommandBehavior.CloseConnection закроет соединение, когда reader будет закрыт
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static int ExecuteNonQuery(string query, SQLiteParameter[] parameters = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query, SQLiteParameter[] parameters = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    return command.ExecuteScalar();
                }
            }
        }

        public static DataTable GetDataTable(string query, SQLiteParameter[] parameters = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    var adapter = new SQLiteDataAdapter(command);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
