using DoctorNow.Domain.Options;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;
using DoctorNow.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DoctorNow.Infrastructure.Persistence.Contexts;

public class AppDbContext(IOptions<DatabaseOptions> databaseOptions) : DbContext
{
    private readonly DatabaseOptions _databaseOptions = databaseOptions.Value;
    
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        
        optionsBuilder.UseLazyLoadingProxies();

        optionsBuilder.UseNpgsql(_databaseOptions.ConnectionString, actions =>
        {
            actions.CommandTimeout(_databaseOptions.CommandTimeout);
            actions.EnableRetryOnFailure(_databaseOptions.MaxRetryCount);
        });

        optionsBuilder.EnableSensitiveDataLogging(_databaseOptions.SensitiveDataLogging)
            .EnableDetailedErrors(_databaseOptions.EnableDetailedErros);

        if (_databaseOptions.SensitiveDataLogging)
        {
            optionsBuilder.LogTo(
                Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
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
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entityEntry.CurrentValues[nameof(Entity.CreatedAt)] = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entityEntry.Property(nameof(Entity.CreatedAt)).IsModified = false;
                    entityEntry.CurrentValues[nameof(Entity.UpdatedAt)] = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entityEntry.State = EntityState.Modified;
                    entityEntry.CurrentValues[nameof(Entity.Deleted)] = true;
                    entityEntry.CurrentValues[nameof(Entity.DeletedAt)] = DateTime.UtcNow;
                    break;
            }
        }
    }

}