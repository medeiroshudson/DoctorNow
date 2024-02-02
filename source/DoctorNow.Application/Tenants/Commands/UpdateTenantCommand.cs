using DoctorNow.Application.Abstractions;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Tenants.Commands;

public record UpdateTenantCommand(
    Guid Id, 
    string Name, 
    string DocumentNumber, 
    TenantStatus Status): ICommand<Tenant>;