using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite; // Используем SQLite

namespace LogisticRequests
{
    public partial class Add_Form2 : Form
    {
        DataBase dataBase = new DataBase();

        public Add_Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ClearField()
        {
            TextBox_FIO.Text = "";
            TextBox_Series_Pass.Text = "";
            TextBox_Pass_issued.Text = "";
            TextBox_Date_issued.Text = "";
            TextBox_Phone.Text = "";
            TextBox_Name_auto.Text = "";
            TextBox_Tractor.Text = "";
            TextBox_Trailer.Text = "";
            TextBox_Сarrying.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Проверяем корректность введенных данных
            if (string.IsNullOrEmpty(TextBox_FIO.Text) || string.IsNullOrEmpty(TextBox_Series_Pass.Text) || string.IsNullOrEmpty(TextBox_Pass_issued.Text) || string.IsNullOrEmpty(TextBox_Date_issued.Text) || string.IsNullOrEmpty(TextBox_Phone.Text) || string.IsNullOrEmpty(TextBox_Name_auto.Text) || string.IsNullOrEmpty(TextBox_Tractor.Text) || string.IsNullOrEmpty(TextBox_Trailer.Text) || string.IsNullOrEmpty(TextBox_Сarrying.Text))
            {
                MessageBox.Show("Одно из полей не заполнено!");
                return;
            }

            dataBase.openConnection();

            int carrying;
            if (!int.TryParse(TextBox_Сarrying.Text, out carrying))
            {
                MessageBox.Show("Грузоподёмность должна иметь числовой формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addQuery = "INSERT INTO Driver (FIO, Series_Pass, Pass_issued, Date_issued, Phone, Name_auto, Tractor, Trailer, Сarrying) VALUES (@FIO, @Series_Pass, @Pass_issued, @Date_issued, @Phone, @Name_auto, @Tractor, @Trailer, @Сarrying)";

            using (SQLiteCommand command = new SQLiteCommand(addQuery, dataBase.GetConnection()))
            {
                command.Parameters.AddWithValue("@FIO", TextBox_FIO.Text);
                command.Parameters.AddWithValue("@Series_Pass", TextBox_Series_Pass.Text);
                command.Parameters.AddWithValue("@Pass_issued", TextBox_Pass_issued.Text);
                command.Parameters.AddWithValue("@Date_issued", TextBox_Date_issued.Text);
                command.Parameters.AddWithValue("@Phone", TextBox_Phone.Text);
                command.Parameters.AddWithValue("@Name_auto", TextBox_Name_auto.Text);
                command.Parameters.AddWithValue("@Tractor", TextBox_Tractor.Text);
                command.Parameters.AddWithValue("@Trailer", TextBox_Trailer.Text);
                command.Parameters.AddWithValue("@Сarrying", carrying);

                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataBase.closeConnection();
            ClearField();
        }
    }
}