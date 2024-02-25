namespace DoctorNow.Application.Features.Users.Contracts;

public record UserTokenResponse(UserResponse User, string Token);