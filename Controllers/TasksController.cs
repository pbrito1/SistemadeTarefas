using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repos;
using SistemadeTarefas.Repos.Interfaces;

namespace SistemadeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepo _taskRepo;

        public TasksController(TaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Models.TaskModel>>> SearchAllTasksAsync()
        {
            List<TaskModel> tasks = await _taskRepo.SearchAllTasksAsync();
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.TaskModel>> SearchTaskByIdAsync(int id)
        {
            TaskModel task = await _taskRepo.SearchTaskByIdAsync(id);
            return Ok(task);
        }
        [HttpPost]
        public async Task<ActionResult<Models.TaskModel>> CreateTaskAsync([FromBody] TaskModel task)
        {
            TaskModel tasks = await _taskRepo.CreateTaskAsync(task);
            return Ok(task);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTaskAsync(int id)
        {
            bool result = await _taskRepo.DeleteTaskAsync(id);
            if (result)
            {
                return Ok($"Task {id} deleted");
            }
            return NotFound($"User with id {id} not found");
        }
    }
}
