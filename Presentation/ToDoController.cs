using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo2.Application;
using Todo2.Domain;

namespace Todo2.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ToDoService _toDoService;

        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _toDoService.GetAllTasks();
            return Ok(tasks);
        }
        [HttpGet("GetTask")]

        public async Task<IActionResult> GetTask(int TaskNum)
        {
            var task = await _toDoService.GetTask(TaskNum);
            return Ok(task);
        }

        [HttpPost("AddTask")]

        public async Task<IActionResult> AddTask(toDo toDoItem)
        {
 
            var addedTask = await _toDoService.AddTaskAsync(toDoItem);
            return CreatedAtAction(nameof(GetAllTasks), new { taskName = addedTask.taskName }, addedTask);
        }
        [HttpPut("UpdateTask")]

        public async Task<IActionResult> UpdateTask(toDo Task)
        {
           var tsk = await _toDoService.UpdateTask(Task);
            if (tsk == null)
            {
                return NotFound();
            }
            return Ok(tsk);
        }
        [HttpDelete("RemoveTask")]
        public async Task<IActionResult> RemoveTask(int TaskNum)
        {
            var removed = await _toDoService.RemoveTask(TaskNum);
            if (!removed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
