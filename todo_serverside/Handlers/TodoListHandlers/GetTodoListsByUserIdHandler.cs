using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Context;
using todo_serverside.Models;
using todo_serverside.Queries;

namespace todo_serverside.Handlers
{
    public class GetTodoListsByUserIdHandler : IRequestHandler<GetTodoListsByUserId, List<TodoList>>
    {
        public GetTodoListsByUserIdHandler(TodoListContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private TodoListContext _context { get; set; }
        private IHttpContextAccessor _httpContextAccessor { get; set; }

        public Task<List<TodoList>> Handle(GetTodoListsByUserId request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var response = new List<TodoList>();
            var user = _context.Users.FirstOrDefault(i => i.Id == currentUserId);
            var userTodoListIds = JsonSerializer.Deserialize<Guid[]>(user.TodoListsIds);
            foreach (Guid id in userTodoListIds)
            {
                response.Add(_context.TodoLists.FirstOrDefault(i => i.Id == id));
            }
            return Task.FromResult(response);
        }
    }
}
