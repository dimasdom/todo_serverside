using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace todo_serverside.Models
{

    public class TodoList
    {
        
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        
        public  Guid UserId { get; set; }
    }
}
