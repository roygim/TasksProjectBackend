using System.Threading.Tasks;

namespace TasksProjectBackend.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskObj>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();
        }

        public async Task<TaskObj> AddTask(TaskObj task)
        {
            return await _taskRepository.AddTask(task);
        }

        public async Task<bool> DeleteTask(int id)
        {
            return await _taskRepository.DeleteTask(id);
        }

        public async Task<int> DeleteTasks(string ids)
        {
            return await _taskRepository.DeleteTasks(ids);
        }

        
    }
}
