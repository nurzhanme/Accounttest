namespace CleanArchitecture.Domain.Entities;

public class Account : BaseAuditableEntity
{
    public int Id { get; set; }

    public string AccountNumber { get; set; }

    public string Username { get; set; }

    public AccountType Type { get; set; }

    private bool _isFrozen;
    public bool IsFrozen
    {
        get => _isFrozen;
        set
        {
            AddDomainEvent(new AccountFrozenOrUnfrozenEvent(this));
            
            _isFrozen = value;
        }
    }

}