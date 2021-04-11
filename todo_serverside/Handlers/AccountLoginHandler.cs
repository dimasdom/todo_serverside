using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.DTOs;
using todo_serverside.Models;
using todo_serverside.Services;
using todo_serverside.UserVerification;

namespace todo_serverside.Handlers
{
    public class AccountLoginHandler : IRequestHandler<AccountLoginCommand, UserDTOs>
    {
        public AccountLoginHandler(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService,UserVerificationClass userValitaionClass)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
           UserValitaionClass = userValitaionClass;
        }

        private UserManager<User>_userManager { get; set; }
        private SignInManager<User> _signInManager { get; set; }
        private TokenService _tokenService { get; set; }
       public UserVerificationClass UserValitaionClass { get; set; }

        public async Task<UserDTOs> Handle( AccountLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.UserLogin.Email);
            if (user == null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.UserLogin.Password, false);
            if (result.Succeeded)
            {
                UserValitaionClass.SetCurrentUserId(user.Id);
                List<UserDTOs> usersFriends = new List<UserDTOs>();
                foreach(string Id in JsonSerializer.Deserialize<string[]>(user.Friends))
                {
                    var userFound = await _userManager.FindByIdAsync(Id);
                    usersFriends.Add(new UserDTOs { UserName = userFound.UserName, Id = userFound.Id, Avatar = userFound.Avatar });
                }
                List<UserDTOs> usersFriendRequest = new List<UserDTOs>();
                foreach (string Id in JsonSerializer.Deserialize<string[]>(user.FriendsRequest))
                {
                    var userFound = await _userManager.FindByIdAsync(Id);
                    usersFriendRequest.Add(new UserDTOs { UserName = userFound.UserName, Id = userFound.Id, Avatar = userFound.Avatar });
                }
                return new UserDTOs
                {
                    UserName = user.UserName,
                    Id = UserValitaionClass.CurrentUserId,
                    Token = _tokenService.CreateToken(user),
                    UserFriendsRequests = usersFriendRequest,
                    UsersFriends = usersFriends,
                    Avatar = user.Avatar
                    
                    
                };
            }
            else
            {
                return Unauthorized();
            };
        }

        private UserDTOs Unauthorized()
        {
            throw new NotImplementedException();
        }
    }
}
