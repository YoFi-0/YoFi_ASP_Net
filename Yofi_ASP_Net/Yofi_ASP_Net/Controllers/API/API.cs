using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Yofi_ASP_Net.Controllers.Pasges;
using Yofi_ASP_Net.Types;

namespace Yofi_ASP_Net.Controllers.API
{
    [ApiController]
    [Route("/Api")]
    public class Test : Controller
    {
        private readonly ILogger<Home> _logger;

        [HttpGet]
        public IActionResult Index()
        {

            return Ok(new
            {
                res = EnumApiRes.Ok,
                data = "this is a data"
            });
        }

        [HttpGet("TestApi_1")]
        public IActionResult TestApi_1()
        {
            User user = new User() {
                UserName = "YoFi"
            };

            APIBaseRes api = new APIBaseRes() {
                Res = EnumApiRes.Ok,
                SatatusCode = Response.StatusCode,
                Data = user
            };

            return Ok(api);
        }
 
    }
}
