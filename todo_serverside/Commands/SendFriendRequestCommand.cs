using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Commands
{
    public class SendFriendRequestCommand : IRequest<bool>
    {
        public SendFriendRequestCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
