using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Commands
{
    public class AcceptFriendRequestCommand:IRequest<bool>
    {
        public AcceptFriendRequestCommand(string id, string userId)
        {
            this.id = id;
            UserId = userId;
        }

        public string id { get; set; }
        public string UserId { get; set; }
    }
}
