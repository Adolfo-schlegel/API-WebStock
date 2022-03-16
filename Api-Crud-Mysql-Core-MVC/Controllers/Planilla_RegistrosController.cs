using Api_Crud_Mysql_Core_MVC.Models;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Planilla_RegistrosController : Controller
    {
        IPlanillaRegistros _PlanillaRegistros;
        
        public Planilla_RegistrosController(IPlanillaRegistros planillaRegistros)
        {
            _PlanillaRegistros = planillaRegistros;
        }

        [HttpGet]
        [Route("GetStock/{cabecera_id}")]
        public Reply Get(int cabecera_id)
        {
            Reply oR = new();
            try
            {
                oR.data = _PlanillaRegistros.Read(cabecera_id);

                if(oR.data == null)
                {
                    oR.message = "Datos Erroneos";
                }
                oR.message = "OK";
                oR.result = 1;                
                return oR;
            }
            catch (Exception ex)
            {
                oR.message = ex.Message;
                return oR;
            }
        }
        [HttpGet]
        [Route("GetStockById/{id}")]
        public Reply GetById(int id)
        {
            Reply oR = new();
            try
            {
                oR.data = _PlanillaRegistros.ReadById(id);
                if(oR.data == null)
                {
                    oR.message = "Error en el servidor";
                    return oR;
                }
                oR.message = "Ok";
                oR.result = 1;
                return oR;
            }
            catch(Exception ex)
            {
                oR.message = ex.Message;
                return oR;
            }
        }
        public Reply Post()
        {
            Reply oR = new();           
            try
            {
                // oR.data = _PlanillaRegistros.Create
                if(oR.data == null)
                {
                    oR.message = "Error en el servidor";
                    return oR;
                }
                oR.message = "OK";
                oR.result=1;
                return oR;
            }
            catch (Exception ex)
            {
                oR.message = ex.Message;
                return oR;
            }
        }

        public Reply Put()
        {
            Reply oR = new();
            try
            {
                // oR.data = _PlanillaRegistros.Update
                if (oR.data == null)
                {
                    oR.message = "Error en el servidor";
                    return oR;
                }
                oR.message = "OK";
                oR.result = 1;
                return oR;
            }
            catch (Exception ex)
            {
                oR.message = ex.Message;
                return oR;
            }
        }

        public Reply Delete()
        {
            Reply oR = new();
            try
            {
                // oR.data = _PlanillaRegistros.Delete
                if (oR.data == null)
                {
                    oR.message = "Error en el servidor";
                    return oR;
                }
                oR.message = "OK";
                oR.result = 1;
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
