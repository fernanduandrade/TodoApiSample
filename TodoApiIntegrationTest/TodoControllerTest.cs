using TodoApi.Context;
using TodoApiIntegrationTest.Setup;
using System.Net;
using TodoApi.Models;

namespace TodoApiIntegrationTest;

public class TodoControllerTest : ClientFixture
{
    public TodoControllerTest(WebApiFactoryConfig<Program, AppDbContext> factory) : base(factory) {}


    [Fact]
    public async Task Create_New_Todo_Return_200OK()
    {
        Todo @todo = new()
        {
            Done= false,
            Title = "Novo todo",
        };

        
        var response = await AsPostAsync("api/Todo/create", todo);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
