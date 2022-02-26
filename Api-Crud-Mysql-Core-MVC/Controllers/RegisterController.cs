using Api_Crud_Mysql_Core_MVC.SQL;
using Microsoft.AspNetCore.Mvc;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private IRegister _register;
        public RegisterController(IRegister register)
        {
            _register = register;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Register reg)
        {
            Models.Register register = new Models.Register();
            register.Email = reg.Email;
            register.Password = reg.Password;

            int result = _register.Create(register);

            if(result>0)
            {
                return Ok(200);
            }
            else
            {
                return BadRequest(400);
            }
            
        }
    }
}
