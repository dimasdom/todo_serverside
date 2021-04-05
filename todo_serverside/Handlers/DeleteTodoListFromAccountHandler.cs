using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;

namespace todo_serverside.Handlers
{
    public class DeleteTodoListFromAccountHandler : IRequestHandler<DeleteTodoListFromAccount, bool>
    {
        public DeleteTodoListFromAccountHandler(TodoListContext context)
        {
            _context = context;
        }

        public TodoListContext _context { get; set; }
        public Task<bool> Handle(DeleteTodoListFromAccount request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == request.UserId.ToString());
            var todoList = _context.TodoLists.Find(request.TodoListId);
            if (user != null&&todoList!=null)
            {
                var userTodoIds = JsonSerializer.Deserialize<Guid[]>(user.TodoListsIds);
                user.TodoListsIds = JsonSerializer.Serialize<Guid[]>(userTodoIds.Where(i => i != request.TodoListId).ToArray());
                _context.TodoLists.Remove(todoList);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
