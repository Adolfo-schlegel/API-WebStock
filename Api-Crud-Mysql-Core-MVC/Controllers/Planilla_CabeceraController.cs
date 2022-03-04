using Api_Crud_Mysql_Core_MVC.Models;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Planilla_CabeceraController : Controller
    {
        private IPlanillaCabecera _planillaCabecera;

        public Planilla_CabeceraController(IPlanillaCabecera planillaCabecera)
        {
            _planillaCabecera = planillaCabecera;
        }

        [HttpGet]
        [Route("GetCabecera/{id}")]
        public Reply Get_by_userid(int id)
        {
            Reply oR = new Reply();
            try
            {
                oR.data = _planillaCabecera.Read(id);
                return oR;
            }
            catch
            {
                oR.result = 0;
                oR.message = "Hubo un error en el servidor, lo estamos corrigiendo";
                return oR;
            }
        }

        [HttpPost]
        [Route("CreatePlanilla")]
        public Reply CreatePlanilla([FromBody] PlanillaCabecera model)
        {
            Reply oR = new Reply();

            try
            {
                oR.result = _planillaCabecera.Create(model);

                if(oR.result != 1)
                {
                    oR.message = "datos erroneos";
                    return oR;
                }

                oR.message = "OK";
                return oR;
            }
            catch (Exception ex)
            {
                oR.message = ex.Message;
                return oR;
            }            
        }
    }
}
