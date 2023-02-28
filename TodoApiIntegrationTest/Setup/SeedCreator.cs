using TodoApi.Context;
using TodoApi.Models;

namespace TodoApiIntegrationTest.Setup;

public class SeedCreator
{
    private readonly AppDbContext _context;

    public SeedCreator(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddTodo()
    {
        var todos = new List<Todo>
        {
            new Todo { Done = false, Title = "Fazer Compras" },
            new Todo { Done = false, Title = "Areia para caixinha dos gatos" },
            new Todo { Done = false, Title = "Lavar as roupas" },
            new Todo { Done = true, Title = "Ir ao shopping" },
        };

        await _context.Todos.AddRangeAsync(todos);
        await _context.SaveChangesAsync();
    }
}
