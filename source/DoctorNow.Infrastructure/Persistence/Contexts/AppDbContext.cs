using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;
using Microsoft.EntityFrameworkCore;

namespace DoctorNow.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Tenant> Tenants { get; init; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
        {
            optionsBuilder.UseNpgsql(opt => 
                opt.MigrationsAssembly("DoctorNow.Infrastructure.Persistence"));
        }
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ConfigureEntityTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    private void ConfigureEntityTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(entry => entry is { Entity: Entity, State: EntityState.Added or EntityState.Modified or EntityState.Deleted });

        foreach (var entityEntry in entities)
        {
            var entity = (Entity)entityEntry.Entity;

            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entityEntry.Property(nameof(entity.CreatedAt)).IsModified = false;
                    break;
                case EntityState.Deleted:
                    entityEntry.State = EntityState.Modified;
                    entityEntry.CurrentValues[nameof(entity.Deleted)] = true;
                    entityEntry.CurrentValues[nameof(entity.DeletedAt)] = DateTime.UtcNow;
                    break;
            }
        }
    }

}