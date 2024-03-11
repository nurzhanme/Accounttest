using CleanArchitecture.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Accounts.EventHandlers;

public class AccountCreatedEventHandler : INotificationHandler<AccountCreatedEvent>
{
    private readonly ILogger<AccountCreatedEventHandler> _logger;

    public AccountCreatedEventHandler(ILogger<AccountCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AccountCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Account created: {AccountNumber}", notification.Account.AccountNumber);

        return Task.CompletedTask;
    }
}