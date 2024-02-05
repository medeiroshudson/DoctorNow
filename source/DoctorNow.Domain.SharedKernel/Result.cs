namespace DoctorNow.Domain.SharedKernel;

public sealed class Result<TValue, TError>
{
    public readonly TValue? Data;
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
        Data = default;
        Error = error;
        IsSuccess = false;
    }
    
    public static Result<TValue, TError> Success(TValue data) => new Result<TValue, TError>(data);
    public static Result<TValue, TError> Failure(TError error) => new Result<TValue, TError>(error);
    
    public static implicit operator Result<TValue, TError>(TValue data) => Success(data);
    public static implicit operator Result<TValue, TError>(TError error) => Failure(error);

    public Result<TValue, TError> Match(
        Func<TValue, Result<TValue, TError>> success,
        Func<TError, Result<TValue, TError>> failure) => IsSuccess ? success(Data!) : failure(Error!);
}