using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;

namespace todo_serverside.Handlers
{
    public class TodoListChangeCommonStatusHandler : IRequestHandler<TodoListChangeCommonStatus, bool>
    {
        public TodoListChangeCommonStatusHandler(TodoListContext context)
        {
            _context = context;
        }

        private TodoListContext _context { get; set; }
        public async Task<bool> Handle(TodoListChangeCommonStatus request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists.FindAsync(request.TodoListId);
            
            if (entity != null)
            {
                entity.Common = true;
                entity.UserIds = JsonSerializer.Serialize(request.UserIds);
                foreach(string e in request.UserIds)
                {
                    var user = _context.Users.FirstOrDefault(i => i.Id == e);
                    if (user != null)
                    {
                        var newEntity = JsonSerializer.Deserialize<string[]>(user.TodoListsIds).ToList<string>();
                        newEntity.Add(request.TodoListId.ToString());
                        user.TodoListsIds = JsonSerializer.Serialize<string[]>(newEntity.ToArray());
                    }
                }
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

            
            
        }
    }
}
