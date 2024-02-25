using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Domain.Users;

public static class UserErrors
{
    private const string NotFoundErrorCode = "User.NotFound";
    private const string EmailNotUniqueErrorCode = "User.NotUnique";
    private const string NotAuthorizedErrorCode = "User.NotAuthorized";

    public static Error NotFound() => 
        Error.NotFound(NotFoundErrorCode, $"The user was not found.");
    
    public static Error EmailNotUnique(string email) =>
        Error.Conflict(EmailNotUniqueErrorCode, $"There is already an email address registered for '{email}'");
    
    public static Error NotAuthorized(string email) =>
        Error.Unauthorized(NotAuthorizedErrorCode, $"The user '{email}' was not authorized.");
}