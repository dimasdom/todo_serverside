using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
