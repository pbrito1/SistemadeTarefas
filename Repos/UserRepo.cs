using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Data;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repos.Interfaces;
using System.Security.Cryptography;

namespace SistemadeTarefas.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly TasksDBContext _dbContext;
        public UserRepo(TasksDBContext tasksDBContext)
        {
            _dbContext = tasksDBContext;
        }
        public async Task<List<UserModel>> SearchAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> SearchUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserModel?> SearchUserByName(string name)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<UserModel?> SearchUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user;
        }
        public async Task<UserModel> UpdateUserAsync(UserModel user, int id)
        {
            UserModel userById = await SearchUserById(id);

            if (userById == null)
            {
                throw new Exception($"User {id} not found");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            UserModel userById = await SearchUserById(id);

            if (userById == null)
            {
                throw new Exception($"User {id} not found");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

