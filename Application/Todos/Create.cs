using System;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Todos;

public class Create
{
    public class Command : IRequest<TodoDto>
        {
            public required CreateTodoDto Todo { get; set; }
        }

        public class Handler : IRequestHandler<Command, TodoDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TodoDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var todo = _mapper.Map<Todo>(request.Todo);
                
                todo.Id = Guid.NewGuid();
                todo.CreatedDate = DateTime.Now;
                todo.IsCompleted = false;
                
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync(cancellationToken);
                
                return _mapper.Map<TodoDto>(todo);
            }
        }
}
