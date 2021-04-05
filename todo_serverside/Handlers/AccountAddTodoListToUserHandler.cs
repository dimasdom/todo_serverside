using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;
using todo_serverside.Models;

namespace todo_serverside.Handlers
{
    public class AccountAddTodoListToUserHandler : IRequestHandler<AccountAddTodoListToUser, bool>
    {
        private TodoListContext _context;

        public AccountAddTodoListToUserHandler(TodoListContext context)
        {
            _context = context;
        }
        public Task<bool> Handle(AccountAddTodoListToUser request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(i=>i.Id==request.UserId.ToString());
            if(user != null)
            {
                var userTodoListIds = JsonSerializer.Deserialize<string[]>(user.TodoListsIds).ToList<string>();
                userTodoListIds.Add(request.TodoListId.ToString());
                user.TodoListsIds = JsonSerializer.Serialize(userTodoListIds.ToArray());
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
