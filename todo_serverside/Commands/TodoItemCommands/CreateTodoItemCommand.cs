using MediatR;
using todo_serverside.Models;

namespace todo_serverside.Commands
{
    public class CreateTodoItemCommand : IRequest<TodoItem>
    {
        public TodoItem TodoItem { get; set; }
        public CreateTodoItemCommand(TodoItem todoItem)
        {
            TodoItem = todoItem;
        }


    }
}
