using DoctorNow.Application.Abstractions;
using DoctorNow.Application.Tenants.Queries;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Tenants.Handlers;

public sealed class GetAllTenantsQueryHandler : IQueryHandler<GetAllTenantsQuery, ICollection<Tenant>>
{
    private readonly ITenantRepository _tenantRepository;

    public GetAllTenantsQueryHandler(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }
    
    public async Task<Result<ICollection<Tenant>>> Handle(GetAllTenantsQuery request, CancellationToken cancellationToken)
    {
        var tenants = await _tenantRepository.GetAllAsync(cancellationToken);
        
        return Result.Success(tenants);
    }
}