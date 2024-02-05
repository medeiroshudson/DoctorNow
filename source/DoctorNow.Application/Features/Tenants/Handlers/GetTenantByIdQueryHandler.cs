using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Tenants.Queries;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Handlers;

public sealed class GetTenantByIdQueryHandler(ITenantRepository tenantRepository)
    : IQueryHandler<GetTenantByIdQuery, Tenant, Error>
{
    public async Task<Result<Tenant, Error>> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken = default)
    {
        var tenant = await tenantRepository.GetByIdAsync(request.TenantId, cancellationToken);

        if (tenant is null) return TenantErrors.NotFound(request.TenantId);

        return tenant;
    }
}