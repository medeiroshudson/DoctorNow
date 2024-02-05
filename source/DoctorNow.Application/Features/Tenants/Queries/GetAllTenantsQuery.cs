using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Tenants.Contracts;
using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Application.Features.Tenants.Queries;

public record GetAllTenantsQuery() : IQuery<IEnumerable<TenantResponse>, Error>;