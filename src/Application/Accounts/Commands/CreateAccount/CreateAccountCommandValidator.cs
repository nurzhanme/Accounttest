namespace CleanArchitecture.Application.Accounts.Commands.CreateAccount;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(v => v.AccountNumber)
            .MaximumLength(20)
            .MinimumLength(20)
            .NotEmpty();

        RuleFor(v => v.Username)
            .MaximumLength(50)
            .MinimumLength(2)
            .NotEmpty();
    }
}
