using MySql.Data.MySqlClient;
using Api_Crud_Mysql_Core_MVC.Models;
namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlStockUser :ConnectionMysql.ConnectionToStocksWeb
    {
        public List<object> Get(StockUser model)
        {
            try
            {
                string query;
                List<object> lista = new List<object>();
                MySqlConnection connection = connect();
                MySqlDataReader? reader = null;

                query = "SELECT id_stock, nombre, marca, modelo, tipo, area, cantidad, estado, id_user, token FROM stock join users on id_user = user_id WHERE user_id = '" + model.Id_user + "';";

                MySqlCommand command1 = new MySqlCommand(query, connection);

                reader = command1.ExecuteReader();

                while (reader.Read())
                {
                    Models.StockUser stockUser = new Models.StockUser();

                    stockUser.Id = Convert.ToInt32(reader.GetString(0));
                    stockUser.Nombre = reader.GetString(1);
                    stockUser.Marca = reader.GetString(2);
                    stockUser.Modelo = reader.GetString(3);
                    stockUser.Tipo = reader.GetString(4);
                    stockUser.Area = reader.GetString(5);
                    stockUser.Cantidad = Convert.ToInt32(reader.GetString(6));
                    stockUser.Estado = reader.GetString(7);
                    stockUser.Id_user = Convert.ToInt32(reader.GetString(8));

                    lista.Add(stockUser);
                }
                connection.Close();

                return lista;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int Post(Models.StockUser stock)
        {
            try
            {
                string query;

                MySqlConnection mySqlConnection = connect();

                query = "INSERT INTO stock (nombre,marca,modelo,tipo,cantidad,estado,area,id_user) VALUES ('" + stock.Nombre + "','" + stock.Marca + "','" + stock.Modelo + "','" + stock.Tipo + "','" + Convert.ToInt32(stock.Cantidad) + "','" + stock.Estado + "','" + stock.Area +"','"+  stock.Id_user+ "');";

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

                return 1;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);

                return 0;
            }
        }
    }
}
