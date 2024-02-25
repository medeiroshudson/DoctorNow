using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Abstractions.Security;
using DoctorNow.Application.Features.Users.Contracts;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Domain.Tenants;
using DoctorNow.Domain.Users;

namespace DoctorNow.Application.Features.Users.Commands.Create;

internal sealed class CreateUserCommandHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    ITenantRepository tenantRepository,
    IPasswordHasher passwordHasher)
    : ICommandHandler<CreateUserCommand, UserResponse, Error>
{
    public async Task<Result<UserResponse, Error>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var tenant = await tenantRepository.GetByIdAsync(request.TenantId, cancellationToken);
        
        if (tenant is null)
        {
            return TenantErrors.NotFound(request.TenantId);
        }
        
        var user = User.Create(
            tenant, 
            request.Name, 
            request.Email, 
            passwordHasher.Hash(request.Password));

        var isUniqueEmail = await userRepository.IsUnique(u => u.Email == request.Email);
        
        if (isUniqueEmail == false)
        {
            return UserErrors.EmailNotUnique(user.Email);
        }

        await userRepository.AddAsync(user, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new UserMapper()
            .MapToResponse(user);
    }
}