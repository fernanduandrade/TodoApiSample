using TodoApi.Context;
using TodoApiIntegrationTest.Setup;
using System.Net;
using System.Text.Json;
using TodoApi.Models;

namespace TodoApiIntegrationTest;

public class TodoControllerTest : ClientFixture
{
    public TodoControllerTest(WebApiFactoryConfig<Program, AppDbContext> factory) : base(factory) {}


    [Fact]
    public async Task Create_New_Todo_Return_200OK()
    {
        // Arrange
        Todo @todo = new()
        {
            Done= false,
            Title = "Novo todo",
        };

        // Act
        var response = await AsPostAsync("api/Todo/", todo);
        var resultId = Int32.Parse(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.True(resultId > 0);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Get_Todo_Return_200OK()
    {
        // Arrange
        await SeedWork.AddTodo();
        
        // Act
        var response = await AsGetAsync("api/Todo/");
        var result = await response.Content.ReadAsStringAsync();
        
        // Assert
        List<Todo>? todos =  JsonSerializer.Deserialize<List<Todo>>(result);
        var assertresult = todos?.Count == 5;

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.True(assertresult);
    }
}
