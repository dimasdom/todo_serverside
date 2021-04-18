using FluentValidation;
using todo_serverside.Commands;

namespace todo_serverside.Validation
{
    public class AccountRegisterCommandValidation : AbstractValidator<AccountRegisterCommand>
    {
        public AccountRegisterCommandValidation()
        {
            RuleFor(x => x.Register.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Register.Password).NotEmpty();
            RuleFor(x => x.Register.UserName).NotEmpty();
        }
    }
}
