﻿using Api_Crud_Mysql_Core_MVC.Models;
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

                if (oR.data == null)
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
        [Route("GetStockItem/{id}")]
        public Reply GetById(int id)
        {
            Reply oR = new();
            try
            {
                oR.data = _PlanillaRegistros.ReadById(id);
                if (oR.data == null)
                {
                    oR.message = "Error en el servidor";
                    return oR;
                }
                oR.message = "Ok";
                oR.result = 1;
                return oR;
            }
            catch (Exception ex)
            {
                oR.message = ex.Message;
                return oR;
            }
        }
        [HttpPost]
        [Route("PostStock")]
        public Reply Post([FromBody]PlanillaRegistros model)
        {
            Reply oR = new();           
            try
            {
                oR.result = _PlanillaRegistros.Create(model);
                if(oR.result != 1)
                {
                    oR.message = "Error en el servidor";
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
        [HttpPut]
        [Route("UpdateStock")]
        public Reply Put([FromBody] PlanillaRegistros model)
        {
            Reply oR = new();
            try
            {
                oR.data = _PlanillaRegistros.Update(model);
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

        [HttpDelete]
        [Route("DeleteStockById/{id}")]
        public Reply Delete(int id)
        {
            Reply oR = new();
            try
            {
                oR.result = _PlanillaRegistros.Delete(id);
                if (oR.result != 1)
                {
                    oR.message = "Error en el servidor";
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
