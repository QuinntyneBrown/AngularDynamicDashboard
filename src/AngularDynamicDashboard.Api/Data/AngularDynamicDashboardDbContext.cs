using AngularDynamicDashboard.Api.Core;
using AngularDynamicDashboard.Api.Interfaces;
using AngularDynamicDashboard.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDynamicDashboard.Api.Data
{
    public class AngularDynamicDashboardDbContext : DbContext, IAngularDynamicDashboardDbContext
    {
        public DbSet<DashboardCard> DashboardCards { get; private set; }
        public DbSet<StoredEvent> StoredEvents { get; private set; }
        public AngularDynamicDashboardDbContext(DbContextOptions options)
            : base(options)
        {
            SavingChanges += DbContext_SavingChanges;
        }

        private void DbContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            var entries = ChangeTracker.Entries<AggregateRoot>()
                .Where(
                    e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToList();

            foreach (var aggregate in entries)
            {
                foreach (var storedEvent in aggregate.StoredEvents)
                {
                    StoredEvents.Add(storedEvent);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AngularDynamicDashboardDbContext).Assembly);
        }

        public override void Dispose()
        {
            SavingChanges -= DbContext_SavingChanges;

            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            SavingChanges -= DbContext_SavingChanges;

            return base.DisposeAsync();
        }

    }
}
