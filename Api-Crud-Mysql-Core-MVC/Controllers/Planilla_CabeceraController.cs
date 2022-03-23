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
        [Route("GetNames/{user_id}")]
        public Reply Get_Names(int user_id)
        {
            Reply oR = new Reply();
            try
            {
                oR.data = _planillaCabecera.Read_NamesTables(user_id);
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
        [Route("GetColumnsByNameTable/{user_id}/{table_name}")]
        public Reply GetColumns(int user_id, string table_name)
        {
            Reply oR = new Reply();
            try
            {
                oR.data = _planillaCabecera.Read_camp(user_id, table_name);

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
        [HttpGet]
        [Route("GetNamePlanillaByid/{id}")]
        public Reply ReadName(int id)
        {
            Reply oR = new Reply();

            try
            {
                oR.data = _planillaCabecera.ReadNamePlanillaByid(id);
                
                if(oR.data == null)
                {
                    oR.result = 0;
                    oR.message = "Error en el servidor";
                    return oR;
                }
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
