using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;

namespace todo_serverside.Handlers
{
    public class DeleteTodoListFromAccountHandler : IRequestHandler<DeleteTodoListFromAccount, bool>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public DeleteTodoListFromAccountHandler(TodoListContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public TodoListContext _context { get; set; }
        public Task<bool> Handle(DeleteTodoListFromAccount request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(i => i.Id == currentUserId);
            var todoList = _context.TodoLists.Find(request.TodoListId);
            if (user != null && todoList != null)
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
