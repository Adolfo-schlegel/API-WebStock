using Microsoft.AspNetCore.Mvc;
using Api_Crud_Mysql_Core_MVC.SQL;
namespace Api_Crud_Mysql_Core_MVC.Controllers
{
    public class BaseController : Controller
    {
        CtrlBase ctrlBase = new CtrlBase();
        public bool Verify(string token)
        {
            bool result = ctrlBase.VerifyToken(token);  
            if(result == true)
                return true;    
            return false;
        }
    }
}
