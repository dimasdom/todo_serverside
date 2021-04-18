using System.Collections.Generic;

namespace todo_serverside.DTOs
{
    public class UserDTOs
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<UserDTOs> UsersFriends { get; set; }
        public string Avatar { get; set; }
        public string Token { get; set; }
        public List<UserDTOs> UserFriendsRequests { get; set; }

    }
}
