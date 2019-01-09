using GoLive.Core.Interfaces;
using GoLive.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GoLive.Infrastructure
{
    public class AppDbContext: DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options)
        
        { }

        public DbSet<Customer> Customers { get; private set; }
    }
}
