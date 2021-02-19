using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Context;
using todo_serverside.Models;
using todo_serverside.Queries;

namespace todo_serverside.Handlers
{
    public class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItem>
    {
        private TodoListContext _context { get; set; }
        public async Task<TodoItem> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.TodoItems.FindAsync(request.Id);
            return response ?? null;
        }
    }
}
