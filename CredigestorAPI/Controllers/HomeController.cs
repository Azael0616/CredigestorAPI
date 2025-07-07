using Microsoft.AspNetCore.Mvc;

namespace CredigestorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Prueba()
        {
            return Ok("Endpoint de prueba");
        }
    }
}
