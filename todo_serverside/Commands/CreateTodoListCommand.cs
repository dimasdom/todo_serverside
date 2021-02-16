using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.Models;

namespace todo_serverside.Commands
{
    public class CreateTodoListCommand : IRequest<TodoList>
    {
        public TodoList TodoList { get; set; }
        public CreateTodoListCommand(TodoList todolist)
        {
            TodoList = todolist;
        }
    }
}
