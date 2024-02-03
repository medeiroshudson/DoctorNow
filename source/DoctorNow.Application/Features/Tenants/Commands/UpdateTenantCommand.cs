using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Commands;

public record UpdateTenantCommand(
    Guid Id, 
    string Name, 
    string DocumentNumber, 
    TenantStatus Status): ICommand<Tenant>;