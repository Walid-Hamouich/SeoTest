using Server.Models;

namespace Server.Services
{
    public interface IService
    {
        public bool Add(TaskItem t);

        public bool Update(TaskItem t);

        public bool Delete(int id);

        public IList<TaskItem> GetAll();

    }
}
