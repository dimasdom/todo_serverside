using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Commands
{
    public class TodoListChangeCommonStatus:IRequest<bool>
    {
        public TodoListChangeCommonStatus(Guid todoListId, string[] userIds)
        {
            TodoListId = todoListId;
            UserIds = userIds;
        }

        public Guid TodoListId { get; set; }
        public string[] UserIds { get; set; }

    }
}
