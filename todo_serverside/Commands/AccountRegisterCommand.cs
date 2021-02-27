using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.DTOs;

namespace todo_serverside.Commands
{
    public class AccountRegisterCommand : IRequest<UserDTOs>
    {
        public RegisterDTOs Register { get; set; }
        public AccountRegisterCommand(RegisterDTOs register)
        {
            Register = register;
        }

         
    }
}
