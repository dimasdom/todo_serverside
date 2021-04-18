using FluentValidation;
using todo_serverside.Commands;

namespace todo_serverside.Validation
{
    public class CreateTodoListCommandValidation : AbstractValidator<CreateTodoListCommand>
    {
        public CreateTodoListCommandValidation()
        {
            RuleFor(x => x.TodoList.Id).NotEmpty();
            RuleFor(x => x.TodoList.Tittle).NotEmpty();
            RuleFor(x => x.TodoList.OwnerId).NotEmpty();
        }
    }

}
