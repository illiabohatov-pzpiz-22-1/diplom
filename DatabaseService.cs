
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DIPLOM_
{
    public sealed class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {
            _connectionString = "Server=bohatovdiplom-bohatovdiplom.f.aivencloud.com;Port=17633;Database=defaultdb;Uid=avnadmin;Pwd=AVNS__1MV09CsyQqK41q_28Z;SslMode=Required;";

            EnsureDatabase();
            SeedData();
        }

        public void EnsureDatabase()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS CareTypes (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Animal TEXT NOT NULL,
                    Description TEXT
                );

                CREATE TABLE IF NOT EXISTS Employees (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Login VARCHAR(255) NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    IsAdmin INT NOT NULL DEFAULT 0
                );

                CREATE TABLE IF NOT EXISTS Tasks (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    TaskDate DATETIME NOT NULL,
                    TaskTime TEXT NOT NULL,
                    CareType TEXT NOT NULL,
                    Description TEXT,
                    Animal TEXT,
                    Place TEXT,
                    Worker TEXT,
                    Status INT NOT NULL DEFAULT 0
                );
                
                CREATE TABLE IF NOT EXISTS AnimalCount (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Animal TEXT NOT NULL,
                    Place TEXT NOT NULL,
                    AnimalCount INT NOT NULL,
                    Description TEXT
                );
            ";
            command.ExecuteNonQuery();

            //    // Проверяем наличие дефолтного администратора
            //    using var checkCommand = connection.CreateCommand();
            //    checkCommand.CommandText = "SELECT COUNT(*) FROM Employees;";
            //    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

            //    if (count == 0)
            //    {
            //        using var insertCommand = connection.CreateCommand();
            //        insertCommand.CommandText = @"
            //            INSERT INTO Employees (Name, Login, Password, IsAdmin)
            //            VALUES ('Администратор', 'a', 'a', 1);";
            //        insertCommand.ExecuteNonQuery();
            //    }
        }

        public void SeedData()
        {
            //using var connection = new MySqlConnection(_connectionString);
            //connection.Open();

            //// Отключаем проверку внешних ключей на время очистки, чтобы MySQL не ругался
            //using var disableConstraints = connection.CreateCommand();
            //disableConstraints.CommandText = "SET FOREIGN_KEY_CHECKS = 0;";
            //disableConstraints.ExecuteNonQuery();

            //// Очищаем таблицы и сбрасываем автоинкремент (Id снова начнется с 1)
            //string[] tablesToClear = { "CareTypes", "Employees", "AnimalCount", "Tasks" };
            //foreach (var table in tablesToClear)
            //{
            //    using var truncateCmd = connection.CreateCommand();
            //    truncateCmd.CommandText = $"TRUNCATE TABLE {table};";
            //    truncateCmd.ExecuteNonQuery();
            //}

            //// Включаем проверку внешних ключей обратно
            //using var enableConstraints = connection.CreateCommand();
            //enableConstraints.CommandText = "SET FOREIGN_KEY_CHECKS = 1;";
            //enableConstraints.ExecuteNonQuery();

            // Проверяем, если данные уже есть, то ничего не делаем
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var checkCmd = connection.CreateCommand();
            checkCmd.CommandText = "SELECT COUNT(*) FROM CareTypes;";
            if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0) return;

            // 1. CareTypes (Виды ухода для разных типов животных)
            var careTypes = new List<Dictionary<string, object>>
    {
        new() { { "Name", "Morning Feeding" }, { "Animal", "Lion" }, { "Description", "Serve 5kg of fresh beef. Ensure water supply is clean." } },
        new() { { "Name", "Evening Feeding" }, { "Animal", "Lion" }, { "Description", "Serve 4kg of meat mixed with essential vitamin supplements." } },
        new() { { "Name", "Dental Examination" }, { "Animal", "Capybara" }, { "Description", "Check incisors for overgrowth and provide fresh bamboo sticks." } },
        new() { { "Name", "Enclosure Cleaning" }, { "Animal", "Penguin" }, { "Description", "Wash down the stones, remove ice crusts, and sanitize the pool filter." } },
        new() { { "Name", "Water Treatment" }, { "Animal", "Dolphin" }, { "Description", "Measure chlorine and salt levels. Add water purifying agents if needed." } },
        new() { { "Name", "Weight Check" }, { "Animal", "Elephant" }, { "Description", "Guide the animal onto the platform scale and record weight in logbook." } },
        new() { { "Name", "Vaccination" }, { "Animal", "Wolf" }, { "Description", "Annual rabies vaccination. Use sedation dart protocol if required." } }
    };
            foreach (var row in careTypes) InsertRow("CareTypes", row);

            // 2. Employees (Сотрудники с логинами для тестов)
            var employees = new List<Dictionary<string, object>>
    {
        new() { { "Name", "John Doe" }, { "Login", "john_keeper" }, { "Password", "password123" }, { "IsAdmin", 0 } },
        new() { { "Name", "Alice Smith" }, { "Login", "alice_vet" }, { "Password", "vetpass456" }, { "IsAdmin", 0 } },
        new() { { "Name", "Robert Johnson" }, { "Login", "robert_j" }, { "Password", "secure789" }, { "IsAdmin", 0 } },
        new() { { "Name", "Emma Watson" }, { "Login", "emma_w" }, { "Password", "keeper99" }, { "IsAdmin", 0 } },
        new() { { "Name", "A" }, { "Login", "a" }, { "Password", "a" }, { "IsAdmin", 1 } }
    };
            foreach (var row in employees) InsertRow("Employees", row);

            // 3. AnimalCount (Сектора и учет количества животных)
            var animals = new List<Dictionary<string, object>>
    {
        new() { { "Animal", "Lion" }, { "Place", "Sector A - Pride Lands" }, { "AnimalCount", 4 }, { "Description", "One dominant male, two adult females, one young cub." } },
        new() { { "Animal", "Capybara" }, { "Place", "Sector C - Wetlands" }, { "AnimalCount", 8 }, { "Description", "A peaceful family group. All adults are microchipped." } },
        new() { { "Animal", "Penguin" }, { "Place", "Sector B - Arctic Coast" }, { "AnimalCount", 15 }, { "Description", "Humboldt penguins active group. Two pairs are currently nesting." } },
        new() { { "Animal", "Dolphin" }, { "Place", "Aquatic Center - Main Pool" }, { "AnimalCount", 3 }, { "Description", "Bottlenose dolphins used for educational presentations." } },
        new() { { "Animal", "Elephant" }, { "Place", "Sector D - Savanna Elephant Park" }, { "AnimalCount", 2 }, { "Description", "Two elderly females transferred from the reservation center." } },
        new() { { "Animal", "Wolf" }, { "Place", "Sector F - Northern Forest" }, { "AnimalCount", 6 }, { "Description", "A structured pack of Canadian timber wolves." } }
    };
            foreach (var row in animals) InsertRow("AnimalCount", row);

            // 4. Tasks (Задачи со всеми возможными статусами: 0 - Новая, 1 - В процессе, 2 - Выполнена)
            var tasks = new List<Dictionary<string, object>>
    {
        // Выполненные задачи (Status = 2)
        new() {
            { "TaskDate", DateTime.Now.AddDays(-1) }, { "TaskTime", "08:30" }, { "CareType", "Morning Feeding" },
            { "Description", "Routine breakfast for the lion pride." }, { "Animal", "Lion" }, { "Place", "Sector A - Pride Lands" },
            { "Worker", "john_keeper" }, { "Status", 2 }
        },
        new() {
            { "TaskDate", DateTime.Now.AddDays(-1) }, { "TaskTime", "11:00" }, { "CareType", "Enclosure Cleaning" },
            { "Description", "Clean up before public opening hours." }, { "Animal", "Penguin" }, { "Place", "Sector B - Arctic Coast" },
            { "Worker", "emma_w" }, { "Status", 2 }
        },
        
        // Задачи в процессе выполнения (Status = 1)
        new() {
            { "TaskDate", DateTime.Now }, { "TaskTime", "14:15" }, { "CareType", "Water Treatment" },
            { "Description", "Emergency filter cleaning due to high turbidity." }, { "Animal", "Dolphin" }, { "Place", "Aquatic Center - Main Pool" },
            { "Worker", "robert_j" }, { "Status", 1 }
        },
        new() {
            { "TaskDate", DateTime.Now }, { "TaskTime", "16:00" }, { "CareType", "Dental Examination" },
            { "Description", "Check the alpha female capybara's teeth issue reported yesterday." }, { "Animal", "Capybara" }, { "Place", "Sector C - Wetlands" },
            { "Worker", "alice_vet" }, { "Status", 1 }
        },

        // Новые нераспределенные задачи (Status = 0, Worker = "")
        new() {
            { "TaskDate", DateTime.Now.AddDays(1) }, { "TaskTime", "09:00" }, { "CareType", "Weight Check" },
            { "Description", "Scheduled monthly monitoring of weight dynamics." }, { "Animal", "Elephant" }, { "Place", "Sector D - Savanna Elephant Park" },
            { "Worker", "" }, { "Status", 0 }
        },
        new() {
            { "TaskDate", DateTime.Now.AddDays(1) }, { "TaskTime", "10:30" }, { "CareType", "Vaccination" },
            { "Description", "Prepare syringes and safety tools before starting medical procedures." }, { "Animal", "Wolf" }, { "Place", "Sector F - Northern Forest" },
            { "Worker", "" }, { "Status", 0 }
        },
        new() {
            { "TaskDate", DateTime.Now.AddDays(2) }, { "TaskTime", "19:00" }, { "CareType", "Evening Feeding" },
            { "Description", "Late feeding. Ensure the gates are locked tightly right after." }, { "Animal", "Lion" }, { "Place", "Sector A - Pride Lands" },
            { "Worker", "" }, { "Status", 0 }
        }
    };
            foreach (var row in tasks) InsertRow("Tasks", row);
        }

        public DataRow? Authenticate(string login, string password)
        {
            var table = new DataTable();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT *
                FROM Employees
                WHERE Login = @login
                AND Password = @password;";

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            using var reader = command.ExecuteReader();
            table.Load(reader);

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }

        public void DeleteRow(string tableName, int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {tableName} WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public DataTable GetTable(string tableName)
        {
            var table = new DataTable();
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {tableName}";

            using var reader = command.ExecuteReader();
            table.Load(reader);

            return table;
        }

        public void InsertRow(string tableName, Dictionary<string, object> values)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();

            string columns = string.Join(", ", values.Keys);
            string parameters = string.Join(", ", values.Keys.Select(x => "@" + x));

            command.CommandText = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

            foreach (var pair in values)
            {
                command.Parameters.AddWithValue("@" + pair.Key, pair.Value ?? DBNull.Value);
            }

            command.ExecuteNonQuery();
        }

        public void UpdateRow(string tableName, Dictionary<string, object> values)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();

            int id = Convert.ToInt32(values["Id"]);
            var updateValues = new Dictionary<string, object>(values);
            updateValues.Remove("Id");

            string setClause = string.Join(", ", updateValues.Keys.Select(x => $"{x} = @{x}"));

            command.CommandText = $"UPDATE {tableName} SET {setClause} WHERE Id = @Id";

            command.Parameters.AddWithValue("@Id", id);
            foreach (var pair in updateValues)
            {
                command.Parameters.AddWithValue("@" + pair.Key, pair.Value ?? DBNull.Value);
            }

            command.ExecuteNonQuery();
        }

        public List<string> GetEmployees()
        {
            List<string> employees = new();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Login FROM Employees WHERE IsAdmin = 0 ORDER BY Login";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(reader.GetString(0));
            }

            return employees;
        }

        public void TakeTask(int id, string login)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE Tasks
                SET Worker = @worker, Status = 1
                WHERE Id = @id";

            command.Parameters.AddWithValue("@worker", login);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public void CompleteTask(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE Tasks
                SET Status = 2
                WHERE Id = @id";

            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public DataTable GetWorkerTasks(string login)
        {
            var table = new DataTable();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tasks WHERE Worker = @worker";
            command.Parameters.AddWithValue("@worker", login);

            using var reader = command.ExecuteReader();
            table.Load(reader);

            return table;
        }
    }
}