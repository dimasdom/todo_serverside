using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.DTOs
{
    public class UserDTOs
    {
        public string Id{ get; set; }
        public string UserName{ get; set; }
        public string[] UsersFriends { get; set; }
        public string Avatar { get; set; }
        public string Token { get; set; }
        public string[] UserFriendsRequests { get; set; }

    }
}
