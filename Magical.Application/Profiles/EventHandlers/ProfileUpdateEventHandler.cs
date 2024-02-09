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
    public class ProfileUpdateEventHandler : INotificationHandler<ProfileUpdateEvent>
    {
        private readonly ILogger<ProfileUpdateEventHandler> _logger;
        public ProfileUpdateEventHandler(ILogger<ProfileUpdateEventHandler> logs)
            => _logger = logs;

        public Task Handle(ProfileUpdateEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Magicalissue Domain Event : {}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
