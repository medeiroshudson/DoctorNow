using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Users.Contracts;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Users;

namespace DoctorNow.Application.Features.Users.Queries.GetById;

public sealed class GetUserByIdQueryHandler(IUserRepository userRepository)
    : IQueryHandler<GetUserByIdQuery, UserResponse, Error>
{
    public async Task<Result<UserResponse, Error>> Handle(
        GetUserByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (user is null) return UserErrors.NotFound();
        
        return new UserMapper()
            .MapToResponse(user);
    }
}