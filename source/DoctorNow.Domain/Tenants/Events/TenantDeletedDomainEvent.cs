using DoctorNow.Domain.SharedKernel.Interfaces;

namespace DoctorNow.Domain.Tenants.Events;

public sealed record TenantDeletedDomainEvent(Guid TenantId) : IDomainEvent;