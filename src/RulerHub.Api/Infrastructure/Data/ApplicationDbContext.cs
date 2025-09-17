using Microsoft.EntityFrameworkCore;

using RulerHub.Api.Domain.Entities.Stores;

namespace RulerHub.Api.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // propiedades sombra globales
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.Entity(entityType.ClrType).Property<DateTime>("CreatedAt");
            modelBuilder.Entity(entityType.ClrType).Property<DateTime>("UpdatedAt");
        }
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added
            || e.State == EntityState.Modified);
        foreach (var entry in entries)
        {
            entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
            if (entry.State == EntityState.Added)
                entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
        }
        return base.SaveChanges();
    }
}
