using DoctorNow.Domain.Tenants;
using DoctorNow.Application.Abstractions;
using DoctorNow.Application.Abstractions.Messaging;

namespace DoctorNow.Application.Tenants.Queries;

public record GetTenantByIdQuery(Guid TenantId) : IQuery<Tenant>;