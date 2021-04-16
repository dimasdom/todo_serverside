using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;
using todo_serverside.Models;

namespace todo_serverside.Handlers
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, TodoItem>
    {
        private TodoListContext _context { get; set; }
        public CreateTodoItemHandler(TodoListContext context)
        {
            _context = context;
        }

        
        public  Task<TodoItem> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            _context.TodoItems.Add(request.TodoItem);
            _context.SaveChanges();
            return Task.FromResult(request.TodoItem);
        }
    }
}
