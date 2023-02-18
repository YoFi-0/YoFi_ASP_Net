using Microsoft.AspNetCore.Mvc;

namespace Yofi_ASP_Net.Controllers.Pasges
{
    public class Singale_R_ex : Controller
    {
        
        public IActionResult Index()
        {
            Request.HttpContext.Session.SetString("plusser", "0");
            Console.WriteLine(Request.HttpContext.Session.GetString("plusser"));
            return View();
        }
    }
}
