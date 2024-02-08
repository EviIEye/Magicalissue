using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Domain.Entities
{
    public enum GameStatus
    {
        Planned = 0,
        InProcess = 1,
        Complite = 2,
        Cancelled = 3,
        Reschedule = 4
    }
}
