using System;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Todos;

public class Edit
{
     public class Command : IRequest<TodoDto>
        {
            public Guid Id { get; set; }
            public required UpdateTodoDto Todo { get; set; }
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
                var todo = await _context.Todos.FindAsync(new object[] { request.Id }, cancellationToken);
                
                _mapper.Map(request.Todo, todo);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return _mapper.Map<TodoDto>(todo);
            }
        }
}
