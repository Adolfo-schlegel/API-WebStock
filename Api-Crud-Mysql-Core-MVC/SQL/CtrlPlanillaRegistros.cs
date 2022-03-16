using Api_Crud_Mysql_Core_MVC.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class CtrlPlanillaRegistros : ConnectionMysql.ConnectionToStocksWeb
    {
        string query = "";
        MySqlConnection connection = connect();
        MySqlCommand? command;
        MySqlDataReader? reader;

        public List<PlanillaRegistros>? Read(int cabecera_id)
        {
            List<PlanillaRegistros> lst = new List<PlanillaRegistros>();
            query = "Select * from stock_web.planilla_registros where cabecera_id = " + cabecera_id;
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

                    planillaRegistros.cabecera_id = reader.GetInt32(3);

                    lst.Add(planillaRegistros);
                }
                return lst;
            }
            return null;
        }

        public List<PlanillaRegistros>? ReadById(int cabecera_id)
        {
            List<PlanillaRegistros> lst = new ();
            query = "SELECT * FROM stock_web.planilla_registros WHERE cabecera_id = " + cabecera_id;
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    PlanillaRegistros registro = new PlanillaRegistros();
                    registro.Id = reader.GetInt32(0);

                    var collection = JsonConvert.DeserializeObject(reader.GetString(1));

                    registro.Registros_Json = JsonConvert.DeserializeObject<List<string>>(collection.ToString());

                    registro.cabecera_id = reader.GetInt32(2);

                    lst.Add(registro);
                }

                return lst;
            }
            return null;
        }
    }   
}
