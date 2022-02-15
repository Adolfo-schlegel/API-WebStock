using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectionMysql
{
    public class ConnectionToStocksWeb
    {
        public static MySqlConnection connect()
        {
            try
            {
                string bd = "Database = stock_web; Data Source = localhost; port = 3306; user id = root; password = 10deagosto ;";

                MySqlConnection MySqlConnection = new MySqlConnection(bd);

                MySqlConnection.Open();

                return MySqlConnection;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("error " + ex);

                return null;
            }
        }
    }
}
