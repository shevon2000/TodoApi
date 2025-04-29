using System;
using MediatR;
using Persistence;

namespace Application.Todos;

public class Delete
{
    public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var todo = await _context.Todos.FindAsync(new object[] { request.Id }, cancellationToken);
                
                if (todo != null)
                {
                    _context.Remove(todo);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                
                return Unit.Value;
            }
        }
}
