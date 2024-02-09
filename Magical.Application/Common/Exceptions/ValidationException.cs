using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
            => Errors = new Dictionary<string, string[]>();

        public ValidationException(
            IEnumerable<ValidationFailure> failuers) 
            : this() => Errors = failuers.GroupBy(
                e => e.PropertyName, e => e.ErrorMessage).ToDictionary(
                failuers => failuers.Key, failuers => failuers.ToArray());

        public IDictionary<string, string[]> Errors { get; }
    }
}
