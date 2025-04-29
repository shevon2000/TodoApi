using System;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Todos;

public class List
{
    public class Query : IRequest<List<TodoDto>> { }

        public class Handler : IRequestHandler<Query, List<TodoDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<TodoDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var todos = await _context.Todos.ToListAsync(cancellationToken);
                
                return _mapper.Map<List<TodoDto>>(todos);
            }
        }
}
