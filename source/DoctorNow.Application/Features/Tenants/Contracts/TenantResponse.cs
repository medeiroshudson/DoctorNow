using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Contracts;

public record TenantResponse(
    Guid Id,
    string Name,
    string DocumentNumber,
    TenantStatus Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt);