using FluentValidation;
using todo_serverside.Commands;

namespace todo_serverside.Validation
{
    public class AccountLoginCommandValidation : AbstractValidator<AccountLoginCommand>
    {
        public AccountLoginCommandValidation()
        {
            RuleFor(x => x.UserLogin.Email).NotEmpty();
            RuleFor(x => x.UserLogin.Password).NotEmpty();
        }
    }
}
