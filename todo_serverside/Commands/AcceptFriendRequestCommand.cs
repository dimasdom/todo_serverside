using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Commands
{
    public class AcceptFriendRequestCommand:IRequest<bool>
    {
        public AcceptFriendRequestCommand(Guid id)
        {
            this.id = id;
        }

        public Guid id { get; set; }
    }
}
