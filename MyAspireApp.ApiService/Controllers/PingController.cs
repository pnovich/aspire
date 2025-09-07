using Microsoft.AspNetCore.Mvc;

namespace MyAspireApp.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("pong");
        }
        
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok(new { status = "OK", timestamp = DateTime.UtcNow });
        }
    }
}