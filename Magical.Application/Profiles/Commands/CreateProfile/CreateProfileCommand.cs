using Magical.Application.Common.Interfaces;
using Magical.Domain.Entities;
using Magical.Domain.Events;
using MediatR;

namespace Magical.Application.Profiles.Commands.CreateProfile
{
    public record CreateProfileCommand : IRequest<int>
    {
        public string UserName { get;  init; }
        public string Email { get;  init; } 
    }

    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateProfileCommandHandler(IAppDbContext db) => _context = db;
        public async Task<int> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = new Profile()
            {
                UserName = request.UserName,
                Email = request.Email,
                RegistrationDate = DateTime.Now,
                TotalMatches = 0,
                Wins = 0,
                Defeats = 0,
            };

            entity.AddDomainEvent(new ProfileCreatedEvent(entity));

            await _context.Profiles.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
