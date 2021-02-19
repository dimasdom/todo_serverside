using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.Models;

namespace todo_serverside.Queries
{
    public class GetAllTodoItemsQuery : IRequest<List<TodoItem>>
    {
    }
}
