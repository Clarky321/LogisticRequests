using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace LogisticRequests
{
    public partial class sign_up : Form
    {

        DataBase dataBase = new DataBase();

        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            TextBox_FIO.MaxLength = 50;
            TextBox_User2.MaxLength = 30;
            TextBox_Password2.MaxLength = 30;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_FIO.Text) || string.IsNullOrEmpty(TextBox_User2.Text) || string.IsNullOrEmpty(TextBox_Password2.Text))
            {
                MessageBox.Show("Одно из полей не заполнено!");
                return;
            }

            if (checkuser(TextBox_User2.Text))
            {
                return;
            }

            string querystring = "INSERT INTO Account (FIO, login_user, password_user, is_admin) VALUES (@FIO, @Login, @Password, 0)";
            using (SQLiteCommand command = new SQLiteCommand(querystring, dataBase.GetConnection()))
            {
                command.Parameters.AddWithValue("@FIO", TextBox_FIO.Text);
                command.Parameters.AddWithValue("@Login", TextBox_User2.Text);
                command.Parameters.AddWithValue("@Password", TextBox_Password2.Text);

                dataBase.openConnection();

                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Аккаунт успешно создан", "Аккаунт создан");
                    log_in frm_login = new log_in();
                    frm_login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Не удалось создать аккаунт!");
                }

                dataBase.closeConnection();
            }
        }

        private Boolean checkuser(string username)
        {
            string querystring = "SELECT id_account FROM Account WHERE login_user = @Login";
            using (SQLiteCommand command = new SQLiteCommand(querystring, dataBase.GetConnection()))
            {
                command.Parameters.AddWithValue("@Login", username);

                dataBase.openConnection();
                var result = command.ExecuteScalar();
                dataBase.closeConnection();

                if (result != null)
                {
                    MessageBox.Show("Аккаунт с таким логином уже существует");
                    return true;
                }
                return false;
            }
        }

        private void btnLogIN_Click(object sender, EventArgs e)
        {
            log_in logIN = new log_in();
            logIN.Show();
            this.Hide();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            TextBox_Password2.PasswordChar = TextBox_Password2.PasswordChar == '\0' ? '•' : '\0';
        }
    }
}
