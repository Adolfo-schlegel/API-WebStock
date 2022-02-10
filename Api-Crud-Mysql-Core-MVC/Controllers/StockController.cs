using Api_Crud_Mysql_Core_MVC.SQL;
using Microsoft.AspNetCore.Mvc;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        [Route("")]
        [Route("stock")]
        [Route("stock/Index")]
        public IActionResult Index()
        {
            return View();
        }

        // GET api/stock/values
        [HttpGet]
        public ActionResult Get()
        {
            CtrlDeposito ctrlDeposito = new CtrlDeposito();

            var lst = ctrlDeposito.Get().ToList();

            return Ok(lst);
        }

        // GET api/stock/5
        [HttpGet("{id}")]
        public ActionResult Get_id(int id)
        {
            CtrlDeposito ctrlDeposito = new CtrlDeposito();

            ctrlDeposito.Id = id;

            var result = ctrlDeposito.Get_id().ToList();

            return Ok(result);

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Models.Deposito deposito)
        {
            CtrlDeposito ctrlDeposito = new CtrlDeposito();

            ctrlDeposito.Post(deposito);

            return Ok(true);
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] Models.Deposito deposito)
        {
            CtrlDeposito ctrlDeposito = new CtrlDeposito();

            ctrlDeposito.Put(deposito);

            return Ok(true);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            CtrlDeposito ctrlDeposito = new CtrlDeposito();

            ctrlDeposito.Delete(id);

            return Ok(true);
        }
    }
}
