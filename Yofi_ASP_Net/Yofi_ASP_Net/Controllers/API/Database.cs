using Microsoft.AspNetCore.Mvc;
using Yofi_ASP_Net.DataBase;

namespace Yofi_ASP_Net.Controllers.API
{
    [ApiController]
    [Route("/Api/[Controller]")]
    public class Database : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (MainContext DB = new MainContext())
            {
                
            }
            return Ok();
        }
    }
}
