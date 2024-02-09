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
    public class ProfileDeletedEventHandler : INotificationHandler<ProfileDeletedEvent>
    {
        private readonly ILogger<ProfileDeletedEventHandler> _logger;
        public ProfileDeletedEventHandler(ILogger<ProfileDeletedEventHandler> logs)
            => _logger = logs;

        public Task Handle(ProfileDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Magicalissue Domain Event : {}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
