using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_serverside.Commands;

namespace todo_serverside.Validation
{
    public class CreateTodoListCommandValidation : AbstractValidator<CreateTodoListCommand>
    {
        public CreateTodoListCommandValidation()
        {
            RuleFor(x => x.TodoList.Id).NotEmpty();
            RuleFor(x => x.TodoList.Tittle).NotEmpty();
            RuleFor(x => x.TodoList.UserId).NotEmpty();
        }
    }
    
}
