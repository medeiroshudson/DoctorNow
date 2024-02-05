using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Queries;

public record GetAllTenantsQuery() : IQuery<IEnumerable<Tenant>, Error>;