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
        [Route("GetNames/{id}")]
        public Reply Get_Names(int id)
        {
            Reply oR = new Reply();
            try
            {
                oR.data = _planillaCabecera.Read_NamesTables(id);
                oR.result = 1;
                oR.message = "OK";
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

                if (oR.result != 1)
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
        [HttpGet]
        [Route("GetColumnsByNameTable/{id}/{table_name}")]
        public Reply GetColumns(int id, string table_name)
        {
            Reply oR = new Reply();
            try
            {
                oR.data = _planillaCabecera.Read_camp(id, table_name);

                if(oR.data == null)
                {
                    oR.result = 0;
                    oR.message = "Error en el servidor";
                    return oR;
                }
                oR.result = 1;
                oR.message = "OK";
                return oR;
            }
            catch(Exception ex)
            {
                oR.message = ex.ToString();
                return oR;
            }            
        }
    }
}
