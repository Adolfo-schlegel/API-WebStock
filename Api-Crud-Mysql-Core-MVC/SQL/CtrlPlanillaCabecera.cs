using Api_Crud_Mysql_Core_MVC.Models;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;
using MySql.Data.MySqlClient;
using System.Text.Json;
using Newtonsoft.Json;
using System.Data;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlPlanillaCabecera : ConnectionMysql.ConnectionToStocksWeb, IPlanillaCabecera
    {
        string query = "";
        MySqlConnection connection = connect();
        MySqlCommand? command;
        MySqlDataReader? reader;
        public int Create(PlanillaCabecera model)
        {
            try
            {
                object ColJson = JsonConvert.DeserializeObject(model.Campos_Json.ToString());           
                List<string> content = JsonConvert.DeserializeObject<List<string>>(ColJson.ToString());

                var planilla_cabecera = new {Col = content};

                //string arrayJson = JsonConvert.SerializeObject(content);  
                string jsonString = System.Text.Json.JsonSerializer.Serialize(planilla_cabecera);

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
        public List<string>? Read_NamesTables(int userId)
        {
            List<string> lsnames = new List<string>();
            query = "SELECT * FROM planilla_cabecera Where user_id = '"+userId+"' ;";
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())                                    
                    lsnames.Add(reader.GetString(1));                
                return lsnames;
            }
            return null;
        }
        public PlanillaCabecera? Read_camp(int userId, string table_name)
        {
            PlanillaCabecera cabecera = new PlanillaCabecera();

            query = "SELECT id, JSON_EXTRACT(Campos_json, '$.Col') From Planilla_cabecera Where user_id = '" + userId + "' and Nombre_tabla = '"+table_name+"';";
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {                                        
                    cabecera.id = reader.GetInt32(0);
                    var collection = JsonConvert.DeserializeObject(reader.GetString(1));
                    cabecera.Campos_Json = System.Text.Json.JsonSerializer.Deserialize<List<string>>(collection.ToString());                    
                }
                return cabecera;
            }

            return null;
        }
    }
}
