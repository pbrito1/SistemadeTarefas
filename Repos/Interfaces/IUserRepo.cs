using SistemadeTarefas.Models;

namespace SistemadeTarefas.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task<List<UserModel>> SearchAllUsersAsync();
        Task<UserModel> SearchUserById(int id);
        Task<UserModel?> SearchUserByName(string name);
        Task<UserModel?> SearchUserByEmailAsync(string email);
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user, int id);
        Task<bool> DeleteUserAsync(int id);
    }
}
