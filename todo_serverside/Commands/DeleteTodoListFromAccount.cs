using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Commands
{
    public class DeleteTodoListFromAccount:IRequest<bool>
    {
        public DeleteTodoListFromAccount(Guid userId, Guid todoListId)
        {
            UserId = userId;
            TodoListId = todoListId;
        }

        public Guid UserId { get; set; }
        public Guid TodoListId { get; set; }


    }
}
