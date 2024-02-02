using MediatR;
using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}