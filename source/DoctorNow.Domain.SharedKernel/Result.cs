namespace DoctorNow.Domain.SharedKernel;

public sealed class Result<TValue, TError>
{
    public readonly TValue Data;
    public readonly TError Error;

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    private Result(TValue data)
    {
        Data = data;
        Error = default!;
        
        IsSuccess = true;
    }

    private Result(TError error)
    {
        Data = default!;
        Error = error;
        
        IsSuccess = false;
    }
    
    // returns as `Result.Success(data)` or `Result.Failure(error)`
    public static Result<TValue, TError> Success(TValue data) => new Result<TValue, TError>(data);
    public static Result<TValue, TError> Failure(TError error) => new Result<TValue, TError>(error);
    
    
    // return as entity e.g: `TValue` or `TError`
    public static implicit operator Result<TValue, TError>(TValue data) => Success(data);
    public static implicit operator Result<TValue, TError>(TError error) => Failure(error);

    public TReturn Match<TReturn>(
        Func<TValue, TReturn> success,
        Func<TError, TReturn> failure) => IsSuccess ? success(Data) : failure(Error);
}