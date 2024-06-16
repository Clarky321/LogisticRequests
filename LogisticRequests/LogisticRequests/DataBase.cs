using System.Data.SQLite;
using System.IO;

namespace LogisticRequests
{
    internal class DataBase
    {
        private SQLiteConnection connection;

        public DataBase()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string dataSource = "LogisticBase.sqlite";
            string connectionString = $"Data Source={dataSource};Version=3;";
            connection = new SQLiteConnection(connectionString);
            if (!File.Exists(dataSource))
            {
                CreateDatabase();
            }
        }

        private void CreateDatabase()
        {
            connection.Open();
            string sql = @"
                CREATE TABLE IF NOT EXISTS Account (
                    id_account INTEGER PRIMARY KEY AUTOINCREMENT,
                    FIO TEXT NOT NULL,
                    login_user TEXT NOT NULL UNIQUE,
                    password_user TEXT NOT NULL,
                    is_admin BOOLEAN NOT NULL DEFAULT 0
                );

                CREATE TABLE IF NOT EXISTS Enterprises (
                    id_enterprises INTEGER PRIMARY KEY AUTOINCREMENT,
                    enterprises TEXT,
                    cargo_type TEXT,
                    tonnage INTEGER,
                    weight_per_load TEXT,
                    load_city TEXT,
                    unloading_city TEXT,
                    shipping_cost REAL,
                    timing TEXT
                );

                CREATE TABLE IF NOT EXISTS Driver (
                    id_driver INTEGER PRIMARY KEY AUTOINCREMENT,
                    FIO TEXT,
                    Series_Pass TEXT,
                    Pass_issued TEXT,
                    Date_issued TEXT,
                    Phone TEXT,
                    Name_auto TEXT,
                    Tractor TEXT,
                    Trailer TEXT,
                    Сarrying INTEGER
                );
            ";

            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SQLiteConnection GetConnection()
        {
            return connection;
        }
    }
}