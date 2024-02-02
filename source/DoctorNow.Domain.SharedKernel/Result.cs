namespace DoctorNow.Domain.SharedKernel;

public abstract class BaseResult
{
    protected internal BaseResult(bool success, Error error)
    {
        if (success && error != Error.None || !success && error == Error.None) 
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = success;
        Error = error;
    }
    
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
}

public class Result : BaseResult
{
    protected internal Result(bool success, Error error)
        : base(success, error)
    { }

    public static Result Success() => new(true, Error.None);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default!, false, error);
}

public class Result<TValue> : BaseResult
{
    protected internal Result(TValue value, bool success, Error error)
        : base(success, error)
    {
        Value = value;
    }
    
    public TValue? Value { get; }
}