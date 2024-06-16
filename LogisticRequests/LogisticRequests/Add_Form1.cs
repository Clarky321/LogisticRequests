using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite; // Используем SQLite

namespace LogisticRequests
{
    public partial class Add_Form1 : Form
    {
        DataBase dataBase = new DataBase();

        public Add_Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ClearField()
        {
            TextBox_Enterprasis.Text = "";
            TextBox_Cargo_type.Text = "";
            TextBox_Tonnage.Text = "";
            TextBox_Weight_per_load.Text = "";
            TextBox_Load_city.Text = "";
            TextBox_Unloading_city.Text = "";
            TextBox_Cost.Text = "";
            TextBox_Timing.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Проверяем корректность введенных данных
            if (string.IsNullOrEmpty(TextBox_Enterprasis.Text) || string.IsNullOrEmpty(TextBox_Cargo_type.Text) || string.IsNullOrEmpty(TextBox_Tonnage.Text) || string.IsNullOrEmpty(TextBox_Weight_per_load.Text) || string.IsNullOrEmpty(TextBox_Load_city.Text) || string.IsNullOrEmpty(TextBox_Unloading_city.Text) || string.IsNullOrEmpty(TextBox_Timing.Text))
            {
                MessageBox.Show("Одно из полей не заполнено!");
                return;
            }

            dataBase.openConnection();

            var enterprises = TextBox_Enterprasis.Text;
            var cargo_type = TextBox_Cargo_type.Text;
            var tonnage = TextBox_Tonnage.Text;
            var weight_per_load = TextBox_Weight_per_load.Text;
            var load_city = TextBox_Load_city.Text;
            var unloading_city = TextBox_Unloading_city.Text;
            int shipping_cost;
            var timing = TextBox_Timing.Text;
            var status = ComboBox_status.Text;

            if (int.TryParse(TextBox_Cost.Text, out shipping_cost))
            {
                var addQuery = "INSERT INTO Enterprises (enterprises, cargo_type, tonnage, weight_per_load, load_city, unloading_city, shipping_cost, timing, status) VALUES (@enterprises, @cargo_type, @tonnage, @weight_per_load, @load_city, @unloading_city, @shipping_cost, @timing, @status)";

                using (SQLiteCommand command = new SQLiteCommand(addQuery, dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@enterprises", enterprises);
                    command.Parameters.AddWithValue("@cargo_type", cargo_type);
                    command.Parameters.AddWithValue("@tonnage", tonnage);
                    command.Parameters.AddWithValue("@weight_per_load", weight_per_load);
                    command.Parameters.AddWithValue("@load_city", load_city);
                    command.Parameters.AddWithValue("@unloading_city", unloading_city);
                    command.Parameters.AddWithValue("@shipping_cost", shipping_cost);
                    command.Parameters.AddWithValue("@timing", timing);
                    command.Parameters.AddWithValue("@status", status);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Запись успешно создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Цена должна иметь числовой формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataBase.closeConnection();

            //ClearField();
        }
    }
}