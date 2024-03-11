using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Accounts.Commands.CreateTodoAccount;
using CleanArchitecture.Application.Accounts.Commands.FreezeOrUnfreezeAccount;
using CleanArchitecture.Application.Accounts.Queries.GetTodoItemsWithPagination;

namespace CleanArchitecture.Web.Endpoints;

public class Accounts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetTodoItemsWithPagination)
            .MapPost(CreateAccount)
            .MapPut(FreezeOrUnfreezeAccount, "{id}");
    }

    public Task<TodosVm> GetAccounts(ISender sender)
    {
        return  sender.Send(new GetAccountsQuery());
    }

    public Task<int> CreateAccount(ISender sender, CreateAccountCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> FreezeOrUnfreezeAccount(ISender sender, int id, FreezeOrUnfreezeAccountCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
}
