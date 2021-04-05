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

namespace todo_serverside.Handlers
{
    public class AccountLoginHandler : IRequestHandler<AccountLoginCommand, UserDTOs>
    {
        public AccountLoginHandler(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        private UserManager<User>_userManager { get; set; }
        private SignInManager<User> _signInManager { get; set; }
        private TokenService _tokenService { get; set; }
        public async Task<UserDTOs> Handle( AccountLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.UserLogin.Email);
            if (user == null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.UserLogin.Password, false);
            if (result.Succeeded)
            {
                return new UserDTOs
                {
                    UserName = user.UserName,
                    Id = user.Id,
                    Token = _tokenService.CreateToken(user),
                    UserFriendsRequests = JsonSerializer.Deserialize<string[]>(user.FriendsRequest),
                    UsersFriends = JsonSerializer.Deserialize<string[]>(user.Friends),
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
