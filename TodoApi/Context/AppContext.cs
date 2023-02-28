using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Context;

public class AppDbContext : DbContext, IAppContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Todo> Todos {get; set;}
}
