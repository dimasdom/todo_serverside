using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.Commands;
using todo_serverside.DTOs;
using todo_serverside.Models;
using todo_serverside.Request;
using todo_serverside.Services;

namespace todo_serverside.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

     
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTOs>> Login(LoginDTOs login)
        {
            var command = new AccountLoginCommand(login);
            var response = await _mediator.Send(command);
            return response;


            
        }
        [HttpPost("register")]

        public async Task<ActionResult<UserDTOs>> Register(RegisterDTOs register)
        {
            var command = new AccountRegisterCommand(register);
            var response = await _mediator.Send(command);
            return response;
        }
        [HttpPost("setAvatar")]
        public async Task<ActionResult<string>> SetAvatar( IFormFile avatar)
        {
            var command = new AccountSetAvatarCommand(avatar) ;
            var response = await _mediator.Send(command);
            return response;
        }
        [HttpPost("sentFriendRequest/{id}")]
        public async Task<IActionResult> SendFriendRequest(string id)
        {
            var command = new SendFriendRequestCommand(id);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }else
            {
                return NotFound();
            }
        }
        [HttpPost("acceptFriendRequest/{id}")]
        public async Task<IActionResult> AcceptFriendRequest(Guid id)
        {
            var command = new AcceptFriendRequestCommand(id);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("searchUser")]
        public async Task<ActionResult<UserDTOs>> SearchUserByUserName(UserNameRequest UserName)
        {
            var command = new SearchUserByUserNameCommand(UserName.UserName);
            var response = await _mediator.Send(command);
            if (response.UserName!="")
            {
                return response;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
