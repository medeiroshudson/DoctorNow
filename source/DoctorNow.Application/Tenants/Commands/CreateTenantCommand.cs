using DoctorNow.Domain.Tenants;
using DoctorNow.Application.Abstractions;
using DoctorNow.Application.Abstractions.Messaging;

namespace DoctorNow.Application.Tenants.Commands;

public record CreateTenantCommand(string Name, string DocumentNumber) : ICommand<Tenant>;