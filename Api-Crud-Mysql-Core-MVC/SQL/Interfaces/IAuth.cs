using Api_Crud_Mysql_Core_MVC.Models;

namespace Api_Crud_Mysql_Core_MVC.SQL.Interfaces
{
    public interface IAuth
    {
        public string GetNewToken(Login model);
    }
}
