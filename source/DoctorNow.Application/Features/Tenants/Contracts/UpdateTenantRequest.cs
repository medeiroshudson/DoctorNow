using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Contracts;

public record UpdateTenantRequest(
    string Name, 
    string DocumentNumber, 
    TenantStatus Status);