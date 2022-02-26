using Api_Crud_Mysql_Core_MVC.Models;

namespace Api_Crud_Mysql_Core_MVC.SQL.Interfaces
{
    public interface IStockUser
    {
        public List<object> Get(User model);
        public int Post(StockUser stock);
        public int Delete(int id_stock);
        public List<StockUser> GetById(int id_stock);
        public int Put(StockUser model);
    }
}
