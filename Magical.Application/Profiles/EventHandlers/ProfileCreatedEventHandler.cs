using Magical.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Application.Profiles.EventHandlers
{
    public class ProfileCreatedEventHandler : INotificationHandler<ProfileCreatedEvent>
    {
        private readonly ILogger<ProfileCreatedEventHandler> _logger;
        public ProfileCreatedEventHandler(ILogger<ProfileCreatedEventHandler> logs)
            => _logger = logs;

        public Task Handle(ProfileCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Magicalissue Domain Event : {notification.GetType().Name}");

            return Task.CompletedTask;
        }
    }
}
