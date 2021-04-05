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
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoLists()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/TodoLists/5
        [HttpGet("getByUserId/{id}")]
        public async Task<ActionResult<List<TodoList>>> GetTodoListByUserId(string id)
        {
            var query = new GetTodoListsByUserId(id);
            var response = await _mediator.Send(query);
            return response;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> GetTodoList(Guid id)
        {
            var query = new GetTodoListByIdQuery(id);
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : (ActionResult<TodoList>)Ok(result);
        }

        // PUT: api/TodoLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(Guid id, TodoList todoList)
        {
            if (id != todoList.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("createPersonalTodoList/{id}")]
        public async Task<ActionResult<TodoList>> PostTodoList( Guid id, TodoList todoList)
        {
            var command = new CreateTodoListCommand(todoList);
            var commandAccount = new AccountAddTodoListToUser(id, todoList.Id);
            var handler = await _mediator.Send(command);
            var accHandler = await _mediator.Send(commandAccount);
            return CreatedAtAction("GetTodoList", new { id = handler.Id }, todoList);
        }
        [HttpPost("changeCommonStatus/{id}")]
        public async Task<IActionResult> ChangeCommonStatus(Guid id , UserIdsRequest UserIds)
        {
            var command = new TodoListChangeCommonStatus(id,UserIds.UserIds) ;
            var handler = await _mediator.Send(command);
            return Ok();
        }
        // DELETE: api/TodoLists/5
        [HttpDelete("{UserId}/{id}")]
        public async Task<IActionResult> DeleteTodoList(Guid UserId, Guid id)
        {
            var command = new DeleteTodoListFromAccount(UserId, id);
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
