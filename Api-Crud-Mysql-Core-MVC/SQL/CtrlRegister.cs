using MySql.Data.MySqlClient;

namespace Api_crud_mysql_core.SQL
{
    public class CtrlRegister : ConnectionMysql.ConnectionToStocksWeb
    {
        public int Create(Models.Register register)
        {
            try
            {
                string query;

                MySqlConnection mySqlConnection = connect();

                query = "INSERT INTO Users (Email, Password) VALUES ('" + register.Email + "','" + register.Password + "');";

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
