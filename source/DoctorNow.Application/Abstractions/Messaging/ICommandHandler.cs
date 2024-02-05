using DoctorNow.Domain.SharedKernel;
using MediatR;

namespace DoctorNow.Application.Abstractions.Messaging;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    
}

public interface ICommandHandler<in TCommand, TResponse, TError> : IRequestHandler<TCommand, Result<TResponse, TError>>
    where TCommand : ICommand<TResponse, TError>
{
    
}