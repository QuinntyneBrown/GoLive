using GoLive.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GoLive.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Customer> Customers { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
