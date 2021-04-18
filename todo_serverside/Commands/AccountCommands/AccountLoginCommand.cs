using MediatR;
using todo_serverside.DTOs;

namespace todo_serverside.Commands
{
    public class AccountLoginCommand : IRequest<UserDTOs>
    {
        public AccountLoginCommand(LoginDTOs user)
        {
            UserLogin = user;
        }

        public LoginDTOs UserLogin { get; set; }
    }
}
