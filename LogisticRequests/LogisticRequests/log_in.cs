using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace LogisticRequests
{
    public partial class log_in : Form
    {

        DataBase dataBase = new DataBase();

        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void log_in_Load(object sender, EventArgs e)
        {
            TextBox_User.MaxLength = 30;
            TextBox_Password.MaxLength = 30;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            var loginUser = TextBox_User.Text;
            var passwordUser = TextBox_Password.Text;

            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                DataTable table = new DataTable();

                string querystring = "SELECT id_account, login_user, password_user, is_admin FROM Account WHERE login_user = @login AND password_user = @password";
                SQLiteCommand command = new SQLiteCommand(querystring, dataBase.GetConnection());
                command.Parameters.AddWithValue("@login", loginUser);
                command.Parameters.AddWithValue("@password", passwordUser);

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    var user = new checkUser(table.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(table.Rows[0].ItemArray[3]));

                    MessageBox.Show("Вы успешно авторизовались", "Успешная авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogisticForm logForm = new LogisticForm(user);
                    logForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Такого аккаунта не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            TextBox_Password.PasswordChar = TextBox_Password.PasswordChar == '\0' ? '•' : '\0';
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            sign_up frm_signup = new sign_up();
            frm_signup.Show();
            this.Hide();
        }
    }
}