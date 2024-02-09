using AutoMapper;
using AutoMapper.QueryableExtensions;
using Magical.Application.Common.Interfaces;
using Magical.Application.Common.Mappings;
using Magical.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Application.Profiles.Queries
{
    public record GetProfilesWithPaginationQuery : IRequest<PaginatedList<ProfileBriefDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } =  10;
    }

    public class GetProfilesWithPaginationQueryHandler
        : IRequestHandler<GetProfilesWithPaginationQuery, PaginatedList<ProfileBriefDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetProfilesWithPaginationQueryHandler(IApplicationDbContext db, IMapper maps)
            => (_context, _mapper) = (db, maps);
        public async Task<PaginatedList<ProfileBriefDto>> Handle(GetProfilesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Profiles
                .OrderBy(x => x.UserName)
                .ProjectTo<ProfileBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
            
        }
    }
}
