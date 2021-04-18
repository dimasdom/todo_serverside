using MediatR;
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
