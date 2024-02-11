using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using DoctorNow.Domain.SharedKernel;
using Microsoft.AspNetCore.Http;

namespace DoctorNow.Presentation.Common.Extensions;

public static class ResultExtensions
{
    [SuppressMessage("ReSharper", "ConvertClosureToMethodGroup")]
    public static IActionResult ConvertToFailureActionResult<TData>(this Result<TData, Error> result)
    {
        return result.Match<IActionResult>(
            success => HandleSuccess(),
            failure => HandleFailure(failure));

        static IActionResult HandleSuccess() => 
            throw new InvalidOperationException(
                "The result is a success, it should not be converted to a failure result.");
        
        static IActionResult HandleFailure(Error failure)
        {
            return failure.Type switch
            {
                ErrorType.Validation => CreateFailureResult(StatusCodes.Status400BadRequest, failure),
                ErrorType.NotFound => CreateFailureResult(StatusCodes.Status404NotFound, failure),
                ErrorType.Conflict => CreateFailureResult(StatusCodes.Status409Conflict, failure),
                _ => CreateFailureResult(StatusCodes.Status500InternalServerError, failure)
            };
            
            static IActionResult CreateFailureResult(int statusCode, Error failure) =>
                new ObjectResult(failure) { StatusCode = statusCode };
        }
    } 
}