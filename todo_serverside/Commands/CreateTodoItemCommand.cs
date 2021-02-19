using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.Models;

namespace todo_serverside.Commands
{
    public class CreateTodoItemCommand:IRequest<TodoItem>
    {
        public TodoItem TodoItem { get; set; }
        public CreateTodoItemCommand(TodoItem todoItem)
        {
            TodoItem = todoItem;
        }

        
    }
}
