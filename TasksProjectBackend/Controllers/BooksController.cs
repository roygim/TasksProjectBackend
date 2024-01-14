using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TasksProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly BooksDataSql _booksDataSql;

        public BooksController(IConfiguration config, BooksDataSql booksDataSql)
        {
            _config = config;
            _booksDataSql = booksDataSql;
        }

        //[HttpGet("GetAll")]
        //public async Task<ActionResult<List<BooksObj>>> GetAll()
        //{
        //    var connection = new SqlConnection(_config.GetConnectionString("MSSQL"));
        //    var books = await connection.QueryAsync<BooksObj>("select * from books");
        //    return Ok(books);
        //}

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BooksObj>>> GetAll()
        {
            List<BooksObj> books = await _booksDataSql.GetAll();
            return Ok(books);
        }

        [HttpGet("GetAllSP")]
        public async Task<ActionResult<List<BooksObj>>> GetAllSP()
        {
            List<BooksObj> books = await _booksDataSql.GetAllSP();
            return Ok(books);
        }

        //[HttpPost("AddTask")]
        //public async Task<ActionResult<TaskObj>> AddTask(TaskObj taskObj)
        //{
        //    TaskObj newTask = await _taskService.AddTask(taskObj);
        //    return Ok(newTask);
        //}

        //[HttpDelete("DeleteTask/{id}")]
        //public async Task<ActionResult<bool>> DeleteTask(int id)
        //{
        //    bool isDeleted = await _taskService.DeleteTask(id);
        //    return Ok(isDeleted);
        //}

        //[HttpDelete("DeleteTasks")]
        //public async Task<ActionResult<int>> DeleteTasks([FromBody] string ids)
        //{
        //    int deletedTasks = await _taskService.DeleteTasks(ids);
        //    return Ok(deletedTasks);
        //}
    }
}
