using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Context;
using todo_serverside.Models;

namespace todo_serverside.Commands
{
    public class CreateTodoListHandler : IRequestHandler<CreateTodoListCommand, TodoList>
    {
        public CreateTodoListHandler(TodoListContext context)
        {
            _context = context;
        }

        private TodoListContext _context { get; set; }
        public async Task<TodoList> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            _context.TodoLists.Add(request.TodoList);
            await _context.SaveChangesAsync();

            return  request.TodoList;
        }
    }
}
