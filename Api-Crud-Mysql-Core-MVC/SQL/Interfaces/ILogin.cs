using Api_Crud_Mysql_Core_MVC.Models;

namespace Api_Crud_Mysql_Core_MVC.SQL.Interfaces
{
    public interface ILogin
    {
        Reply Validate_User(Login model);
    }
}
