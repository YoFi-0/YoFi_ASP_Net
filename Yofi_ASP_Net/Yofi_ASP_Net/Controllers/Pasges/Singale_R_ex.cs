using Microsoft.AspNetCore.Mvc;

namespace Yofi_ASP_Net.Controllers.Pasges
{
    public class Singale_R_ex : Controller
    {
        
        public IActionResult Index()
        {
            Request.HttpContext.Session.SetString("plusser", "0");
            return View();
        }
        public IActionResult No_Sleeep()
        {
            Request.HttpContext.Session.SetString("plusser", "0");
            return View();
        }
    }
}
