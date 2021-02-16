using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.Models;

namespace todo_serverside.Queries
{
    public class GetTodoListByIdQuery : IRequest<TodoList>
    {
        public Guid Id { get; set; }
        public GetTodoListByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
