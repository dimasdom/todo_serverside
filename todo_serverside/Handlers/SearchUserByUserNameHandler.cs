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
    public class SearchUserByUserNameHandler : IRequestHandler<SearchUserByUserNameCommand, UserDTOs>
    {
        public SearchUserByUserNameHandler(TodoListContext context)
        {
            _context = context;
        }

        public TodoListContext _context { get; set; }
        public Task<UserDTOs> Handle(SearchUserByUserNameCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(i => i.UserName == request.UserName);
           
                return Task.FromResult(new UserDTOs { UserName = user.UserName, Avatar = user.Avatar, Id = user.Id });
       
        }
    }
}
