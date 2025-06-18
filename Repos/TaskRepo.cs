using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Data;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repos.Interfaces;

namespace SistemadeTarefas.Repos
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TasksDBContext _dbContext;
        public TaskRepo(TasksDBContext tasksDBContext)
        {
            _dbContext = tasksDBContext;
        }
        public async Task<TaskModel> CreateTaskAsync(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            TaskModel task = await SearchTaskByIdAsync(id);
            if (task == null)
            {
                throw new Exception($"Task {id} not found");
            }
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();

            return true; 
        }

        public async Task<List<TaskModel>> SearchAllTasksAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> SearchTaskByIdAsync(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public Task<List<TaskModel>> SearchTasksByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskModel> UpdateTaskAsync(TaskModel task, int id)
        {
            TaskModel taskModel = await SearchTaskByIdAsync(id);
            if (taskModel == null)
            {
                throw new Exception($"Task {id} not found");
            }
            taskModel.Title = task.Title;
            taskModel.Description = task.Description;
            taskModel.Status = task.Status;
            taskModel.IdUser = task.IdUser;
            _dbContext.Tasks.Update(taskModel);
            _dbContext.SaveChangesAsync();

            return await Task.FromResult(taskModel); // Return the updated task
        }
    }
}
