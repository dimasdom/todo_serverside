using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Context;
using todo_serverside.Queries;

namespace todo_serverside.Handlers
{
    public class SetDoneStatusHandler : IRequestHandler<SetDoneStatusQuery,bool>
    {
        private TodoListContext _context;

        public SetDoneStatusHandler(TodoListContext context)
        {
            _context = context;
        }

        public  Task<bool>  Handle(SetDoneStatusQuery request, CancellationToken cancellationToken)
        {
            var entity =  _context.TodoItems.FirstOrDefault(item => item.Id == request.Id);
            if (entity != null)
            {
                entity.Done = false;
                _context.SaveChanges();
            }
            return Task<bool>.FromResult(entity.Done);
        }
    }
}
