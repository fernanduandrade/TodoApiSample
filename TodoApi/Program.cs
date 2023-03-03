using Microsoft.EntityFrameworkCore;
using TodoApi.Context;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connection).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        

builder.Services.AddScoped<IAppContext>(provider => provider.GetRequiredService<AppDbContext>());
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


public partial class Program { }