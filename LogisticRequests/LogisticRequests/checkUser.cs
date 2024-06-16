namespace LogisticRequests
{
    public class checkUser
    {
        public string Login { get; set; }
        public bool IsAdmin { get; }
        public string Status => IsAdmin ? "Сотрудник" : "Водитель";

        public checkUser(string login, bool isAdmin)
        {
            Login = login.Trim();
            IsAdmin = isAdmin;
        }
    }
}