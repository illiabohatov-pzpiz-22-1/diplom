using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;

namespace DIPLOM_
{
    public sealed class DatabaseService
    {
        private readonly string _dbPath;
        private readonly string _connectionString;

        public DatabaseService()
        {
            _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.db");
            _connectionString = $"Data Source={_dbPath}";
            EnsureDatabase();
        }

        public void EnsureDatabase()
        {
            var folder = Path.GetDirectoryName(_dbPath);
            if (!string.IsNullOrWhiteSpace(folder) && !Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS CareTypes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Animal TEXT NOT NULL,
                    Description TEXT
                );

                CREATE TABLE IF NOT EXISTS Employees (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Login TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    IsAdmin INTEGER NOT NULL DEFAULT 0
                );

                CREATE TABLE IF NOT EXISTS Tasks (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TaskDate DATETIME NOT NULL,
                    TaskTime TEXT NOT NULL,
                    CareType TEXT NOT NULL,
                    Description TEXT,
                    Animal TEXT,
                    Place TEXT,
                    Worker TEXT,
                    Status INTEGER NOT NULL DEFAULT 0
                );
                
                CREATE TABLE IF NOT EXISTS AnimalCount (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Animal TEXT NOT NULL,
                    Place TEXT NOT NULL,
                    AnimalCount INTEGER NOT NULL,
                    Description TEXT
                );

                ";

            using var checkCommand = connection.CreateCommand();

            checkCommand.CommandText =
                "SELECT COUNT(*) FROM Employees;";

            long count = Convert.ToInt64(checkCommand.ExecuteScalar());

            if (count == 0)
            {
                using var insertCommand = connection.CreateCommand();

                insertCommand.CommandText =
                    @"INSERT INTO Employees
                      (Name, Login, Password, IsAdmin)
                      VALUES
                      ('Администратор',
                       'admin',
                       'admin',
                       1);";

                insertCommand.ExecuteNonQuery();
            }

            command.ExecuteNonQuery();
        }

        public DataRow? Authenticate(string login, string password)
        {
            var table = new DataTable();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText =
                @"SELECT *
                  FROM Employees
                  WHERE Login = $login
                  AND Password = $password;";

            command.Parameters.AddWithValue("$login", login);
            command.Parameters.AddWithValue("$password", password);

            using var reader = command.ExecuteReader();

            table.Load(reader);

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }


        public void DeleteRow(string tableName, int id)
        {
            using var connection =
                new SqliteConnection(_connectionString);

            connection.Open();

            using var command =
                connection.CreateCommand();

            command.CommandText =
                $"DELETE FROM {tableName} WHERE Id=$id";

            command.Parameters.AddWithValue(
                "$id",
                id);

            command.ExecuteNonQuery();
        }
        public DataTable GetTable(string tableName)
        {
            var table = new DataTable();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {tableName}";

            using var reader = command.ExecuteReader();
            table.Load(reader);

            return table;
        }
        public void InsertRow(string tableName, Dictionary<string, object> values)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();

            string columns = string.Join(", ", values.Keys);
            string parameters = string.Join(", ", values.Keys.Select(x => "$" + x));

            command.CommandText = $"INSERT INTO {tableName} ({columns}) " + $"VALUES ({parameters})";

            foreach (var pair in values)
            {
                command.Parameters.AddWithValue(
                    "$" + pair.Key,
                    pair.Value);
            }

            command.ExecuteNonQuery();
        }
        public void UpdateRow(string tableName, Dictionary<string, object> values)
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();

            using var command = connection.CreateCommand();

            int id = Convert.ToInt32(values["Id"]);

            values.Remove("Id");

            string setClause = string.Join(", ", values.Keys.Select(x => $"{x} = ${x}"));

            command.CommandText =
                $"UPDATE {tableName} " +
                $"SET {setClause} " +
                $"WHERE Id = $Id";

            command.Parameters.AddWithValue("$Id", id);

            foreach (var pair in values)
            {
                command.Parameters.AddWithValue("$" + pair.Key, pair.Value);
            }

            command.ExecuteNonQuery();
        }


        //public void UpdateEmployee(int id, string name, string login, string password, bool IsAdmin)
        //{
        //    ExecuteNonQuery(
        //        "UPDATE Employees SET Name = $name, Login = $Login, Password = $Password, IsAdmin = $IsAdmin WHERE Id = $id;",
        //        new SqliteParameter[]
        //        {
        //            new SqliteParameter("$name", name),
        //            new SqliteParameter("$Login", login),
        //            new SqliteParameter("$Password", password),
        //            new SqliteParameter("$IsAdmin", IsAdmin),
        //            new SqliteParameter("$id", id)
        //        });
        //}
        //public void DeleteEmployee(int id)
        //{
        //    using var connection =
        //        new SqliteConnection(_connectionString);

        //    connection.Open();

        //    using var command =
        //        connection.CreateCommand();

        //    command.CommandText =
        //        "DELETE FROM Employees WHERE Id = $id";

        //    command.Parameters.AddWithValue("$id", id);

        //    command.ExecuteNonQuery();
        //}

        public List<string> GetEmployees()
        {
            List<string> employees = new();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = "SELECT Login FROM Employees WHERE IsAdmin = 0 ORDER BY Login";

            using var reader = command.ExecuteReader();

            while (reader.Read()) employees.Add(reader.GetString(0));

            return employees;
        }
        public void TakeTask(int id, string login)
        {
            using var connection =
                new SqliteConnection(_connectionString);

            connection.Open();

            using var command =
                connection.CreateCommand();

            command.CommandText =
                @"UPDATE Tasks
          SET Worker = $worker,
              Status = 1
          WHERE Id = $id";

            command.Parameters.AddWithValue(
                "$worker",
                login);

            command.Parameters.AddWithValue(
                "$id",
                id);

            command.ExecuteNonQuery();
        }
        public void CompleteTask(int id)
        {
            using var connection =
                new SqliteConnection(_connectionString);

            connection.Open();

            using var command =
                connection.CreateCommand();

            command.CommandText =
                @"UPDATE Tasks
          SET Status = 2
          WHERE Id = $id";

            command.Parameters.AddWithValue(
                "$id",
                id);

            command.ExecuteNonQuery();
        }
        public DataTable GetWorkerTasks(string login)
        {
            var table = new DataTable();

            using var connection =
                new SqliteConnection(_connectionString);

            connection.Open();

            using var command =
                connection.CreateCommand();

            command.CommandText =
                "SELECT * FROM Tasks WHERE Worker = $worker";

            command.Parameters.AddWithValue(
                "$worker",
                login);

            using var reader =
                command.ExecuteReader();

            table.Load(reader);

            return table;
        }
        private void ExecuteNonQuery(string commandText, SqliteParameter[] parameters)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = commandText;

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            command.ExecuteNonQuery();
        }
    }
}
