using MediatR;
using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Application.Abstractions.Messaging;

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}