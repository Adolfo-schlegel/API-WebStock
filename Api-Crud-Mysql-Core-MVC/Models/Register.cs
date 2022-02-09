namespace Api_crud_mysql_core.Models
{
    public class Register
    {
        string password;
        string email;
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}
