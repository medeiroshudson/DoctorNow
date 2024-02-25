using DoctorNow.Application.Features.Tenants.Contracts;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Users.Contracts;

public record UserResponse(
    Guid Id,
    TenantResponse Tenant,
    string Name,
    string Email);