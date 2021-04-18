using MediatR;
using System;
using todo_serverside.Models;

namespace todo_serverside.Queries
{
    public class GetTodoItemByIdQuery : IRequest<TodoItem>
    {
        public GetTodoItemByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
