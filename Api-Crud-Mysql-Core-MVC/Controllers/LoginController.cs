using Microsoft.AspNetCore.Mvc;
using Api_Crud_Mysql_Core_MVC.Models;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;
using System.Web;
using Microsoft.AspNetCore.Authorization;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private ILogin _login;

        public LoginController (ILogin login)
        {
            _login = login;
        }        
        
        [HttpGet]
        [Route("GetUsers")]
        [Authorize]
        public Reply GetAll()
        {
            Reply oR = new Reply();

            oR.message = "OK";
            oR.data = "lista";
            oR.result = 1;

            return oR;
        }

        [HttpPost]
        [Route("Auth")]
        [AllowAnonymous]
        public Reply Login([FromBody] Login model)
        {

            Reply oR = new Reply();

            oR = _login.Validate_User(model);

            return oR;

        }        
    }
}
