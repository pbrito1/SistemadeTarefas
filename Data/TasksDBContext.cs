using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Data.Map;
using SistemadeTarefas.Models;

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
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskModel>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.IdUser);
        }
    }
}
