using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.DTOs;
using todo_serverside.Models;
using todo_serverside.Services;

namespace todo_serverside.Handlers
{
    public class AccountRegisterHandler : IRequestHandler<AccountRegisterCommand, UserDTOs>
    {
        public AccountRegisterHandler(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        private UserManager<User> _userManager { get; set; }
        private SignInManager<User> _signInManager { get; set; }
        private TokenService _tokenService { get; set; }
        public async Task<UserDTOs> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Register.Email))
            {
                return BadRequest("Email taken");
            }
            if (await _userManager.Users.AnyAsync(x => x.UserName == request.Register.UserName))
            {
                return BadRequest("Username taken");
            };
            var user = new User
            {
                Email = request.Register.Email,
                UserName = request.Register.UserName ,
                Avatar = "",
                TodoListsIds="[]",
                Friends="[]",
                FriendsRequest="[]"

            };
            var result = await _userManager.CreateAsync(user, request.Register.Password);
            if (result.Succeeded)
            {
                return new UserDTOs
                {
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }
            return BadRequest("Problem Registration");
        }

        private UserDTOs BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}
