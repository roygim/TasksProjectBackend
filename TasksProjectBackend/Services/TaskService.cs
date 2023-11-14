using System.Threading.Tasks;

namespace TasksProjectBackend.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskDataMock _taskDataMock;

        public TaskService(TaskDataMock taskDataMock)
        {
            _taskDataMock = taskDataMock;
        }

        public async Task<List<TaskObj>> GetAllTasks()
        {
            return await _taskDataMock.GetAllTasks();
        }

        public async Task<TaskObj> AddTask(TaskObj task)
        {
            return await _taskDataMock.AddTask(task);
        }

        public async Task<bool> DeleteTask(int id)
        {
            return await _taskDataMock.DeleteTask(id);
        }

        public async Task<int> DeleteTasks(string ids)
        {
            return await _taskDataMock.DeleteTasks(ids);
        }

        
    }
}
