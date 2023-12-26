using Microsoft.AspNetCore.Mvc;
using TasksProjectBackend.SimpleObjects;

namespace TasksProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LambdaController : ControllerBase
    {
        private readonly LambdaService _lambdaService;

        public LambdaController(LambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpGet("GetData")]
        public async Task<ActionResult<List<TaskObj>>> GetData()
        {
            List<TaskObj> tasks = await _lambdaService.GetData();
            return Ok(tasks);
        }

        [HttpGet("GetCompletedTasks")]
        public async Task<ActionResult<List<TaskObj>>> GetCompletedTasks()
        {
            List<TaskObj> tasks = await _lambdaService.GetCompletedTasks();
            return Ok(tasks);
        }

        [HttpGet("GetTask/{id}")]
        public async Task<ActionResult<TaskObj>> GetTask(int id)
        {
            TaskObj taskObj = await _lambdaService.GetTask(id);
            return Ok(taskObj);
        }

        [HttpGet("GetCompletedTasksName")]
        public async Task<ActionResult<List<string>>> GetCompletedTasksName()
        {
            List<string> tasks = await _lambdaService.GetCompletedTasksName();
            return Ok(tasks);
        }
    }
}
