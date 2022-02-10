namespace Api_Crud_Mysql_Core_MVC.Models
{
    public class Login
    {
        int id;
        string email;
        string password;
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id; set => id = value; }
    }
}
