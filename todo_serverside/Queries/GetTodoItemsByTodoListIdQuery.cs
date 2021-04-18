using MediatR;
using System;
using System.Collections.Generic;
using todo_serverside.Models;

namespace todo_serverside.Queries
{
    public class GetTodoItemsByTodoListIdQuery : IRequest<List<TodoItem>>
    {
        public Guid id { get; set; }

        public GetTodoItemsByTodoListIdQuery(Guid Id)
        {
            id = Id;
        }
    }
}
