namespace TasksProjectBackend.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskObj>> GetAllTasks();
        Task<TaskObj> GetTask(int id);
        Task<List<TaskObj>> GetCompletedTasks();
        Task<TaskObj> AddTask(TaskObj task);
        Task<bool> DeleteTask(int id);
        Task<int> DeleteTasks(string ids);
    }
}
