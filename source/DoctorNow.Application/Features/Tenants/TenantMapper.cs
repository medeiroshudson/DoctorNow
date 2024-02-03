using DoctorNow.Application.Abstractions.Mapping;
using DoctorNow.Application.Features.Tenants.Contracts;
using DoctorNow.Domain.Tenants;
using Riok.Mapperly.Abstractions;

namespace DoctorNow.Application.Features.Tenants;

[Mapper]
public partial class TenantMapper : IMapper
{
    public partial TenantResponse MapToResponse(Tenant request);
    public partial ICollection<TenantResponse> MapToResponseCollection(ICollection<Tenant> request);
}