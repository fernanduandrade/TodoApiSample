using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Context;

public interface IAppContext
{
    DbSet<Todo> Todos {get; set;}
}
