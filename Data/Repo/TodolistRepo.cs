using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repo
{
    public class TodolistRepo : ITodolistRepo
    {
        private readonly ApplicationDbContext _context;

        public TodolistRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemTodo>> GetAllTodoItemAsync()
        {
            try
            {
                return await _context.TodoItem.ToListAsync();
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
                return Enumerable.Empty<ItemTodo>();
            }
        }

        public async Task<ItemTodo> GetTodoItemByIdAsync(int id)
        {
            return await _context.TodoItem.FindAsync(id);
        }

        public async Task AddTodoitemAsync(ItemTodo todo)
        {
            await _context.TodoItem.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoitemAsync(ItemTodo todo)
        {
            _context.TodoItem.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoitemAsync(int id)
        {
            var todo = await _context.TodoItem.FindAsync(id);
            if (todo != null)
            {
                _context.TodoItem.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }

}
