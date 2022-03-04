using Api_Crud_Mysql_Core_MVC.Models;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;
using MySql.Data.MySqlClient;
using System.Text.Json;
using Newtonsoft.Json;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlPlanillaCabecera : ConnectionMysql.ConnectionToStocksWeb, IPlanillaCabecera
    {
        string query = "";
        MySqlConnection connection = connect();
        MySqlCommand? command;
        MySqlDataReader reader;
        public int Create(PlanillaCabecera model)
        {
            try
            {
                object contentJson = JsonConvert.DeserializeObject(model.Campos_Json.ToString());

                List<string> content = JsonConvert.DeserializeObject<List<string>>(contentJson.ToString());

                //string arrayJson = JsonConvert.SerializeObject(content);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(content);

                query = "insert into planilla_cabecera (Nombre_tabla, Campos_Json, user_id)" +
                    "Values ('" + model.Nombre_tabla + "', '" + jsonString + "', '" + model.user_id + "')";

                command = new MySqlCommand(query, connection);
                int result = command.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public List<PlanillaCabecera>? Read(int userId)
        {
            List<PlanillaCabecera> lsCabecera = new List<PlanillaCabecera>();
            query = "SELECT * FROM planilla_cabecera Where user_id = '"+userId+"';";
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PlanillaCabecera oCabecera = new PlanillaCabecera();

                    oCabecera.id = reader.GetInt32(0);
                    oCabecera.Nombre_tabla = reader.GetString(1);
                    oCabecera.Campos_Json = reader.GetString(2);

                    lsCabecera.Add(oCabecera);
                }

                return lsCabecera;
            }

            return null;
        }
    }
}
