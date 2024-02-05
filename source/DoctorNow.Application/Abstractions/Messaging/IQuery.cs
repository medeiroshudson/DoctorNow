using DoctorNow.Domain.SharedKernel;
using MediatR;

namespace DoctorNow.Application.Abstractions.Messaging;

public interface IQuery<TResponse, TError> : IRequest<Result<TResponse, TError>>
{
    
}