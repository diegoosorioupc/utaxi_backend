using Microsoft.EntityFrameworkCore;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Persistence.Contexts

{
    public class AppDbContext : DbContext
    {
        public DbSet<DetailsRoute> DetailsRoutes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Taxi> Taxis { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Route> Routes { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}