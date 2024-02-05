using DoctorNow.Domain.SharedKernel;
using MediatR;

namespace DoctorNow.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse, TError> : IRequestHandler<TQuery, Result<TResponse, TError>>
    where TQuery : IQuery<TResponse, TError>
{

}