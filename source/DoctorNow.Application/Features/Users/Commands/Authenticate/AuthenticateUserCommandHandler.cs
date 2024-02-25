using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Abstractions.Security;
using DoctorNow.Application.Features.Users.Contracts;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Users;

namespace DoctorNow.Application.Features.Users.Commands.Authenticate;

internal sealed class AuthenticateUserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenProvider jwtTokenProvider)
    : ICommandHandler<AuthenticateUserCommand, UserTokenResponse, Error>
{
    public async Task<Result<UserTokenResponse, Error>> Handle(
        AuthenticateUserCommand request, 
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email);
        
        if (user is null)
        {
            return UserErrors.NotFound();
        }

        var passwordCheck = passwordHasher.Verify(request.Password, user.Password);

        if (passwordCheck == false)
        {
            return UserErrors.NotAuthorized(user.Email);
        }
        
        var token = jwtTokenProvider.Generate(user);

        var userResponse = new UserMapper()
            .MapToResponse(user);
        
        return new UserTokenResponse(userResponse, token);
    }
}