using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.DTOs;

namespace todo_serverside.Commands
{
    public class AccountSetAvatarCommand : IRequest<string>
    {
        public IFormFile Avatar;
        public Guid UserId;

        public AccountSetAvatarCommand(IFormFile avatar,Guid id)
        {
            Avatar = avatar;
            UserId = id;
        }
    }
}
