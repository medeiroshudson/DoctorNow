namespace DoctorNow.Presentation.WebApi.Options;

public class DatabaseOptions
{
    public int MaxRetryCount { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedErros { get; set; }
    public bool SensitiveDataLogging { get; set; }
    public string ConnectionString { get; set; } = string.Empty;
}