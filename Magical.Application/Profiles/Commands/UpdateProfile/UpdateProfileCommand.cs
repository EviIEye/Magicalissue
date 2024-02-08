using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Application.Profiles.Commands.UpdateProfile
{
    public record UpdateProfileCommand : IRequest<int>
    {
    }
}
