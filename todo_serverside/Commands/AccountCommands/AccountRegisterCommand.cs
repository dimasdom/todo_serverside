using MediatR;
using todo_serverside.DTOs;

namespace todo_serverside.Commands
{
    public class AccountRegisterCommand : IRequest<UserDTOs>
    {
        public RegisterDTOs Register { get; set; }
        public AccountRegisterCommand(RegisterDTOs register)
        {
            Register = register;
        }


    }
}
