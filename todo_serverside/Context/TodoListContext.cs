using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using todo_serverside.Models;

namespace todo_serverside.Context
{
    public class TodoListContext : IdentityDbContext<User>
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {

        }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
