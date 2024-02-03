using DoctorNow.Domain.Options;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DoctorNow.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    private readonly DatabaseOptions _databaseOptions;
    public AppDbContext(DbContextOptions<AppDbContext> options, 
        IOptions<DatabaseOptions> databaseOptions) : base(options)
    {
        _databaseOptions = databaseOptions.Value;
    }
    
    public DbSet<Tenant> Tenants { get; init; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        
        optionsBuilder.UseNpgsql(_databaseOptions.ConnectionString, actions =>
        {
            actions.CommandTimeout(_databaseOptions.CommandTimeout);
            actions.EnableRetryOnFailure(_databaseOptions.MaxRetryCount);
        });

        optionsBuilder.EnableSensitiveDataLogging(_databaseOptions.SensitiveDataLogging)
            .EnableDetailedErrors(_databaseOptions.EnableDetailedErros);
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
                    entityEntry.CurrentValues[nameof(entity.UpdatedAt)] = DateTime.UtcNow;
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