using Microsoft.AspNetCore.Mvc;
using Y76.Entities;
using Y76.Repository;

namespace Y76.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemRepository _repository;

        public TodoItemsController(ITodoItemRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("/tasks")]
        public async Task<IActionResult> GetTodoItems()
        {
            var todoItems = await _repository.GetAllAsync();
            return Ok(todoItems);
        }

        [HttpPost("/task")]
        public async Task<ActionResult<Guid>> CreateTodoItem(TodoItemDto todoItemDto)
        {
           var item = await _repository.AddAsync(todoItemDto);
            return Created(nameof(GetTodoItems), item);
        }

        [HttpPut("task/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, TodoItemDto todoItemDto)
        {
            await _repository.UpdateAsync(id, todoItemDto);
            return Ok("Successfully updated");
        }

        [HttpDelete("task/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
            return Ok("Successfully deleted");
        }
    }
}
