using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repo
{
    public class TodolistRepo : ITodolistRepo
    {
        private readonly TodoContext _context;

        public TodolistRepo(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItemAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task AddTodoitemAsync(TodoItem todo)
        {
            await _context.TodoItems.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoitemAsync(TodoItem todo)
        {
            _context.TodoItems.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoitemAsync(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }

}
