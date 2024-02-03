using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Queries;

public record GetAllTenantsQuery() : IQuery<ICollection<Tenant>>;