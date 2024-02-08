using Magical.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Magical.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Champion> Champions { get; set; }
        DbSet<Match> Matches { get; set; }
        DbSet<Pool> Pools { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<Roster> Rosters { get; set; }
        DbSet<Schedule> Schedules { get; set; }
        DbSet<Statistics> Statistics { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Domain.Entities.TimeSpan> TimeSpans { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
