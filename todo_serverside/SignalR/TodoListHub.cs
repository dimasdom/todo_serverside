using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Models;

namespace todo_serverside.SignalR
{
    public class TodoListHub : Hub
    {
        private IMediator _mediator;

        public TodoListHub(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task CreateTodoItem(TodoItem todoItem)
        {
            var command = new CreateTodoItemCommand(todoItem);
            var response = await _mediator.Send(command);
            await Clients.Group(response.TodoListId.ToString()).SendAsync("ReceiveTodoItem", response);
        }
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var TodoListId = httpContext.Request.Query["todoListId"];
            await Groups.AddToGroupAsync(Context.ConnectionId, TodoListId);
        }
    }
}
