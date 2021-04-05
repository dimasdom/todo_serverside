using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Models
{
    public class TodoItem
    {
            
            public Guid Id { get; set; }
            public string Description { get; set; }
            public bool Done { get; set; }

            public Guid TodoListId { get; set; }
            public string CreatedByUserId { get; set; }
        
    }
}
