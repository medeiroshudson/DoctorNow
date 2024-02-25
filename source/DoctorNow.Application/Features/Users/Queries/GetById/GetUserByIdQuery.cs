using DoctorNow.Domain.SharedKernel;
using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Users.Contracts;

namespace DoctorNow.Application.Features.Users.Queries.GetById;

public record GetUserByIdQuery(Guid Id) : IQuery<UserResponse, Error>;