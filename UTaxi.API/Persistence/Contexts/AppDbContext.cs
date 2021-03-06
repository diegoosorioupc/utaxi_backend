using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using UTaxi.API.Domain.Models;
using UTaxi.API.Extensions;

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
        
        public DbSet<StudentRoute> StudentRoutes { get; set; }

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
            builder.Entity<Driver>().Property(p => p.Birth).IsRequired();
            builder.Entity<Driver>().Property(p => p.Phone).IsRequired();
            builder.Entity<Driver>().Property(p => p.LicensedNumber).IsRequired();
            builder.Entity<Driver>().Property(p => p.UniversityName).IsRequired();
            builder.Entity<Driver>().Property(p => p.UniversityCard).IsRequired();
            
            builder.Entity<Student>().ToTable("Students");
            builder.Entity<Student>().HasKey(p => p.Id);
            builder.Entity<Student>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Student>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Student>().Property(p => p.Birth).IsRequired();
            builder.Entity<Student>().Property(p => p.Phone).IsRequired();
            builder.Entity<Student>().Property(p => p.UniversityName).IsRequired();
            builder.Entity<Student>().Property(p => p.UniversityCard).IsRequired();
            
            builder.Entity<Route>().ToTable("Routes");
            builder.Entity<Route>().HasKey(p => p.Id);
            builder.Entity<Route>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Route>().Property(p => p.Status).IsRequired();
            
            builder.Entity<DetailsRoute>().ToTable("DetailsRoutes");
            builder.Entity<DetailsRoute>().HasKey(p => p.Id);
            builder.Entity<DetailsRoute>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<DetailsRoute>().Property(p => p.Description).IsRequired();
            builder.Entity<DetailsRoute>().Property(p => p.Date).IsRequired();
            builder.Entity<DetailsRoute>().Property(p => p.RouteCode).IsRequired();
            builder.Entity<DetailsRoute>().Property(p => p.RouteStart).IsRequired();
            builder.Entity<DetailsRoute>().Property(p => p.RouteEnd).IsRequired();
            builder.Entity<DetailsRoute>().Property(p => p.Price).IsRequired();
            
            builder.Entity<Taxi>().ToTable("Taxis");
            builder.Entity<Taxi>().HasKey(p => p.Id);
            builder.Entity<Taxi>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Taxi>().Property(p => p.RegistrationNumber).IsRequired();
            builder.Entity<Taxi>().Property(p => p.Capacity).IsRequired();
            builder.Entity<Taxi>().Property(p => p.VehicleStatus).IsRequired();
            builder.Entity<Taxi>().Property(p => p.Model).IsRequired();

            builder.Entity<StudentRoute>().ToTable("StudentsRoutes");
            builder.Entity<StudentRoute>().HasKey(p => p.Id);
            
            builder.Entity<Payment>().ToTable("Payments");
            builder.Entity<Payment>().HasKey(p => p.Id);
            builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.Mont).IsRequired();
            builder.Entity<Payment>().Property(p => p.Discount).IsRequired();
            builder.Entity<Payment>().Property(p => p.CheckPayment).IsRequired();
            builder.Entity<Payment>().Property(p => p.TypePayment).IsRequired();
            
            
            //Relationships
            builder.Entity<Driver>()
                .HasMany(p => p.Routes)
                .WithOne(p => p.Driver)
                .HasForeignKey(p => p.DriverId);
            
            builder.Entity<Student>()
                .HasMany(p => p.StudentRoutes)
                .WithOne(p =>p.Student)
                .HasForeignKey(p => p.StudentId);
            
            builder.Entity<Route>()
                .HasMany(p => p.StudentRoutes)
                .WithOne(p =>p.Route)
                .HasForeignKey(p => p.RouteId);
            
            builder.Entity<Driver>()
                .HasMany(p => p.Taxis)
                .WithOne(p =>p.Driver)
                .HasForeignKey(p => p.DriverId);
            
            builder.Entity<DetailsRoute>()
                .HasOne(p => p.Route)
                .WithOne(p =>p.DetailsRoute)
                .HasForeignKey<Route>(p => p.DetailsRouteId);
            
            builder.Entity<Payment>()
                .HasOne(p => p.DetailsRoute)
                .WithOne(p =>p.Payment)
                .HasForeignKey<DetailsRoute>(p => p.PaymentId);
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}