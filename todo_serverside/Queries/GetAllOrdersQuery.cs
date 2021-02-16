using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using todo_serverside.Models;

namespace todo_serverside.Queries
{
    public class GetAllOrdersQuery : IRequest<List<TodoList>>
    {
    }
}
