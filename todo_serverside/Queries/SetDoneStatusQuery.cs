using MediatR;
using System;

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
