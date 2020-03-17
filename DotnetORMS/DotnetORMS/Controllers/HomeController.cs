using Microsoft.AspNetCore.Mvc;

namespace DotnetORMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("API Works!");
        }
    }
}