using System.Collections.Immutable;
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

            //Constrains
            builder.Entity<Driver>().ToTable("Drivers");
            builder.Entity<Driver>().HasKey(p => p.Id);
            builder.Entity<Driver>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Driver>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            
            //Relationships
            builder.Entity<Driver>()
                .HasMany(p => p.Routes)
                .WithOne(p => p.Driver)
                .HasForeignKey(p => p.DriverId);
        }
    }
}