using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, List<TodoItem>>
    {
        public GetAllTodoItemsHandler(TodoListContext context)
        {
            _context = context;
        }

        private TodoListContext _context { get; set; }
        public async Task<List<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoItems.ToListAsync();
        }
    }
}
