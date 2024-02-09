using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Magical.Application.Common.Models
{
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors)
            => (Succeeded, Errors) = (succeeded, errors.ToArray());

        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }

        public static Result Success()
            => new Result(true, Array.Empty<string>());

        public static Result Failuer(IEnumerable<string> errors)
            => new Result(false, errors);
    }
}
