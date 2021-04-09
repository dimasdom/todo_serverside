using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Commands
{
    public class DeleteTodoListFromAccount:IRequest<bool>
    {
        public DeleteTodoListFromAccount( Guid todoListId)
        {
            TodoListId = todoListId;
        }

        public Guid TodoListId { get; set; }


    }
}
