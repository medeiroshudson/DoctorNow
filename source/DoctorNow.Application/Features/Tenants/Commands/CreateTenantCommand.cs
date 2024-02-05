using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Tenants.Contracts;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Commands;

public record CreateTenantCommand(string Name, string DocumentNumber) : ICommand<TenantResponse, Error>;