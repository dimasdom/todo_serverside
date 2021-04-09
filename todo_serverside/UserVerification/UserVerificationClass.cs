using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.UserVerification
{
    public class UserVerificationClass:IUserVerification
    {
        public UserVerificationClass()
        {
            CurrentUserId = "";
        }

        public string CurrentUserId { get ; set ; }
        public void SetCurrentUserId(string c)
        {
            this.CurrentUserId = c;
        }
    }
}
