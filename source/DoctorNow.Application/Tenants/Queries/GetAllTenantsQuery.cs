using DoctorNow.Domain.Tenants;
using DoctorNow.Application.Abstractions;

namespace DoctorNow.Application.Tenants.Queries;

public record GetAllTenantsQuery() : IQuery<ICollection<Tenant>>;