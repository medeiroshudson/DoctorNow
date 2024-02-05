using MediatR;
using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Application.Abstractions.Messaging;

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse, TError> : IRequest<Result<TResponse, TError>>
{
}