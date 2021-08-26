using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EfCoreUser>().HasData(
            new EfCoreUser { Id = 1, Name = "User 1" },
            new EfCoreUser { Id = 2, Name = "User 2" },
            new EfCoreUser { Id = 3, Name = "User 3" });
    }

    public DbSet<EfCoreUser> Users { get; set; }
}