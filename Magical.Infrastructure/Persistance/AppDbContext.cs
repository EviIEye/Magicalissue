using Duende.IdentityServer.EntityFramework.Options;
using Magical.Application.Common.Interfaces;
using Magical.Domain.Entities;
using Magical.Domain.Persistance.Interceptors;
using Magical.Infrastructure.Common;
using Magical.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Infrastructure.Persistance
{
    public class AppDbContext : ApiAuthorizationDbContext<AppUser>, IAppDbContext
    {
        private readonly IMediator _mediator;
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            IOptions<OperationalStoreOptions> operationalOptions,
            IMediator mediator,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
            : base(options, operationalOptions) 
        {
            _mediator = mediator;
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<Champion> Champions => Set<Champion>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<Pool> Pools => Set<Pool>();
        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<Roster> Rosters => Set<Roster>();
        public DbSet<Schedule> Schedules => Set<Schedule>();
        public DbSet<Statistics> Statistics => Set<Statistics>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Domain.Entities.TimeSpan> TimeSpans => Set<Domain.Entities.TimeSpan>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
