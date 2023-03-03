using Microsoft.AspNetCore.Mvc;
using TodoApi.Context;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<int>> GetAllTodo()
    {
       var result = await _context.Todos
        .AsNoTracking()
        .ToListAsync();

       return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateTodo(Todo todo)
    {
        try
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return Created("", todo.Id);
        }
        catch(Exception ex)
        {
            return Ok(ex);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<int>> GetTodoById(int id)
    {
       var result = await _context.Todos
        .AsNoTracking()
        .FirstOrDefaultAsync(todo => todo.Id == id);

       return Ok(result);
    }
}
