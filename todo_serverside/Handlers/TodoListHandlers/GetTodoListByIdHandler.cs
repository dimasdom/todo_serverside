using MediatR;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Context;
using todo_serverside.Models;
using todo_serverside.Queries;

namespace todo_serverside.Handlers
{
    public class GetTodoListByIdHandler : IRequestHandler<GetTodoListByIdQuery, TodoList>
    {
        private TodoListContext _context;

        public GetTodoListByIdHandler(TodoListContext context)
        {
            _context = context;
        }

        public async Task<TodoList> Handle(GetTodoListByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.TodoLists.FindAsync(request.Id);
            return result ?? null;
        }
    }
}
