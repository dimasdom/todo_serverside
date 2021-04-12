using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_serverside.Commands;
using todo_serverside.Context;
using todo_serverside.Models;
using todo_serverside.Queries;
using todo_serverside.Request;

namespace todo_serverside.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly TodoListContext _context;
        private readonly IMediator _mediator;

        public TodoListsController(TodoListContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
            
        }

        // GET: api/TodoLists
        [EnableCors]
        [HttpGet]
        [Authorize(AuthenticationSchemes =
    JwtBearerDefaults.AuthenticationScheme)]

        // GET: api/TodoLists
        [HttpGet]
        public async Task<ActionResult<List<TodoList>>> GetTodoList()
        {
            var query = new GetTodoListsByUserId();
            var response = await _mediator.Send(query);
            return response;
        }

        // POST: api/TodoLists
        [HttpPost()]
        public async Task<ActionResult<TodoList>> PostTodoList( TodoList todoList)
        {
            var command = new CreateTodoListCommand(todoList);
            var handler = await _mediator.Send(command);
            return CreatedAtAction("GetTodoList", new { id = handler.Id }, todoList);
        }
        [HttpPost("changeCommonStatus/{id}")]
        public async Task<IActionResult> ChangeCommonStatus(Guid id , UserIdsRequest UserIds)
        {
            var command = new TodoListChangeCommonStatus(id,UserIds.UserIds) ;
            var handler = await _mediator.Send(command);
            
            return handler ? Ok():NotFound();
        }
        // DELETE: api/TodoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList( Guid id)
        {
            var command = new DeleteTodoListFromAccount( id);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            else
            {
               return  NotFound();
            }
        }

        private bool TodoListExists(Guid id)
        {
            return _context.TodoLists.Any(e => e.Id == id);
        }
    }
}
