using DoctorNow.Domain.Users;

namespace DoctorNow.Application.Abstractions.Security;

public interface IJwtTokenProvider
{
    string Generate(User user);
}