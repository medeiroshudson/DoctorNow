using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Tenants.Queries;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Handlers;

public sealed class GetAllTenantsQueryHandler(ITenantRepository tenantRepository)
    : IQueryHandler<GetAllTenantsQuery, IEnumerable<Tenant>, Error>
{
    public async Task<Result<IEnumerable<Tenant>, Error>> Handle(GetAllTenantsQuery request, CancellationToken cancellationToken)
    {
        var tenants = await tenantRepository.GetAllAsync(cancellationToken);

        return tenants.ToList();
    }
}