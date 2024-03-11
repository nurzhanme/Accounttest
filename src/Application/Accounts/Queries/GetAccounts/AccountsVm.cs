using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Application.Accounts.Queries.GetAccounts;

public class AccountsVm
{
    public IReadOnlyCollection<LookupDto> AccountTypes { get; init; } = Array.Empty<LookupDto>();

    public IReadOnlyCollection<AccountDto> Lists { get; init; } = Array.Empty<AccountDto>();
}