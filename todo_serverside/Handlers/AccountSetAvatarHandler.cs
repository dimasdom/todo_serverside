using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;
using todo_serverside.DTOs;

namespace todo_serverside.Handlers
{
    public class AccountSetAvatarHandler : IRequestHandler<AccountSetAvatarCommand, string>
    {
        public AccountSetAvatarHandler(TodoListContext context)
        {
            _context = context;
        }

        private TodoListContext _context { get; set; }

        public async  Task<string> Handle(AccountSetAvatarCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);
               user.Avatar = request.Avatar;
            await _context.SaveChangesAsync();
            return user.Avatar;
        }
    }
}
