using Microsoft.AspNetCore.Mvc;
using Yofi_ASP_Net.Types;

namespace Yofi_ASP_Net.Controllers.API
{
    [ApiController]
    [Route("/Api/Users")]
    public class Users : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return Ok(new {
                  res = EnumApiRes.Ok,
                  status = Response.StatusCode,
                  data = "this is a user route"

            });
        }
    }
}
