using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Application.Common.Models
{
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            succeeded
        }

        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }
    }
}
