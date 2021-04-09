using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.UserVerification
{
    public interface IUserVerification
    {
        public string CurrentUserId { get; set; }
    }
}
