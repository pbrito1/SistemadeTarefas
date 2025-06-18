using SistemadeTarefas.Models;

namespace SistemadeTarefas.Repos.Interfaces
{
    public interface ITaskRepo
    {
        Task<List<TaskModel>> SearchAllTasksAsync();
        Task<TaskModel> SearchTaskByIdAsync(int id);
        Task<TaskModel> CreateTaskAsync(TaskModel task);
        Task<bool> DeleteTaskAsync(int id);
        Task<List<TaskModel>> SearchTasksByUserIdAsync(int userId);
        Task<TaskModel> UpdateTaskAsync(TaskModel task, int id);
    }
}
