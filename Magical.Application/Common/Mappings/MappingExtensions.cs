using AutoMapper;
using AutoMapper.QueryableExtensions;
using Magical.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
            this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
            => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

        public static Task<List<TDest>> ProjectToListAsync<TDest>(
            this IQueryable queryable, IConfigurationProvider configuration) where TDest : class
        {
            return queryable.ProjectTo<TDest>(configuration).AsNoTracking().ToListAsync();
        }
    }
}
