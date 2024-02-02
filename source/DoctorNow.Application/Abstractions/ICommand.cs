using DoctorNow.Domain.SharedKernel;
using MediatR;

namespace DoctorNow.Application.Abstractions;

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}