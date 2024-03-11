using CleanArchitecture.Application.Accounts.Commands.CreateAccount;
using CleanArchitecture.Application.Accounts.Commands.FreezeOrUnfreezeAccount;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.FunctionalTests.Accounts.Commands;

using static Testing;

public class FreezeOrUnfreezeAccountTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new FreezeOrUnfreezeAccountCommand { Id = 99, IsFrozen = true };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateTodoItem()
    {
        var userId = await RunAsDefaultUserAsync();

        var createCommand = new CreateAccountCommand
        {
            AccountNumber = "01234567899876543210",
            Username = "Test"
            Type = AccountType.Savings
        };

        var id = await SendAsync(createCommand);

        var command = new FreezeOrUnfreezeAccountCommand
        {
            Id = id,
            IsFrozen = true
        };

        await SendAsync(command);

        var item = await FindAsync<Account>(id);

        item.Should().NotBeNull();
        item.IsFrozen.Should().Be(command.IsFrozen);
        item.LastModifiedBy.Should().NotBeNull();
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
