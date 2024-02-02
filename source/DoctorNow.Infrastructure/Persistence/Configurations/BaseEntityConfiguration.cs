using DoctorNow.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorNow.Infrastructure.Persistence.Configurations;

public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> 
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.Deleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(e => e.CreatedAt);
        
        builder.Property(e => e.DeletedAt);

        // default filtering `false` entities
        builder.HasQueryFilter(e => 
            EF.Property<bool>(e, nameof(e.Deleted)) == false);
    }
}