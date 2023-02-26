using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Context;

public class AppContext : DbContext, IAppContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options) {}

    public DbSet<Todo> Todos {get;}
}
