namespace CleanArchitecture.Domain.Events;

public class AccountCreatedEvent : BaseEvent
{
    public AccountCreatedEvent(Account account)
    {
        Account = account;
    }

    public Account Account { get; }
}
