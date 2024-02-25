using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorNow.Infrastructure.Persistence.Configurations;

public class TenantConfiguration : BaseEntityConfiguration<Tenant>
{
    public override void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => new { e.DocumentNumber, e.Deleted })
            .IsUnique()
            .HasFilter($"\"{nameof(Entity.Deleted)}\" = false");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.DocumentNumber)
            .IsRequired()
            .HasMaxLength(14);
        
        builder.Property(e => e.Status)
            .IsRequired()
            .HasConversion(
                v => Convert.ToString(v),
                v => Enum.Parse<TenantStatus>(v ?? string.Empty));

        builder.HasMany(e => e.Users)
            .WithOne(u => u.Tenant)
            .HasForeignKey(u => u.TenantId)
            .OnDelete(DeleteBehavior.Restrict);
        
        base.Configure(builder);
    }
}