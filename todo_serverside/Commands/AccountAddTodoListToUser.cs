using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Commands
{
    public class AccountAddTodoListToUser:IRequest<bool>
    {
        public AccountAddTodoListToUser(Guid userId, Guid todoListId)
        {
            UserId = userId;
            TodoListId = todoListId;
        }

        public Guid UserId { get; set; }
        public Guid TodoListId { get; set; }
    }
}
