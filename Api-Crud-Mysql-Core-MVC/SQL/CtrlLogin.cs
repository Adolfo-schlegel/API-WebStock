using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Api_Crud_Mysql_Core_MVC.SQL
{  
    public class CtrlLogin : ConnectionMysql.ConnectionToStocksWeb
    {
        public int Validate_User(Models.Login login)
        {
            try
            {
                string query;
                List<int> list = new List<int>();
                MySqlConnection mySqlConnection = connect();
                MySqlDataReader reader;
                query = "SELECT id_user FROM users WHERE Email = '" + login.Email + "' and Password = '" + login.Password + "';";

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                reader = mySqlCommand.ExecuteReader();           
               
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Models.Login login1 = new Models.Login();

                        login1.Id = Convert.ToInt32(reader.GetString(0));

                        list.Add(login1.Id);
                    }
                    return list[0];
                }
                else
                {
                    return 0;
                }                                       
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
    }   
}
