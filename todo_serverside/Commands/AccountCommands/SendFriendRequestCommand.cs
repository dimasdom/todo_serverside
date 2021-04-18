using MediatR;

namespace todo_serverside.Commands
{
    public class SendFriendRequestCommand : IRequest<bool>
    {
        public SendFriendRequestCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
