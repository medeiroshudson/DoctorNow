using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Commands;

public record CreateTenantCommand(string Name, string DocumentNumber) : ICommand<Tenant>;