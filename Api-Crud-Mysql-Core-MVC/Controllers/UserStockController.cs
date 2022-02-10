using Microsoft.AspNetCore.Mvc;
using Api_Crud_Mysql_Core_MVC.SQL;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserStockController : Controller
    {
        CtrlStockUser stockUser = new CtrlStockUser();

        [Route("")]
        [Route("UserStock")]
        [Route("UserStock/Index")]
        public IActionResult Index()
        {
            return View();
        }

        // GET api/stock/values
        [HttpGet("list/{id}")]
        public ActionResult Get(int id)
        {            
            var lst = stockUser.Get(id).ToList();

            return Ok(lst);
        }

        // GET api/stock/5
        [HttpGet("{id}")]
        public ActionResult Get_id(int id)
        {





            return null;
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody] Models.StockUser stock)
        {
            bool result = stockUser.Post(stock);

            return result;
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] Models.StockUser stockUser)
        {




            return Ok(true);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {



            return Ok(true);
        }
    }
}
