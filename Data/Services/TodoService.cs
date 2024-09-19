using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync()
        {
            var response = await _httpClient.GetAsync("api/todo");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<TodoItem>>();
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/todo/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TodoItem>();
        }
    }

}
