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
    private Error(ErrorType Type, string Code, string? Message = null)
    {
        this.Type = Type;
        this.Code = Code;
        this.Message = Message;
    }
    
    public ErrorType Type { get; init; }
    public string Code { get; init; }
    public string? Message { get; init; }
    
    public static Error Failure(string code, string message) => new(ErrorType.Failure, code, message);
    public static Error Validation(string code, string message) => new(ErrorType.Validation, code, message);
    public static Error NotFound(string code, string message) => new(ErrorType.NotFound, code, message);
    public static Error Conflict(string code, string message) => new(ErrorType.Conflict, code, message);
}
