using DoctorNow.Domain.Tenants;
using Riok.Mapperly.Abstractions;
using DoctorNow.Application.Tenants.Contracts;
using DoctorNow.Application.Abstractions.Mapping;

namespace DoctorNow.Application.Tenants;

[Mapper]
public partial class TenantMapper : IMapper
{
    public partial TenantResponse MapToResponse(Tenant request);
    public partial ICollection<TenantResponse> MapToResponseCollection(ICollection<Tenant> request);
}