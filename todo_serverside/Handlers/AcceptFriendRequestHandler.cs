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
    public class AcceptFriendRequestHandler : IRequestHandler<AcceptFriendRequestCommand, bool>
    {
        public AcceptFriendRequestHandler(TodoListContext context)
        {
            _context = context;
        }

        public TodoListContext _context {get;set;}
        public Task<bool> Handle(AcceptFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var userWhoAccept = _context.Users.FirstOrDefault(i => i.Id == request.UserId);
            var userWhoRequest = _context.Users.FirstOrDefault(i => i.Id == request.id.ToString());
            if(userWhoAccept!=null&& userWhoRequest != null)
            {
                var userWhoAcceptNewFriendsRequest = JsonSerializer.Deserialize<string[]>(userWhoAccept.FriendsRequest).ToList<string>();
                var userWhoAcceptNewFriends = JsonSerializer.Deserialize<string[]>(userWhoAccept.Friends).ToList<string>();
                userWhoAcceptNewFriends.Add(request.id.ToString());
                userWhoAccept.FriendsRequest = JsonSerializer.Serialize(userWhoAcceptNewFriendsRequest.Where(i => i != request.id.ToString()));
                userWhoAccept.Friends = JsonSerializer.Serialize(userWhoAcceptNewFriends);

                var userWhoRequestNewFriendsRequest = JsonSerializer.Deserialize<string[]>(userWhoRequest.FriendsRequest).ToList<string>();
                var userWhoRequestNewFriends = JsonSerializer.Deserialize<string[]>(userWhoRequest.Friends).ToList<string>();
                userWhoRequestNewFriends.Add(request.UserId);
                //userWhoRequest.FriendsRequest = JsonSerializer.Serialize(userWhoRequestNewFriendsRequest.Where(i => i != request.id));
                userWhoRequest.Friends = JsonSerializer.Serialize(userWhoRequestNewFriends);

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
