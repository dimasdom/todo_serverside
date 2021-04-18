using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SendFriendRequestHandler(TodoListContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public TodoListContext _context { get; set; }
        public Task<bool> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(i => i.Id == request.Id);

            if (user != null)
            {
                var userFriendRequest = JsonSerializer.Deserialize<List<string>>(user.FriendsRequest);
                var userFriends = JsonSerializer.Deserialize<List<string>>(user.Friends);
                if (!userFriendRequest.Contains(currentUserId) && !userFriends.Contains(currentUserId))
                {
                    if (user.FriendsRequest == "[]")
                    {
                        string[] friendRequest = { currentUserId };
                        user.FriendsRequest = JsonSerializer.Serialize<string[]>(friendRequest);
                    }
                    else
                    {
                        var userNewFriendsRequest = JsonSerializer.Deserialize<string[]>(user.FriendsRequest).ToList<string>();
                        userNewFriendsRequest.Add(currentUserId);
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
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}