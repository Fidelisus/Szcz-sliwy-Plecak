using Microsoft.EntityFrameworkCore;
using SzczesliwyPlecak.Models;

namespace SzczesliwyPlecak.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public DbSet<Trip> Trip { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<TripProduct> TripProduct { get; set; }
    }
}
