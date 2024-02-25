using DoctorNow.Domain.Tenants;
using DoctorNow.Infrastructure.Persistence.Contexts;

namespace DoctorNow.Infrastructure.Persistence.Repositories.Tenants;

public class TenantRepository(AppDbContext dbContext) 
    : Repository<Tenant>(dbContext), ITenantRepository
{
    
}