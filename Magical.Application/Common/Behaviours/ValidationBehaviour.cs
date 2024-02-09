using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Application.Common.Behaviours
{
    public class ValidationBehaviour<Trequest, TResponse>
        : IPipelineBehavior<Trequest, TResponse>
        where TResponse : notnull
    {
        private readonly IEnumerable<IValidator<Trequest>> _validators;
        public ValidationBehaviour(
            IEnumerable<IValidator<Trequest>> validators)
            => _validators = validators;

        public async Task<TResponse> Handle(Trequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<Trequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(r => r.Errors.Any())
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (failures.Any())
                    throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
