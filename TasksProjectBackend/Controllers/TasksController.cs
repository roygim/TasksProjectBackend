using Microsoft.AspNetCore.Mvc;

namespace TasksProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAllTasks")]
        public async Task<ActionResult<List<TaskObj>>> GetAll()
        {
            List<TaskObj> tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost("AddTask")]
        public async Task<ActionResult<TaskObj>> AddTask(TaskObj taskObj)
        {
            TaskObj newTask = await _taskService.AddTask(taskObj);
            return Ok(newTask);
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<ActionResult<bool>> DeleteTask(int id)
        {
            bool isDeleted = await _taskService.DeleteTask(id);
            return Ok(isDeleted);
        }

        [HttpDelete("DeleteTasks")]
        public async Task<ActionResult<int>> DeleteTasks([FromBody] string ids)
        {
            int deletedTasks = await _taskService.DeleteTasks(ids);
            return Ok(deletedTasks);
        }
    }
}
