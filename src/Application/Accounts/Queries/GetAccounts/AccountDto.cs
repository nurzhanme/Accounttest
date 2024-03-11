using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Accounts.Queries.GetAccounts;

public class AccountDto
{
    public int Id { get; init; }

    public string AccountNumber { get; init; }

    public string Username { get; init; }

    public bool IsFrozen { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Account, AccountDto>();
        }
    }
}
