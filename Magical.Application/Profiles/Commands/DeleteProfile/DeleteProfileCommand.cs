using Magical.Application.Common.Exceptions;
using Magical.Application.Common.Interfaces;
using Magical.Domain.Entities;
using Magical.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Application.Profiles.Commands.DeleteProfile
{
    public record DeleteProfileCommand (int Id) : IRequest<Unit>;

    public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public DeleteProfileCommandHandler(IApplicationDbContext db) => _context = db;
        public async Task<Unit> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Profiles
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Profile), request.Id);

            _context.Profiles.Remove(entity);

            entity.AddDomainEvent(new ProfileDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
