using MediatR;
using todo_serverside.Models;

namespace todo_serverside.Commands
{
    public class TodoListAddTaskCommand : IRequest<TodoItem>
    {
        public TodoItem TodoItem { get; set; }
        public TodoListAddTaskCommand(TodoItem todoItem)
        {
            TodoItem = todoItem;
        }
    }
}
