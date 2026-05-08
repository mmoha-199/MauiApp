
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StarterApp.Database.Models;

namespace StarterApp.Database.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(){ }//BAD fallback path
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        if (string.IsNullOrEmpty(connectionString))
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("StarterApp.Database.appsettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            connectionString = config.GetConnectionString("DevelopmentConnection");  
        }
        optionsBuilder.UseNpgsql(connectionString);
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Rental> Rentals => Set<Rental>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Item entity
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasIndex(e => e.Id).IsUnique();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PricePerDay).HasPrecision(10, 2);
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
        });

        // Configure User entity
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PasswordSalt).HasMaxLength(255);
        });

        // Configure Role entity
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        // Configure UserRole entity
        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasIndex(e => new { e.UserId, e.RoleId }).IsUnique();

            entity.HasOne(ur => ur.User)
                  .WithMany(u => u.UserRoles)
                  .HasForeignKey(ur => ur.UserId);

            entity.HasOne(ur => ur.Role)
                  .WithMany(r => r.UserRoles)
                  .HasForeignKey(ur => ur.RoleId);
        });
        // Configure Rental entity
        modelBuilder.Entity<Rental>(e =>
        {
            e.HasOne(r => r.Item)
             .WithMany(i => i.Rentals)
             .HasForeignKey(r => r.ItemId)
             .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(r => r.Renter)
             .WithMany()
             .HasForeignKey(r => r.RenterId)
             .OnDelete(DeleteBehavior.Restrict);

            e.Property(r => r.TotalPrice).HasPrecision(10, 2);
        });
    }

}