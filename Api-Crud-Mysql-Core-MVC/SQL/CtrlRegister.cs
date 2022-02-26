using MySql.Data.MySqlClient;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlRegister : ConnectionMysql.ConnectionToStocksWeb, IRegister
    {
        public int Create(Models.Register register)
        {
            try
            {
                string query;

                MySqlConnection mySqlConnection = connect();

                query = "INSERT INTO Users (Email, Password, idEstatus) VALUES ('" + register.Email + "','" + register.Password + "','" + 1 + "');";

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

                return 1;
            }
            catch 
            {
                return 0;
            }
        }
    }
}
