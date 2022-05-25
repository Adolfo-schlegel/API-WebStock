using Api_Crud_Mysql_Core_MVC.Models;

namespace Api_Crud_Mysql_Core_MVC.SQL.Interfaces
{
    public interface IPlanillaRegistros
    {
        public List<PlanillaRegistros>? Read(int cabecera_id);
        public List<string>? ReadById(int id);
        public int Create(PlanillaRegistros registros);
        public int Delete(int id);
        public int Update(PlanillaRegistros model);
    }
}
