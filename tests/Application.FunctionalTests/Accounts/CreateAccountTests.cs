using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Accounts.Commands.CreateAccount;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.FunctionalTests.Accounts.Commands;

using static Testing;

public class CreateAccountTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateAccountommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateAccount()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateAccountCommand
        {
            AccountNumber = "01234567899876543210",
            Username = "Test",
            Type = AccountType.Savings
        };

        var id = await SendAsync(command);

        var item = await FindAsync<Account(id);

        item.Should().NotBeNull();
        item.AccountNumber.Should().Be(command.AccountNumber);
        item.Username.Should().Be(command.Username);
        item.CreatedBy.Should().Be(userId);
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
