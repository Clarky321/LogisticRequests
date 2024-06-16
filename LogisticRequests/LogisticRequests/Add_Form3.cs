using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LogisticRequests
{
    public partial class Add_Form3 : Form
    {
        DataBase dataBase = new DataBase();

        public Add_Form3()
        {
            InitializeComponent();
            LoadData();
            SetupComboBox();
        }

        private void LoadData()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id_enterprises", "ID");
            dataGridView1.Columns.Add("enterprises", "Предприятия");
            dataGridView1.Columns.Add("cargo_type", "Тип груза");
            dataGridView1.Columns.Add("tonnage", "Тоннаж");
            dataGridView1.Columns.Add("weight_per_load", "Вес одной загрузки");
            dataGridView1.Columns.Add("load_city", "Город загрузки");
            dataGridView1.Columns.Add("unloading_city", "Город выгрузки");
            dataGridView1.Columns.Add("shipping_cost", "Цена доставки");
            dataGridView1.Columns.Add("timing", "Срок");
            dataGridView1.Columns.Add("status", "Статус");

            using (var conn = dataBase.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Enterprises";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["id_enterprises"], reader["enterprises"], reader["cargo_type"], reader["tonnage"], reader["weight_per_load"], reader["load_city"], reader["unloading_city"], reader["shipping_cost"], reader["timing"], reader["status"]);
                        }
                    }
                }
                conn.Close();
            }
        }

        private void SetupComboBox()
        {
            ComboBox_status.Items.AddRange(new string[] { "Открыто", "В работе", "Доставлено" });
            ComboBox_status.SelectedIndex = 0; // Default to first item
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a row first.");
                return;
            }

            var id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var status = ComboBox_status.SelectedItem.ToString();

            using (var conn = dataBase.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Enterprises SET status = @status WHERE id_enterprises = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

            MessageBox.Show("Status updated successfully.");
            LoadData(); // Reload data to reflect changes
        }
    }
}
