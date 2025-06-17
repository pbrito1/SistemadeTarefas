using Microsoft.EntityFrameworkCore;

namespace SistemadeTarefas.Data
{
    public class TasksDBContext : DbContext
    {
        public TasksDBContext(DbContextOptions<TasksDBContext> options) : base(options)
        {
        }
        public DbSet<Models.UserModel> Users { get; set; }
        public DbSet<Models.TaskModel> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.TaskModel>().ToTable("Tasks");
            modelBuilder.Entity<Models.UserModel>().ToTable("Users");
        }
    }
}
