using CleanArchitecture.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.TodoItems.EventHandlers;

public class AccountFrozenOrUnfrozenEventHandler : INotificationHandler<AccountFrozenOrUnfrozenEvent>
{
    private readonly ILogger<AccountFrozenOrUnfrozenEventHandler> _logger;

    public TodoItemCompletedEventHandler(ILogger<AccountFrozenOrUnfrozenEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AccountFrozenOrUnfrozenEvent notification, CancellationToken cancellationToken)
    {
        if (notification.Account.IsFrozen)
        {
            _logger.LogInformation("Account {AccountNumber} was frozen", notification.Account.AccountNumber);
        }
        else
        {
            _logger.LogInformation("Account {AccountNumber} was unfrozen", notification.Account.AccountNumber);
        }
        
        return Task.CompletedTask;
    }
}
