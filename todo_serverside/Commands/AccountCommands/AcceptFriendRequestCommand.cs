using MediatR;
using System;

namespace todo_serverside.Commands
{
    public class AcceptFriendRequestCommand : IRequest<bool>
    {
        public AcceptFriendRequestCommand(Guid id)
        {
            this.id = id;
        }

        public Guid id { get; set; }
    }
}
