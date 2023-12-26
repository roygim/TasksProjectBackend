using Org.BouncyCastle.Asn1.X509.SigI;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TasksProjectBackend.SimpleObjects;
using System.Reflection;
using System.Collections.Generic;

namespace TasksProjectBackend.Services
{
    public class LambdaService
    {
        private readonly ITaskRepository _taskRepository;

        public LambdaService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskObj>> GetData()
        {
            return await _taskRepository.GetAllTasks();
        }

        public async Task<List<TaskObj>> GetCompletedTasks()
        {
            return await _taskRepository.GetCompletedTasks();
        }

        public async Task<TaskObj> GetTask(int id)
        {
            return await _taskRepository.GetTask(id);
        }

        public async Task<List<string>> GetCompletedTasksName()
        {
            List<TaskObj> list = await this.GetCompletedTasks();            
            return list.Select(t => GetTaskObjNameMapper(t)).ToList();
        }

        private string GetTaskObjNameMapper(TaskObj t)
        {
            return "The taks name is: " + t.Text;
        }
    }
}
