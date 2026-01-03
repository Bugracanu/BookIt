using BookIt.Models;
using Microsoft.EntityFrameworkCore;

namespace BookIt.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Saç Kesimi", Duration = 30, Price=150},
            new Service { Id = 2, Name = "Sakal Bakımı", Duration = 20, Price=100},
            new Service { Id = 3, Name = "Saç Kesimi", Duration = 45, Price=300}
        );
    }
}