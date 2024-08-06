using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            return await _todoService.GetAllTodosAsync();
        }

        // GET: api/todo/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(long id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // POST: api/todo
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(Todo todo)
        {
            await _todoService.CreateTodoAsync(todo);
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
        }

        // PUT: api/todo/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(long id, Todo todo)
        {
            var updatedTodo = await _todoService.UpdateTodoAsync(id, todo);
            if (updatedTodo == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/todo/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(long id)
        {
            var result = await _todoService.DeleteTodoAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
