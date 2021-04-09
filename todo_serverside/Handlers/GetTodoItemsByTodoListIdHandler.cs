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
    public class GetTodoItemsByTodoListIdHandler : IRequestHandler<GetTodoItemsByTodoListIdQuery, List<TodoItem>>
    {
        public GetTodoItemsByTodoListIdHandler(TodoListContext context)
        {
            _context = context;
        }

        private TodoListContext _context { get; set; }
        public Task<List<TodoItem>> Handle(GetTodoItemsByTodoListIdQuery request, CancellationToken cancellationToken)
        {
            var response =   _context.TodoItems.Where( t =>  t.TodoListId == request.id).ToList();
           var responseas=  Task<List<TodoItem>>.FromResult(response);
            
          if(response == null)
            {
                return null;
            }
            else
            {
                return responseas;
            }
        }
    }
}
