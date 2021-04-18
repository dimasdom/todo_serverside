using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Context;
using todo_serverside.Models;

namespace todo_serverside.Commands
{
    public class CreateTodoListHandler : IRequestHandler<CreateTodoListCommand, TodoList>
    {
        public CreateTodoListHandler(TodoListContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            HttpContextAccessor = httpContextAccessor;
        }

        private TodoListContext _context { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public async Task<TodoList> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {


            var currentUserId = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(i => i.Id == currentUserId);
            if (user != null)
            {
                var userTodoListIds = JsonSerializer.Deserialize<string[]>(user.TodoListsIds).ToList<string>();
                userTodoListIds.Add(request.TodoList.Id.ToString());
                user.TodoListsIds = JsonSerializer.Serialize(userTodoListIds.ToArray());
                request.TodoList.OwnerId = Guid.Parse(HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                _context.TodoLists.Add(request.TodoList);
                _context.SaveChanges();
                return request.TodoList;
            }
            else
            {
                return null;
            }

        }
    }
}
