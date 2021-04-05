using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.DTOs;

namespace todo_serverside.Commands
{
    public class SearchUserByUserNameCommand:IRequest<UserDTOs>
    {
        public SearchUserByUserNameCommand(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
