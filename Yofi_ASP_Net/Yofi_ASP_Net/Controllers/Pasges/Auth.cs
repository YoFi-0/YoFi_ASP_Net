using Microsoft.AspNetCore.Mvc;

namespace Yofi_ASP_Net.Controllers.Pasges
{
    public class Auth : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
