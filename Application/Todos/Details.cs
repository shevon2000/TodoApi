using System;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Todos;

public class Details
{
    public class Query : IRequest<TodoDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, TodoDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TodoDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var todo = await _context.Todos.FindAsync(new object[] { request.Id }, cancellationToken);
                
                return _mapper.Map<TodoDto>(todo);
            }
        }
}
