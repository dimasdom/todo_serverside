using MediatR;
using Microsoft.AspNetCore.Http;

namespace todo_serverside.Commands
{
    public class AccountSetAvatarCommand : IRequest<string>
    {
        public IFormFile Avatar;

        public AccountSetAvatarCommand(IFormFile avatar)
        {
            Avatar = avatar;
        }
    }
}
