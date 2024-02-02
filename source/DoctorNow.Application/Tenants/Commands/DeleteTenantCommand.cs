using DoctorNow.Domain.SharedKernel;
using DoctorNow.Application.Abstractions;

namespace DoctorNow.Application.Tenants.Commands;

public record DeleteTenantCommand(Guid Id): ICommand<bool>;