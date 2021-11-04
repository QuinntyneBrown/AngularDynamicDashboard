using AngularDynamicDashboard.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace AngularDynamicDashboard.Api.Interfaces
{
    public interface IAngularDynamicDashboardDbContext
    {
        DbSet<DashboardCard> DashboardCards { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
