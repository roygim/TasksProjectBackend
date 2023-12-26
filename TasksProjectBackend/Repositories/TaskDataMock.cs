using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TasksProjectBackend.Repositories
{
    public class TaskDataMock: ITaskRepository
    {
        private List<TaskObj> _tasks = new List<TaskObj>
        {
            new TaskObj { Id = 1, Text = "Test1", IsComplete = false },
            new TaskObj { Id = 2, Text = "Test2", IsComplete = true },
            new TaskObj { Id = 3, Text = "Test3", IsComplete = false },
            new TaskObj { Id = 4, Text = "Test4", IsComplete = false },
            new TaskObj { Id = 5, Text = "Test5", IsComplete = true },
            new TaskObj { Id = 6, Text = "Test6", IsComplete = false },
        };

        public async Task<List<TaskObj>> GetAllTasks()
        {
            return _tasks;
        }

        public async Task<TaskObj> GetTask(int id)
        {
           return _tasks.SingleOrDefault(t => t.Id == id);
        }

        public async Task<List<TaskObj>> GetCompletedTasks()
        {
            return _tasks.Where(t => t.IsComplete).ToList();
        }

        public async Task<TaskObj> AddTask(TaskObj task)
        {
            _tasks.Add(task);
            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = _tasks.SingleOrDefault(t => t.Id == id);
            if(task != null)
            {
                return _tasks.Remove(task);
            }
            return false;
        }

        public async Task<int> DeleteTasks(string ids)
        {
            string [] idsArray = ids.Split(',');
            int num = _tasks.RemoveAll(t => idsArray.Contains(t.Id.ToString()));
            return num;
        }
    }
}
