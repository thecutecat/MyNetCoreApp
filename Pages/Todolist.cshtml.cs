using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;

namespace WebApplication1.Pages
{
    public class TodoModel : PageModel
    {
        private readonly ILogger<TodoModel> _logger;
        private readonly TodoService _todoService;
        public IEnumerable<TodoItem> TodoItems { get; set; }

        //Task<TodoItem> get = await OnGetAsync();

        public TodoModel(TodoService todoService, ILogger<TodoModel> logger)
        {
            _logger = logger;
            _todoService = todoService;
            
            
        }

        public async Task OnGetAsync()
        {
            TodoItems = await _todoService.GetAllTodoItemsAsync();
        }
    }

}
