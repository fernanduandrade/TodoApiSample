using Microsoft.AspNetCore.Mvc;
using TodoApi.Context;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly IAppContext _context;

    public TodoController(IAppContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateTodo(Todo todo)
    {
       await _context.Todos.AddAsync(todo);
       return Created("", todo.Id);
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
