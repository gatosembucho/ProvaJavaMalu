using Microsoft.EntityFrameworkCore;

namespace ProvaJavaMalu.Entities;

public class ProvaJavaMaluDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Trip> Trips => Set<Trip>();
    public DbSet<Point> Points => Set<Point>();
    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Point>()
        .HasOne(t => t.Trips)
        .WithMany(p => p.Points)
        .HasForeignKey(t => t.IDTrip)
        .OnDelete(DeleteBehavior.Cascade);

        model.Entity<User>()
       .HasMany(t => t.Trips)
       .WithMany(p => p.Users);
        
        model.Entity<Trip>()
       .HasMany(u => u.Users)
       .WithMany(t => t.Trips);
    }
}