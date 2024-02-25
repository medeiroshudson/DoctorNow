namespace DoctorNow.Application.Features.Users.Contracts;

public record AuthenticateUserRequest(string Email, string Password);