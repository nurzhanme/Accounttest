using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Accounts.Commands.FreezeOrUnfreezeAccount;

public record FreezeOrUnfreezeAccountCommand : IRequest
{
    public int Id { get; init; }

    public bool IsFrozen { get; init; }
}

public class FreezeOrUnfreezeAccountCommandHandler : IRequestHandler<FreezeOrUnfreezeAccountCommand>
{
    private readonly IApplicationDbContext _context;

    public FreezeOrUnfreezeAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(FreezeOrUnfreezeAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Accounts
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.IsFrozen = request.IsFrozen;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
