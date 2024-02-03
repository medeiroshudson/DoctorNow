using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Tenants.Commands;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Handlers;

internal sealed class DeleteTenantCommandHandler : ICommandHandler<DeleteTenantCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantRepository _tenantRepository;

    public DeleteTenantCommandHandler(IUnitOfWork unitOfWork, ITenantRepository tenantRepository)
    {
        _unitOfWork = unitOfWork;
        _tenantRepository = tenantRepository;
    }
    
    public async Task<Result<bool>> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (tenant is null)
            return Result.Failure<bool>(TenantErrors.NotFound(request.Id));

        tenant.Delete();
        
        await _tenantRepository.DeleteAsync(tenant.Id, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(true);
    }
}