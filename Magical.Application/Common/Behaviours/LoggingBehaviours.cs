﻿using Magical.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Application.Common.Behaviours
{
    public class LoggingBehaviours<TRequest>
        : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;
        public LoggingBehaviours(ILogger logger,
            ICurrentUserService currentUserService,
            IIdentityService identityService) =>
            (_logger, _currentUserService, _identityService) 
            = (logger, currentUserService, identityService);

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId ?? string.Empty;
            string? userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
                userName = await _identityService.GetUserNameAsync(userId);
        }
    }
}
