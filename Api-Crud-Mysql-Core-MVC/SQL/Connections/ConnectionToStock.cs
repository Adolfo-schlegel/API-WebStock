using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ConnectionMysql
{
    public class ConnectionToStock
    {
       public MySqlConnection connect()
       {
            try
            {
                string bd = "Database = stock_eet2; Data Source = localhost; port = 3306; user id = root; password = 10deagosto ;";

                MySqlConnection MySqlConnection = new MySqlConnection(bd);

                MySqlConnection.Open();

                return MySqlConnection;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("error " + ex);

                return null;
            }
       }
    }
}