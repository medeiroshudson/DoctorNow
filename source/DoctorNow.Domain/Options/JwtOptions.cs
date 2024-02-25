using System.ComponentModel.DataAnnotations;

namespace DoctorNow.Domain.Options;

public sealed class JwtOptions
{
    public const string SectionName = "JwtOptions";
    
    [Required]
    public required string Issuer { get; init; }
    
    [Required]
    public required string Audience { get; init; }
    
    [Required]
    public required string SecretKey { get; init; }
    
    [Required]
    public required int TokenLifetimeInHours { get; init; }
}
