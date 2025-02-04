﻿using MediatR;
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
    public class AcceptFriendRequestHandler : IRequestHandler<AcceptFriendRequestCommand, bool>
    {
        public AcceptFriendRequestHandler(TodoListContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            HttpContextAccessor = httpContextAccessor;
        }

        public TodoListContext _context { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public Task<bool> Handle(AcceptFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userWhoAccept = _context.Users.FirstOrDefault(i => i.Id == currentUserId);
            var userWhoRequest = _context.Users.FirstOrDefault(i => i.Id == request.id.ToString());
            if (userWhoAccept != null && userWhoRequest != null)
            {

                var userFriendRequest = JsonSerializer.Deserialize<List<string>>(userWhoAccept.FriendsRequest);
                var userFriends = JsonSerializer.Deserialize<List<string>>(userWhoAccept.Friends);
                if (!userFriendRequest.Contains(currentUserId) && !userFriends.Contains(currentUserId))
                {
                    var userWhoAcceptNewFriendsRequest = JsonSerializer.Deserialize<string[]>(userWhoAccept.FriendsRequest).ToList<string>();
                    var userWhoAcceptNewFriends = JsonSerializer.Deserialize<string[]>(userWhoAccept.Friends).ToList<string>();
                    userWhoAcceptNewFriends.Add(request.id.ToString());
                    userWhoAccept.FriendsRequest = JsonSerializer.Serialize(userWhoAcceptNewFriendsRequest.Where(i => i != request.id.ToString()));
                    userWhoAccept.Friends = JsonSerializer.Serialize(userWhoAcceptNewFriends);

                    var userWhoRequestNewFriendsRequest = JsonSerializer.Deserialize<string[]>(userWhoRequest.FriendsRequest).ToList<string>();
                    var userWhoRequestNewFriends = JsonSerializer.Deserialize<string[]>(userWhoRequest.Friends).ToList<string>();
                    userWhoRequestNewFriends.Add(currentUserId);
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
            else
            {
                return Task.FromResult(false);
            }

        }
    }
}