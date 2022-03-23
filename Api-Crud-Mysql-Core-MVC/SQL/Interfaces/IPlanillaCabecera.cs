using Api_Crud_Mysql_Core_MVC.Models;

namespace Api_Crud_Mysql_Core_MVC.SQL.Interfaces
{
    public interface IPlanillaCabecera
    {
        public int Create(PlanillaCabecera model);
        public List<string>? Read_NamesTables(int userId);
        public PlanillaCabecera Read_camp(int userId, string table_name);
        public string ReadNamePlanillaByid(int id);
    }
}
