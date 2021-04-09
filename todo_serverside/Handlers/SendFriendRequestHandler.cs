using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.Context;

namespace todo_serverside.Handlers
{
    public class SendFriendRequestHandler : IRequestHandler<SendFriendRequestCommand, bool>
    {

        public SendFriendRequestHandler(TodoListContext context)
        {
            _context = context;
        }

        public TodoListContext _context { get; set; }
        public Task<bool> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == request.Id);
            if (user != null)
            {
                if (user.FriendsRequest == "[]")
                {
                    string[] friendRequest = { request.Id };
                    user.FriendsRequest = JsonSerializer.Serialize<string[]>(friendRequest);
                }
                else
                {
                    var userNewFriendsRequest = JsonSerializer.Deserialize<string[]>(user.FriendsRequest).ToList<string>();
                    userNewFriendsRequest.Add(request.Id);
                    user.FriendsRequest = JsonSerializer.Serialize(userNewFriendsRequest);
                }
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
