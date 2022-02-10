using MySql.Data.MySqlClient;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlStockUser :ConnectionMysql.ConnectionToStocksWeb
    {
        public List<object> Get(int id_user)
        {
            try
            {
                string query;
                List<object> lista = new List<object>();
                MySqlConnection connection = connect();
                MySqlDataReader reader = null;

                query = "SELECT id_stock, nombre, marca, modelo, tipo, area, cantidad, estado, id_user FROM stock WHERE id_user = '" + id_user + "';";

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
            catch
            {
                return null;
            }
        }

        public bool Post(Models.StockUser stock)
        {
            try
            {
                string query;

                MySqlConnection mySqlConnection = connect();

                query = "INSERT INTO stock (nombre,marca,modelo,tipo,cantidad,estado,area,id_user) VALUES ('" + stock.Nombre + "','" + stock.Marca + "','" + stock.Modelo + "','" + stock.Tipo + "','" + Convert.ToInt32(stock.Cantidad) + "','" + stock.Estado + "','" + stock.Area +"','"+  stock.Id_user+ "');";

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}
