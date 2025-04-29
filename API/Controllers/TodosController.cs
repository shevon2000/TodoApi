using Application.DTOs;
using Application.Todos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoDto>>> GetTodos()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetTodo(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> CreateTodo(CreateTodoDto todo)
        {
            return await _mediator.Send(new Create.Command { Todo = todo });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoDto>> UpdateTodo(Guid id, UpdateTodoDto todo)
        {
            return await _mediator.Send(new Edit.Command { Id = id, Todo = todo });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(Guid id)
        {
            await _mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }
    }
}