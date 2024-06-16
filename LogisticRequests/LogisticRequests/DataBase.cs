using System.Data.SQLite;
using System.IO;

namespace LogisticRequests
{
    internal class DataBase
    {
        private string connectionString;

        public DataBase()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string dataSource = "LogisticBase.sqlite";
            connectionString = $"Data Source={dataSource};Version=3;";
            if (!File.Exists(dataSource))
            {
                CreateDatabase();
            }
        }

        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
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
                        tonnage TEXT,
                        weight_per_load TEXT,
                        load_city TEXT,
                        unloading_city TEXT,
                        shipping_cost REAL,
                        timing TEXT,
                        status TEXT
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

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
