using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Models;

namespace todo_serverside.Handlers
{
    public class TodoListAddTaskHandler : IRequestHandler<TodoListAddTaskCommand, TodoItem>
    {
        public Task<TodoItem> Handle(TodoListAddTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
