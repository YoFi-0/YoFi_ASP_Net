using Microsoft.AspNetCore.Mvc;
using Yofi_ASP_Net.Models;

namespace Yofi_ASP_Net.Controllers.Pasges
{
    [Route("/Auth/[Controller]")]
    public class Register : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("../Auth/Register");
        }

        [HttpPost]
        public IActionResult Index([FromForm] UserModle user)
        {
            return View("../Auth/Register");
        }
    }
}
