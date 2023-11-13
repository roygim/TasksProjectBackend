namespace TasksProjectBackend.Interfaces
{
    public interface ITaskService
    {
        List<TaskObj> GetAllTasks();
        TaskObj AddTask(TaskObj task);
        void DeleteTask(int id);
        void DeleteTasks(string ids);
    }
}
