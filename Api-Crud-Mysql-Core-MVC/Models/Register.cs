namespace Api_Crud_Mysql_Core_MVC.Models
{
    public class Register
    {
        string password;
        string email;
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}
