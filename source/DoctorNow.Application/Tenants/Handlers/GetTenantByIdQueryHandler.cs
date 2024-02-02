using DoctorNow.Application.Abstractions;
using DoctorNow.Application.Tenants.Queries;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Tenants.Handlers;

public sealed class GetTenantByIdQueryHandler : IQueryHandler<GetTenantByIdQuery, Tenant>
{
    private readonly ITenantRepository _tenantRepository;

    public GetTenantByIdQueryHandler(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }
    
    public async Task<Result<Tenant>> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken = default)
    {
        var tenant = await _tenantRepository.GetByIdAsync(request.TenantId, cancellationToken);
        
        if (tenant is null)
            return Result.Failure<Tenant>(TenantErrors.NotFound(request.TenantId));

        return Result.Success(tenant);
    }
}