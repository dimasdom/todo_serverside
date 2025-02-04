﻿using FluentValidation;
using todo_serverside.Commands;

namespace todo_serverside.Validation
{
    public class CreateTodoItemCommandValidation : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidation()
        {
            RuleFor(x => x.TodoItem.Id).NotEmpty();
            RuleFor(x => x.TodoItem.TodoListId).NotEmpty();
            RuleFor(x => x.TodoItem.Description).NotEmpty();
            RuleFor(x => x.TodoItem.Done).NotEmpty();
        }
    }
}
