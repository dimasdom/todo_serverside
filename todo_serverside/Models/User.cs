using Microsoft.AspNetCore.Identity;

namespace todo_serverside.Models
{
    public class User : IdentityUser
    {
        public string Avatar { get; set; }
        public string Friends { get; set; }
        public string FriendsRequest { get; set; }
        public string TodoListsIds { get; set; }
    }
}
