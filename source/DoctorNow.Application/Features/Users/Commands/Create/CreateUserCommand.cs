using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Users.Contracts;
using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Application.Features.Users.Commands.Create;

public sealed record CreateUserCommand(Guid TenantId, string Name, string Email, string Password) : ICommand<UserResponse, Error>;