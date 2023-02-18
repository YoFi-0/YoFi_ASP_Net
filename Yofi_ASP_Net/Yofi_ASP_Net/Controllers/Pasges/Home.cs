using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Yofi_ASP_Net.Global;
using Yofi_ASP_Net.Middlewares;

namespace Yofi_ASP_Net.Controllers.Pasges
{
    public class Home : Controller
    {
        private readonly ILogger<Home> _logger;

        public Home(ILogger<Home> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [IsLogin]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Sleep()
        {
            AllFunctions.Sleep(3);
            return View();
        }
    }
}