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
        CtrlStockUser StockUserSQL = new CtrlStockUser();

        [HttpPost]
        [Route("Stock")]
        public Reply GetStock([FromBody] User model)
        {
            Reply oR = new Reply();
            
            try
            {
                oR.message = "OK";
                oR.data = StockUserSQL.Get(model).ToList();
                oR.result = 1;

            }
            catch (Exception)
            {
                oR.result = 0;
                oR.message = "Error en el servidor";

                return oR;
            }

            return oR;
        }

        [HttpGet("{id}")]
        [Route("GetStockId")]
        public Reply Get_id(int id)
        {
            Reply oR = new Reply();

            try
            {

            }
            catch
            {
                oR.message = "Ocurrio un problema en el servidor, estamos reparandolo";
            }

            return oR;
        }

        [HttpPost]
        [Route("AddStock")]        
        public Reply Add([FromBody] StockUser stock)
        {
            Reply oR = new Reply();
            oR.result = 0;

            try
            {
                oR.message="OK";
                oR.result = StockUserSQL.Post(stock);

                if(oR.result != 1)
                {
                    oR.message = "mysql error";
                }
            }
            catch(Exception)
            {
                oR.message = "Ocurrio un problema en el servidor, estamos reparandolo";
            }        
            
            return oR;
        }

        [HttpPut]
        [Route("ModifyStock")]
        public Reply Put([FromBody] Models.StockUser stockUser)
        {
            Reply oR = new Reply();

            try
            {

            }
            catch
            {
                oR.message = "Ocurrio un problema en el servidor, estamos reparandolo";
            }

            return oR;
        }

        
        [HttpDelete("DeleteStock/{id}")]
        public Reply Delete(int id)
        {
            Reply oR = new Reply();

            try
            {
                oR.result = StockUserSQL.Delete(id);
                oR.message = "OK";

                if (oR.result != 1)
                {
                    oR.message = "mysql error";
                }
            }
            catch
            {
                oR.message = "Ocurrio un problema en el servidor, estamos reparandolo";
            }


            return oR;
        }
    }
}
