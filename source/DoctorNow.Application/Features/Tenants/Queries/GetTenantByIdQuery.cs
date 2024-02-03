using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Queries;

public record GetTenantByIdQuery(Guid TenantId) : IQuery<Tenant>;