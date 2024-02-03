using DoctorNow.Application.Abstractions.Messaging;

namespace DoctorNow.Application.Features.Tenants.Commands;

public record DeleteTenantCommand(Guid Id): ICommand<bool>;