using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.DataAccess.Context;
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student>? Students { get; set; }
    public DbSet<ClassRoom>? ClassRooms { get; set; }

    public DbSet<AppUser>? Users { get; set; }
    public DbSet<AppRole>? Roles { get; set; }
    public DbSet<UserRole>? UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });
    }
}
