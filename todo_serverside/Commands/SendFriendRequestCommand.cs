using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Commands
{
    public class SendFriendRequestCommand : IRequest<bool>
    {
        public SendFriendRequestCommand(string id, string userId)
        {
            Id = id;
            UserId = userId;
        }

        public string Id { get; set; }
        public string UserId{ get; set; }
    }
}
