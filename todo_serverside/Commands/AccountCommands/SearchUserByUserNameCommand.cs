using MediatR;
using todo_serverside.DTOs;

namespace todo_serverside.Commands
{
    public class SearchUserByUserNameCommand : IRequest<UserDTOs>
    {
        public SearchUserByUserNameCommand(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
