using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Queries
{
    public class SetDoneStatusQuery : IRequest<bool>
    {
        public Guid Id { get; set; }
        public SetDoneStatusQuery(Guid id)
        {
            Id = id;
        }
    }
}
