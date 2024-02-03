using System.ComponentModel.DataAnnotations;

namespace DoctorNow.Domain.Options;

public sealed class DatabaseOptions
{
    public const string SectionName = "DatabaseOptions";
    
    [Required]
    [Range(1, 10)]
    public int MaxRetryCount { get; set; }
    
    [Required]
    public int CommandTimeout { get; set; }
    
    [Required]
    public bool EnableDetailedErros { get; set; }
    
    [Required]
    public bool SensitiveDataLogging { get; set; }
    
    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
