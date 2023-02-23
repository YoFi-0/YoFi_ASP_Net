using Microsoft.AspNetCore.Mvc;
using Yofi_ASP_Net.Global;
using Yofi_ASP_Net.Types;

namespace Yofi_ASP_Net.Controllers.API
{
    [ApiController]
    [Route("/Api/Jwt")]
    public class Jwt : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { 
                JWTApi = "is Running"
            });
        }
        [HttpPost]
        public IActionResult Index([FromBody] Testjwt user)
        {
            return Ok(new { 
                JwtToken = JwtAuthManager.Authenticate(user.Username, user.Password)
            });
        }
    }
}
