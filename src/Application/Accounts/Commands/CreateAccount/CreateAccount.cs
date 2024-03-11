using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Application.Accounts.Commands.CreateAccount;

public record AccountCommand : IRequest<int>
{
    public string AccountNumber { get; init; }
    public string Username { get; init; }
    public AccountType Type { get; init; }
}

public class AccountCommandHandler : IRequestHandler<AccountCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AccountCommand request, CancellationToken cancellationToken)
    {
        var entity = new Account
        {
            AccountNumber = request.AccountNumber,
            Username = request.Username,
            Type = request.Type,
            IsFrozen = false
        };

        entity.AddDomainEvent(new AccountCreatedEvent(entity));

        _context.Accounts.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
