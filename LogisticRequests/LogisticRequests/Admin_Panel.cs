using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite; // Используем SQLite

namespace LogisticRequests
{
    public partial class Admin_Panel : Form
    {
        DataBase dataBase = new DataBase();

        public Admin_Panel()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id_account", "ID");
            dataGridView1.Columns.Add("FIO", "ФИО");
            dataGridView1.Columns.Add("login_user", "Логин");
            dataGridView1.Columns.Add("password_user", "Пароль");
            var checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "IsAdmin";
            dataGridView1.Columns.Add(checkColumn);
        }

        private void ReadSingleRow(SQLiteDataReader record)
        {
            dataGridView1.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetBoolean(4));
        }

        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();

            string querystring = "SELECT * FROM Account;";

            using (SQLiteCommand command = new SQLiteCommand(querystring, dataBase.GetConnection()))
            {
                dataBase.openConnection();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReadSingleRow(reader);
                    }
                }
                dataBase.closeConnection();
            }
        }

        private void Admin_Panel_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                var isadmin = Convert.ToBoolean(dataGridView1.Rows[index].Cells[4].Value);

                var changeQuery = "UPDATE Account SET is_admin = @is_admin WHERE id_account = @id;";

                using (SQLiteCommand command = new SQLiteCommand(changeQuery, dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@is_admin", isadmin);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }

            dataBase.closeConnection();
            RefreshDataGrid();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            dataBase.openConnection();

            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            var id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);

            var deleteQuery = "DELETE FROM Account WHERE id_account = @id;";

            using (SQLiteCommand command = new SQLiteCommand(deleteQuery, dataBase.GetConnection()))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }

            dataBase.closeConnection();
            RefreshDataGrid();
        }
    }
}