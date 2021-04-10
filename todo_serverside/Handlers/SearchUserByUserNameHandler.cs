using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;
using todo_serverside.DTOs;

namespace todo_serverside.Handlers
{
    public class SearchUserByUserNameHandler : IRequestHandler<SearchUserByUserNameCommand, UserDTOs>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SearchUserByUserNameHandler(TodoListContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public TodoListContext _context { get; set; }
        public Task<UserDTOs> Handle(SearchUserByUserNameCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(i => i.UserName == request.UserName);
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (user!=null)
            {
                if (user.Id != currentUserId)
                {
                    return Task.FromResult(new UserDTOs { UserName = user.UserName, Avatar = user.Avatar, Id = user.Id });
                }
                else
                {
                    return Task.FromResult(new UserDTOs { UserName = "" });
                }
            }
            else
            {
                return Task.FromResult(new UserDTOs { UserName = "" });
            }
            
       
        }
    }
}
