using DoctorNow.Domain.SharedKernel;
using MediatR;

namespace DoctorNow.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
    // Task<Result<TResult>> Handle(TQuery query, CancellationToken cancellationToken);
}