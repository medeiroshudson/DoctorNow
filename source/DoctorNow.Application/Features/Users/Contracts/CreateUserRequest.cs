namespace DoctorNow.Application.Features.Users.Contracts;

public record CreateUserRequest(
    Guid TenantId, 
    string Name,
    string Email,
    string Password);