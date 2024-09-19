using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public interface ITodolistRepo
    {
        Task<IEnumerable<ItemTodo>> GetAllTodoItemAsync();
        Task<ItemTodo> GetTodoItemByIdAsync(int id);
        Task AddTodoitemAsync(ItemTodo todo);
        Task UpdateTodoitemAsync(ItemTodo todo);
        Task DeleteTodoitemAsync(int id);
    }

    public class ItemTodo
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
