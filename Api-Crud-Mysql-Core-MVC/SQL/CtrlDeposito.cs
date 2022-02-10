using MySql.Data.MySqlClient;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlDeposito : ConnectionMysql.ConnectionToStock
    {
        int id;
        public int Id { get => id; set => id = value; }

        public List<object> Get_id()
        {
            string query;
            List<object> lista = new List<object>();
            MySqlConnection connection = connect();
            MySqlDataReader reader = null;

            query = "SELECT id, nombre, marca, tipo, modelo, cantidad, estado, area FROM deposito_comp WHERE id = '" + id + "';";

            MySqlCommand command1 = new MySqlCommand(query, connection);

            reader = command1.ExecuteReader();

            while (reader.Read())
            {
                Models.Deposito deposito = new Models.Deposito();

                deposito.Id = Convert.ToInt32(reader.GetString(0));
                deposito.Nombre = reader.GetString(1);
                deposito.Marca = reader.GetString(2);
                deposito.Tipo = reader.GetString(3);
                deposito.Modelo = reader.GetString(4);
                deposito.Cantidad = Convert.ToInt32(reader.GetString(5));
                deposito.Estado = reader.GetString(6);
                deposito.Area = reader.GetString(7);
                lista.Add(deposito);
            }
            connection.Close();

            return lista;
        }

        public void Post(Models.Deposito __deposito)
        {
            Models.Deposito _deposito = new Models.Deposito();

            _deposito = __deposito;

            try
            {
                string query;

                MySqlConnection mySqlConnection = connect();

                query = "INSERT INTO deposito_comp (nombre,marca,modelo,tipo,cantidad,estado,area) VALUES ('" + _deposito.Nombre + "','" + _deposito.Marca + "','" + _deposito.Modelo + "','" + _deposito.Tipo + "','" + Convert.ToInt32(_deposito.Cantidad) + "','" + _deposito.Estado + "','" + _deposito.Area + "')";

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public List<object> Get()
        {
            try
            {
                string query;
                List<object> lista = new List<object>();
                MySqlConnection connection = connect();
                MySqlDataReader reader = null;

                query = "SELECT id, nombre, marca, tipo, modelo, cantidad, estado, area FROM deposito_comp";

                MySqlCommand command = new MySqlCommand(query, connection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Models.Deposito deposito = new Models.Deposito();

                    deposito.Id = Convert.ToInt32(reader.GetString(0));
                    deposito.Nombre = reader.GetString(1);
                    deposito.Marca = reader.GetString(2);
                    deposito.Tipo = reader.GetString(3);
                    deposito.Modelo = reader.GetString(4);
                    deposito.Cantidad = Convert.ToInt32(reader.GetString(5));
                    deposito.Estado = reader.GetString(6);
                    deposito.Area = reader.GetString(7);

                    lista.Add(deposito);
                }
                connection.Close();

                return lista;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR" + ex);
            }

            return null;
        }

        public void Delete(int id)
        {
            try
            {
                string query = "DELETE FROM deposito_comp WHERE id = '" + id + "';";

                MySqlConnection mySqlConnection = connect();

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR :" + ex);
            }
        }

        public void Put(Models.Deposito deposito)
        {
            try
            {
                string query = "UPDATE deposito_comp SET nombre = '" + deposito.Nombre + "', marca = '" + deposito.Marca + "', tipo = '" + deposito.Tipo + "', modelo = '" + deposito.Modelo + "', cantidad= '" + deposito.Cantidad + "', estado= '" + deposito.Estado + "', area  = '" + deposito.Area + "' WHERE id = '" + deposito.Id + "';";

                MySqlConnection mySqlConnection = connect();

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR :" + ex);
            }
        }
    }
}

