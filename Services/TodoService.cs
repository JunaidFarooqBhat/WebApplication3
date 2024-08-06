using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllTodosAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(long id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> UpdateTodoAsync(long id, Todo todo)
        {
            var existingTodo = await _context.Todos.FindAsync(id);
            if (existingTodo == null)
            {
                return null;
            }

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.Completed = todo.Completed;

            await _context.SaveChangesAsync();
            return existingTodo;
        }

        public async Task<bool> DeleteTodoAsync(long id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return false;
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
