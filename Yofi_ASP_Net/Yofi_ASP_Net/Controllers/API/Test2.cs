using Microsoft.AspNetCore.Mvc;
using Yofi_ASP_Net.Models;
using Yofi_ASP_Net.Types;

namespace Yofi_ASP_Net.Controllers.API
{
    [ApiController]
    [Route("/Api")]
    public class Test2 : Controller
    {
        [HttpPost("TestApi_1")]
        public IActionResult TestApi_1([FromBody] UserModle user)
        {
            return Ok(user);
        }
    }
}
