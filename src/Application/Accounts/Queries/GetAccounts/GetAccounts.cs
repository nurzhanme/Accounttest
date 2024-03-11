using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Accounts.Queries.Accounts;

public record GetAccountsQuery : IRequest<AccountsVm>;

public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, AccountsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAccountsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AccountsVm> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        return new AccountsVm
        {
            AccountTypes = Enum.GetValues(typeof(AccountType))
                .Cast<AccountType>()
                .Select(p => new LookupDto { Id = (int)p, Title = p.ToString() })
                .ToList(),

            Lists = await _context.Accounts
                .AsNoTracking()
                .ProjectTo<AccountDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.AccountNumber)
                .ToListAsync(cancellationToken)
        };
    }
}