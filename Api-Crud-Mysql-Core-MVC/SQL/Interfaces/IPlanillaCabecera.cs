using Api_Crud_Mysql_Core_MVC.Models;

namespace Api_Crud_Mysql_Core_MVC.SQL.Interfaces
{
    public interface IPlanillaCabecera
    {
        public int Create(Models.PlanillaCabecera model);

        public List<PlanillaCabecera>? Read(int userId);
    }
}
