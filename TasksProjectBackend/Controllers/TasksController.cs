using Microsoft.AspNetCore.Mvc;

namespace TasksProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        [HttpGet("example")]
        public IActionResult Get()
        {
            return Ok("ok");
        }

        [HttpGet("example2")]
        public IActionResult Get2()
        {
            return Ok("ok2");
        }

        [HttpPost("post1")]
        public IActionResult post1()
        {
            return Ok("post1");
        }
    }
}
