namespace DoctorNow.Application.Abstractions.Security;

public interface IPasswordHasher
{
    string Hash(string input);
    bool Verify(string input, string hashed);
}