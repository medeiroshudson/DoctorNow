using DoctorNow.Domain.Tenants;

namespace DoctorNow.Presentation.Common.Contracts.Tenants;

public record UpdateTenantRequest(
    string Name, 
    string DocumentNumber, 
    TenantStatus Status);