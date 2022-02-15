using MySql.Data.MySqlClient;
using Api_Crud_Mysql_Core_MVC.SQL;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlBase : ConnectionMysql.ConnectionToStocksWeb
    {
        public bool VerifyToken(string token)
        {
            /*** Validar el token ***/


            // here code


            /*\** Validar el token **\*/

            bool result = false; // TOKEN VALIDO = TRUE

            if(result == true)
                return true;
            return false;

        }
    }
}
