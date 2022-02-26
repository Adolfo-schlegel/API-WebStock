using Api_Crud_Mysql_Core_MVC.SQL;
using Microsoft.AspNetCore.Mvc;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private IDeposito_Computacion_Stock _computacion_stock;
        public StockController(IDeposito_Computacion_Stock computacion_stock)
        {
            _computacion_stock = computacion_stock;
        }

        // GET api/stock/values
        [HttpGet]
        public ActionResult Get()
        {            
            var lst = _computacion_stock.Get().ToList();
            return Ok(lst);
        }

        // GET api/stock/5
        [HttpGet("{id}")]
        public ActionResult Get_id(int id)
        {
            _computacion_stock.Id = id;

            var result = _computacion_stock.Get_id().ToList();

            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Models.Deposito deposito)
        {
            _computacion_stock.Post(deposito);

            return Ok(true);
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] Models.Deposito deposito)
        {
            _computacion_stock.Put(deposito);

            return Ok(true);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _computacion_stock.Delete(id);

            return Ok(true);
        }
    }
}
