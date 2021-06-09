using KarlaHi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace KarlaHi.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}