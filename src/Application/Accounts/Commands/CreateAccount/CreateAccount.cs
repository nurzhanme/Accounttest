using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Accounts.Commands.CreateAccount;

public record CreateAccountCommand : IRequest<int>
{
    public string AccountNumber { get; init; }
    public string Username { get; init; }
    public AccountType Type { get; init; }
}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
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
