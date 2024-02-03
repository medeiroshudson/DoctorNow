using System.ComponentModel.DataAnnotations;

namespace DoctorNow.Domain.Options;

public sealed class DatabaseOptions
{
    public const string SectionName = "DatabaseOptions";
    
    [Required]
    [Range(1, 10)]
    public int MaxRetryCount { get; init; }
    
    [Required]
    public int CommandTimeout { get; init; }
    
    [Required]
    public bool EnableDetailedErros { get; init; }
    
    [Required]
    public bool SensitiveDataLogging { get; init; }
    
    [Required]
    public string ConnectionString { get; init; } = string.Empty;
}
