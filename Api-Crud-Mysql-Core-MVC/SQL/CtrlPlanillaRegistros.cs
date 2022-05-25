using Api_Crud_Mysql_Core_MVC.Models;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlPlanillaRegistros : ConnectionMysql.ConnectionToStocksWeb, IPlanillaRegistros
    {
        string query = "";
        MySqlConnection connection = connect();
        MySqlCommand? command;
        MySqlDataReader? reader;

        public List<PlanillaRegistros>? Read(int cabecera_id)
        {
            List<PlanillaRegistros> lst = new List<PlanillaRegistros>();
            query = "Select id, JSON_EXTRACT(Registros_json, '$.Reg'), cabecera_id FROM stock_web.planilla_registros WHERE cabecera_id = " + cabecera_id;
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    PlanillaRegistros planillaRegistros = new PlanillaRegistros();
                    planillaRegistros.Id = reader.GetInt32(0);

                    var collection = JsonConvert.DeserializeObject(reader.GetString(1));
                    planillaRegistros.Registros_Json = JsonConvert.DeserializeObject<List<string>>(collection.ToString());

                    planillaRegistros.cabecera_id = reader.GetInt32(2);

                    lst.Add(planillaRegistros);
                }
                return lst;
            }
            return new List<PlanillaRegistros>();
        }

        public List<string>? ReadById(int id)
        {
            List<string> lstItems = new();
            query = "SELECT JSON_EXTRACT(Registros_json, '$.Reg') FROM stock_web.planilla_registros WHERE id = " + id;
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())                
                    lstItems = JsonConvert.DeserializeObject<List<string>>(reader.GetString(0));                
                return lstItems;
            }
            return null;
        }
        public int Create(PlanillaRegistros model)
        {
            try
            {
                var planilla_Registro = new { Reg = model.Registros_Json };

                string jsonString = System.Text.Json.JsonSerializer.Serialize(planilla_Registro);

                query = "Insert Into planilla_registros (cabecera_id, Registros_Json) Values ('" + model.cabecera_id + "', '" + jsonString + "' )";
                command = new MySqlCommand(query, connection);
                int result = command.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            try
            {
                query = "DELETE FROM planilla_registros WHERE id = " + id;
                command = new MySqlCommand(query, connection);
                return command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public int Update(PlanillaRegistros model)
        {
            try
            {
                var oRegistro = new { Reg = model.Registros_Json };
                string jsonString = System.Text.Json.JsonSerializer.Serialize(oRegistro);
                //la forma mas facil es pisar todo el registro con un nuevo objeto 
                query = $"UPDATE planilla_registros set Registros_Json = '{jsonString}' WHERE id = {model.Id}";               

                //la otra forma es reemplazar el arreglo que esta dentro de la propiedad del objeto json
                //string query2 = $"UPDATE planilla_registros SET Registros_Json = JSON_REPLACE(Registros_Json, '$.Reg', JSON_ARRAY('one', 'two', 'three', 'four')) where id = 33;";
                command = new MySqlCommand(query, connection);
                int result = command.ExecuteNonQuery();
                return result;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }   
}
