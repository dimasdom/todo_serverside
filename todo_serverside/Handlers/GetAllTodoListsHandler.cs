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
    public class GetAllTodoListsHandler : IRequestHandler<GetAllOrdersQuery, List<TodoList>>
    {

        private readonly TodoListContext _context;
        public GetAllTodoListsHandler(TodoListContext context)
        {
            _context = context;
        }

        public async Task<List<TodoList>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoLists.ToListAsync();
        }
    }
}
