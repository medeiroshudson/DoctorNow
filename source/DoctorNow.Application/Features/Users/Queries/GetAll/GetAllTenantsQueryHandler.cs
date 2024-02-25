using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Users.Contracts;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Users;

namespace DoctorNow.Application.Features.Users.Queries.GetAll;

public sealed class GetAllUsersQueryHandler(IUserRepository userRepository)
    : IQueryHandler<GetAllUsersQuery, IEnumerable<UserResponse>, Error>
{
    public async Task<Result<IEnumerable<UserResponse>, Error>> Handle(
        GetAllUsersQuery request, 
        CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync(cancellationToken);
        
        return new UserMapper()
            .MapToResponse(users).ToList();
    }
}