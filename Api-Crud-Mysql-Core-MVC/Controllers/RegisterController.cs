using Api_Crud_Mysql_Core_MVC.SQL;
using Microsoft.AspNetCore.Mvc;

namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        [Route("")]
        [Route("Register")]
        [Route("Register/Index")]
        public IActionResult Index()
        {
            return View();
        }

        public CtrlRegister CtrlRegister = new CtrlRegister();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(string Email, string password)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Models.Register reg)
        {
            Models.Register register = new Models.Register();
            register.Email = reg.Email;
            register.Password = reg.Password;

            int result = CtrlRegister.Create(register);

            if(result>0)
            {
                return Ok(200);
            }
            else
            {
                return BadRequest(400);
            }
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}
