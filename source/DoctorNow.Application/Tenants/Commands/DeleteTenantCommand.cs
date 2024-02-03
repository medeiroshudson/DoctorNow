using DoctorNow.Domain.SharedKernel;
using DoctorNow.Application.Abstractions;
using DoctorNow.Application.Abstractions.Messaging;

namespace DoctorNow.Application.Tenants.Commands;

public record DeleteTenantCommand(Guid Id): ICommand<bool>;