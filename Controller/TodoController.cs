using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodolistRepo _repo;

    public TodoController(ITodolistRepo repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetAllTodoItems()
    {
        var items = await _repo.GetAllTodoItemAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetTodoItemById(int id)
    {
        var item = await _repo.GetTodoItemByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> AddTodoItem(TodoItem todo)
    {
        await _repo.AddTodoitemAsync(todo);
        return CreatedAtAction(nameof(GetTodoItemById), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTodoItem(int id, TodoItem todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }

        await _repo.UpdateTodoitemAsync(todo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTodoItem(int id)
    {
        await _repo.DeleteTodoitemAsync(id);
        return NoContent();
    }
}
