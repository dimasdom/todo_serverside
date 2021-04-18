using MediatR;
using System;

namespace todo_serverside.Commands
{
    public class DeleteTodoListFromAccount : IRequest<bool>
    {
        public DeleteTodoListFromAccount(Guid todoListId)
        {
            TodoListId = todoListId;
        }

        public Guid TodoListId { get; set; }


    }
}
