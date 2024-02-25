using DoctorNow.Domain.SharedKernel;
using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Users.Contracts;

namespace DoctorNow.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQuery() : IQuery<IEnumerable<UserResponse>, Error>;