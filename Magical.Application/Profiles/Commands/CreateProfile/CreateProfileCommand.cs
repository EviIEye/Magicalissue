using Magical.Application.Common.Interfaces;
using Magical.Domain.Entities;
using Magical.Domain.Events;
using MediatR;

namespace Magical.Application.Profiles.Commands.CreateProfile
{
    //класс-команда для вызова операции
    public record CreateProfileCommand : IRequest<int>
    {
        //в этой команде мы указываем данные необходимые для ее выполнения
        public string UserName { get;  init; }
        public string Email { get;  init; } 
    }

    //класс - обработчик команды
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, int>
    {
        private readonly IAppDbContext _context;
        //используя DI получаем дополнительно-нужные для работы команды объекты (AppDbContext)
        public CreateProfileCommandHandler(IAppDbContext db) => _context = db;
        //Метод занимающийся выполнением команды (в params прин. класс-команду, и токен завершения)
        public async Task<int> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            //т.к. это команда создания профиля, то вот мы его и создаем
            var entity = new Profile()
            {
                UserName = request.UserName,
                Email = request.Email,
                RegistrationDate = DateTime.Now,
                TotalMatches = 0,
                Wins = 0,
                Defeats = 0,
            };
            //каждая сущнсоть имеет свою историю изменений, которая понадобиться в будущем для логирования
            entity.AddDomainEvent(new ProfileCreatedEvent(entity));//поэтому момент создания мы в эту историю добавим

            await _context.Profiles.AddAsync(entity);           //теперь новую сущность можно добавить в бд
            await _context.SaveChangesAsync(cancellationToken); //и закрепить изменения

            return entity.Id;
        }
    }
}
