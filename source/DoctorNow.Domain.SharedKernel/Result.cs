namespace DoctorNow.Domain.SharedKernel;

public sealed class Result<TData, TError>
{
    public readonly TData Data;
    public readonly TError Error;

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    private Result(TData data)
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
    public static Result<TData, TError> Success(TData data) => new Result<TData, TError>(data);
    public static Result<TData, TError> Failure(TError error) => new Result<TData, TError>(error);
    
    
    // return as entity e.g: `TData` or `TError`
    public static implicit operator Result<TData, TError>(TData data) => Success(data);
    public static implicit operator Result<TData, TError>(TError error) => Failure(error);

    public TReturn Match<TReturn>(
        Func<TData, TReturn> success,
        Func<TError, TReturn> failure) => IsSuccess ? success(Data) : failure(Error);
}