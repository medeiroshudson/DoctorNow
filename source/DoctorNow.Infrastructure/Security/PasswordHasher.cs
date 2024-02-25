using System.Security.Cryptography;
using DoctorNow.Application.Abstractions.Security;

namespace DoctorNow.Infrastructure.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 128 / 8;
    private const int KeySize = 256 / 8;
    private const int Iterations = 10000;
    private const char Delimiter = ';';
    
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;
    
    public string Hash(string input)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(input, salt, Iterations, HashAlgorithm, KeySize);

        return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool Verify(string input, string hashed)
    {
        var elements = hashed.Split(Delimiter);
        
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var hashBytes = Rfc2898DeriveBytes.Pbkdf2(input, salt, Iterations, HashAlgorithm, KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashBytes);
    }
}