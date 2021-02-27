using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.DTOs;

namespace todo_serverside.Commands
{
    public class AccountLoginCommand : IRequest<UserDTOs>
    {
        public AccountLoginCommand(LoginDTOs user)
        {
            UserLogin = user;
        }

        public LoginDTOs UserLogin { get; set; }
    }
}
