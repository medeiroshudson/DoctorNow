using DoctorNow.Application.Abstractions;
using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Tenants.Commands;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Tenants.Handlers;

internal sealed class UpdateTenantCommandHandler : ICommandHandler<UpdateTenantCommand, Tenant>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantRepository _tenantRepository;

    public UpdateTenantCommandHandler(IUnitOfWork unitOfWork, ITenantRepository tenantRepository)
    {
        _unitOfWork = unitOfWork;
        _tenantRepository = tenantRepository;
    }
    
    public async Task<Result<Tenant>> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (tenant is null)
            return Result.Failure<Tenant>(TenantErrors.NotFound(request.Id));

        tenant.Update(request.Name, request.DocumentNumber, request.Status);
        
        await _tenantRepository.UpdateAsync(tenant, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(tenant);
    }
}