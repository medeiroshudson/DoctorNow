using DoctorNow.Domain.Tenants;
using DoctorNow.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DoctorNow.Infrastructure.Persistence.Repositories.Tenants;

public class TenantRepository : Repository<Tenant>, ITenantRepository
{
    private readonly AppDbContext _dbContext;
    
    public TenantRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsDocumentNumberUnique(string documentNumber)
    {
        var exist = await _dbContext.Set<Tenant>().AnyAsync(t => t.DocumentNumber == documentNumber);
        return !exist;
    }
}