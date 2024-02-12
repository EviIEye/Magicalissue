using Magical.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Magical.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Champion> Champions { get; }
        DbSet<Match> Matches { get; }
        DbSet<Pool> Pools { get; }
        DbSet<Profile> Profiles { get; }
        DbSet<Roster> Rosters { get; }
        DbSet<Schedule> Schedules { get; }
        DbSet<Statistics> Statistics { get; }
        DbSet<Status> Statuses { get; }
        DbSet<Team> Teams { get; }
        DbSet<Domain.Entities.TimeSpan> TimeSpans { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
