using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Application.Features.Tenants.Commands;

public record DeleteTenantCommand(Guid Id): ICommand<bool, Error>;