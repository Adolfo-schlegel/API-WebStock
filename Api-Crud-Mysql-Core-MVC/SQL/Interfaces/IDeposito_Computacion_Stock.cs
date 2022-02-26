namespace Api_Crud_Mysql_Core_MVC.SQL.Interfaces
{
    public interface IDeposito_Computacion_Stock
    {
        int Id { get; set; }
        public List<object> Get_id();
        public void Post(Models.Deposito __deposito);
        public List<object> Get();
        public void Delete(int id);
        public void Put(Models.Deposito deposito);
    }
}
