using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public interface ITodolistRepo
    {
        Task<IEnumerable<TodoItem>> GetAllTodoItemAsync();
        Task<TodoItem> GetTodoItemByIdAsync(int id);
        Task AddTodoitemAsync(TodoItem todo);
        Task UpdateTodoitemAsync(TodoItem todo);
        Task DeleteTodoitemAsync(int id);
    }

    public class TodoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt
        { get; set; }

        public DateTime UpdatedAt
        {
            get; set;
        }
    }
}
