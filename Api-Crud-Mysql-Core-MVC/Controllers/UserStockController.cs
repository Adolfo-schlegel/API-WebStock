using Microsoft.AspNetCore.Mvc;
using Api_Crud_Mysql_Core_MVC.SQL;
using Api_Crud_Mysql_Core_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserStockController : BaseController
    {
        CtrlStockUser stockUser = new CtrlStockUser();

        [HttpPost]
        [Route("Stock")]
        public Reply Get([FromBody] User model)
        {
            Reply oR = new Reply();
            oR.result = 0;
            oR.message = "Error en el servidor";
            try
            {
                oR.message = "OK";
                oR.data = stockUser.Get(model).ToList();
                oR.result = 1;
            }
            catch (Exception ex)
            {
                return oR;
            }

            return oR;
        }

        [HttpGet("{id}")]
        public ActionResult Get_id(int id)
        {
            return null;
        }

        [HttpPost]
        [Route("AddStock")]
        public Reply Add([FromBody] Models.StockUser stock)
        {
            Reply oR = new Reply();
            oR.result = 0;

            try
            {
                oR.result = stockUser.Post(stock);
            }
            catch(Exception ex)
            {
                oR.message = "Ocurrio un problema en el servidor, estamos reparandolo";
            }        
            
            return oR;
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.StockUser stockUser)
        {




            return Ok(true);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {



            return Ok(true);
        }
    }
}
