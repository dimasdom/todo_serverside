using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_serverside.Commands;
using todo_serverside.Context;
using todo_serverside.Models;
using todo_serverside.Queries;

namespace todo_serverside.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoListContext _context;
        private IMediator _mediator;

        public TodoItemsController(TodoListContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }


        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItem(Guid id)
        {
            var query = new GetTodoItemsByTodoListIdQuery(id);

            var response =  await _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }


        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            var command = new CreateTodoItemCommand(todoItem);
            var response = _mediator.Send(command);
            return CreatedAtAction("GetTodoItem", new { id = response.Id }, todoItem);
        }
        [HttpPost("done/{id}")]
        public async Task<ActionResult<bool>> PutDoneStatus(Guid id)
        {
            var command = new SetDoneStatusQuery(id);
            return await _mediator.Send(command);
        }
        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(Guid id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
