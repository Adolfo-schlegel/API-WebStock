using Microsoft.AspNetCore.Mvc;
using Api_Crud_Mysql_Core_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserStockController 
    {
        private IStockUser _stockUser;

        public UserStockController(IStockUser stockUser)
        {
            _stockUser = stockUser;
        }

        [HttpPost]
        [Route("Stock")]
        public Reply GetStock([FromBody] User model)
        {
            Reply oR = new Reply();
            
            try
            {
                oR.message = "OK";
                oR.data = _stockUser.Get(model).ToList();
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

        [HttpGet("GetStockById/{id}")]        
        public Reply Get_id(int id)
        {
            Reply oR = new Reply();

            try
            {
                oR.result = 1;
                oR.data = _stockUser.GetById(id);
                oR.message = "OK";
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
                oR.result = _stockUser.Post(stock);

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
        public Reply Put([FromBody] StockUser stockUser)
        {
            Reply oR = new Reply();

            try
            {
                oR.result = _stockUser.Put(stockUser);
                oR.message = "OK";
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
                oR.result = _stockUser.Delete(id);
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
