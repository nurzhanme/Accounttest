namespace CleanArchitecture.Domain.Events;

public class AccountFrozenOrUnfrozenEvent : BaseEvent
{
    public AccountFrozenOrUnfrozenEvent(Account account)
    {
        Account = account;
    }

    public Account Account { get; }
}
