using MediatR;
using System.Collections.Generic;
using todo_serverside.Models;

namespace todo_serverside.Queries
{
    public class GetAllTodoItemsQuery : IRequest<List<TodoItem>>
    {
    }
}
