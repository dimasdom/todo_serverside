using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Models;

namespace todo_serverside.Handlers
{
    public class AccountSignOutHandler : IRequestHandler<AccountSignOutCommand, bool>
    {
        public AccountSignOutHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        private SignInManager<User> _signInManager { get; set; }
        


        public async Task<bool> Handle(AccountSignOutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _signInManager.SignOutAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
