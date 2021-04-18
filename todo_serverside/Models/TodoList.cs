using System;

namespace todo_serverside.Models
{

    public class TodoList
    {

        public Guid Id { get; set; }
        public string Tittle { get; set; }

        public Guid OwnerId { get; set; }
        public bool Common { get; set; }
        public string UserIds { get; set; }
    }
}
