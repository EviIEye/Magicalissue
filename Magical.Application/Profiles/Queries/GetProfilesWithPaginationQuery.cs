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
    //запрос чтения для : определенной модели
    public record GetProfilesWithPaginationQuery : IRequest<PaginatedList<ProfileBriefDto>>
    {
        //данные необходимые для выполнения запроса
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } =  10;
    }
    //собственно обработчик запроса указывающий : ..<выполняемую команду, возвращаемый ответ>
    public class GetProfilesWithPaginationQueryHandler
        : IRequestHandler<GetProfilesWithPaginationQuery, PaginatedList<ProfileBriefDto>>
    {
        private readonly IAppDbContext _context; //доп объекты необходимые
        private readonly IMapper _mapper;        //для запроса
        public GetProfilesWithPaginationQueryHandler(IAppDbContext db, IMapper maps)
            => (_context, _mapper) = (db, maps);

        //наконец метод выполняющий обработку запроса
        public async Task<PaginatedList<ProfileBriefDto>> Handle(
            GetProfilesWithPaginationQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Profiles
                .OrderBy(x => x.UserName)
                .ProjectTo<ProfileBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
