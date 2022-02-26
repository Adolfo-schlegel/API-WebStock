using MySql.Data.MySqlClient;
using Api_Crud_Mysql_Core_MVC.Models;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlStockUser :ConnectionMysql.ConnectionToStocksWeb, IStockUser
    {
        public List<object> Get(User model)
        {
             string query;
             List<object> lista = new List<object>();
             MySqlConnection connection = connect();
             MySqlDataReader? reader = null;

             query = "SELECT id_stock, nombre, marca, modelo, tipo, area, cantidad, estado, id_user FROM stock join users on id_user = user_id WHERE user_id = '" +model.user_id + "';";

             MySqlCommand command1 = new MySqlCommand(query, connection);

             reader = command1.ExecuteReader();

             while (reader.Read())
             {
                 StockUser stockUser = new StockUser();

                 stockUser.Id = Convert.ToInt32(reader.GetString(0));
                 stockUser.Nombre = reader.GetString(1);
                 stockUser.Marca = reader.GetString(2);
                 stockUser.Modelo = reader.GetString(3);
                 stockUser.Tipo = reader.GetString(4);
                 stockUser.Area = reader.GetString(5);
                 stockUser.Cantidad = Convert.ToInt32(reader.GetString(6));
                 stockUser.Estado = reader.GetString(7);
                 stockUser.user_id = Convert.ToInt32(reader.GetString(8));

                 lista.Add(stockUser);
             }
             connection.Close();

             return lista;
        }

        public int Post(StockUser stock)
        {
            try
            {
                string query;

                MySqlConnection mySqlConnection = connect();

                query = "INSERT INTO stock (nombre,marca,modelo,tipo,cantidad,estado,area,user_id) VALUES ('" + stock.Nombre + "','" + stock.Marca + "','" + stock.Modelo + "','" + stock.Tipo + "','" + Convert.ToInt32(stock.Cantidad) + "','" + stock.Estado + "','" + stock.Area +"','"+  stock.user_id+ "');";

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

                return 1;
            }
            catch (MySqlException)
            {                
                return 0;
            }
        }

        public int Delete(int id_stock)
        {
            try
            {
                string query = "DELETE FROM stock WHERE id_stock = '" + id_stock + "';";

                MySqlConnection mySqlConnection = connect();

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

                return 1;
            }
            catch(MySqlException)
            {
                return 0;
            }
        }

        public List<StockUser> GetById(int id_stock)
        {
            string query;
            List<StockUser> lista = new List<StockUser>();
            MySqlConnection connection = connect();
            MySqlDataReader? reader = null;

            query = "SELECT id_stock, nombre, marca, modelo, tipo, area, cantidad, estado, user_id FROM stock WHERE id_stock = '" + id_stock + "';";

            MySqlCommand command1 = new MySqlCommand(query, connection);

            reader = command1.ExecuteReader();

            while (reader.Read())
            {
                StockUser stockUser = new StockUser();

                stockUser.Id = Convert.ToInt32(reader.GetString(0));
                stockUser.Nombre = reader.GetString(1);
                stockUser.Marca = reader.GetString(2);
                stockUser.Modelo = reader.GetString(3);
                stockUser.Tipo = reader.GetString(4);
                stockUser.Area = reader.GetString(5);
                stockUser.Cantidad = Convert.ToInt32(reader.GetString(6));
                stockUser.Estado = reader.GetString(7);
                stockUser.user_id = Convert.ToInt32(reader.GetString(8));

                lista.Add(stockUser);
            }
            connection.Close();

            return lista;
        }

        public int Put(StockUser model)
        {
            try
            {
                string query = "UPDATE stock SET nombre = '" + model.Nombre + "', marca = '" + model.Marca + "', tipo = '" + model.Tipo + "', modelo = '" + model.Modelo + "', cantidad= '" + model.Cantidad + "', estado= '" + model.Estado + "', area  = '" + model.Area + "' WHERE id_stock = '" + model.Id + "';";

                MySqlConnection mySqlConnection = connect();

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

                return 1;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR :" + ex);
                return 0;
            }
        }
    }
}
