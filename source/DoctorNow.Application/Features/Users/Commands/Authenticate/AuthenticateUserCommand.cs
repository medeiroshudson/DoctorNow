using DoctorNow.Domain.SharedKernel;
using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Users.Contracts;

namespace DoctorNow.Application.Features.Users.Commands.Authenticate;

public sealed record AuthenticateUserCommand(string Email, string Password) : ICommand<UserTokenResponse, Error>;