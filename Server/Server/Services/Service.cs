using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Services
{
    public class Service : IService

    {

        private TaskContext context;

        public Service(TaskContext context)
        {
            this.context = context;
        }

        public bool Add(TaskItem t)
        {
            if(t.Name.Count() == 0)
            {
                return false;
            }
            t.IsComplete = true;
            context.TaskItem.Add(t);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            TaskItem task = context.TaskItem.Where(t => t.Id == id).FirstOrDefault();
            if (task == null) return false;
            context.TaskItem.Remove(task);
            context.SaveChanges();
            return true;
        }

        public IList<TaskItem> GetAll()
        {
            return context.TaskItem.AsNoTracking().ToList();
        }

        public bool Update(TaskItem t)
        {
            TaskItem taskInDb = context.TaskItem.Where(t => t.Id == t.Id).FirstOrDefault();
            if(taskInDb == null) return false;
            taskInDb.IsComplete = t.IsComplete;
            taskInDb.Name = t.Name;
            context.SaveChanges();
            return true;
        }
    }
}
