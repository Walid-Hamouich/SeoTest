using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class TaskContext : DbContext
    {

        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
        public DbSet<TaskItem> TaskItem { get; set; }


        public DbSet<User> User { get; set; }

    }



}
