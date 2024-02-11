namespace DoctorNow.Domain.SharedKernel;

public enum ErrorType
{
    Failure = 0,
    Validation = 1,
    NotFound = 2,
    Conflict = 3
}

public record Error
{
    private Error(string Code, ErrorType Type, string? Message = null)
    {
        this.Code = Code;
        this.Type = Type;
        this.Message = Message;
    }
    
    public ErrorType Type { get; init; }
    public string Code { get; init; }
    public string? Message { get; init; }
    
    public static Error Failure(string code, string message) => new(code, ErrorType.Failure, message);
    public static Error Validation(string code, string message) => new(code, ErrorType.Validation, message);
    public static Error NotFound(string code, string message) => new(code, ErrorType.NotFound, message);
    public static Error Conflict(string code, string message) => new(code, ErrorType.Conflict, message);
}
