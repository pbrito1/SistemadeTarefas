using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repos.Interfaces;

namespace SistemadeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> SearchAllUsers()
        {
            List<UserModel> users = await _userRepo.SearchAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> SearchUserById(int id)
        {
            UserModel users = await _userRepo.SearchUserById(id);
            return Ok(users);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<UserModel>>> SearchUserByNameAsync(string name)
        {
            UserModel users = await _userRepo.SearchUserByNameAsync(name);
            return Ok(users);
        }
        [HttpGet("{email}")]
        public async Task<ActionResult<List<UserModel>>> SearchUserByEmailAsync(string email)
        {
            UserModel users = await _userRepo.SearchUserByEmailAsync(email);
            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUserAsync([FromBody] UserModel user)
        {
            UserModel users = await _userRepo.CreateUserAsync(user);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUserAsync(int id)
        {
            bool result = await _userRepo.DeleteUserAsync(id);
            if (result)
            {
                return Ok($"User {id} deleted");
            }
            return NotFound($"User with id {id} not found");
        }
    }
}
