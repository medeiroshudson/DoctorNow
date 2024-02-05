using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Tenants.Commands;
using DoctorNow.Application.Features.Tenants.Contracts;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Handlers;

internal sealed class UpdateTenantCommandHandler(IUnitOfWork unitOfWork, ITenantRepository tenantRepository)
    : ICommandHandler<UpdateTenantCommand, TenantResponse, Error>
{
    public async Task<Result<TenantResponse, Error>> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = await tenantRepository.GetByIdAsync(request.Id, cancellationToken);

        if (tenant is null) return TenantErrors.NotFound(request.Id);

        tenant.Update(request.Name, request.DocumentNumber, request.Status);
        
        await tenantRepository.UpdateAsync(tenant, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        var mapped = new TenantMapper()
            .MapToResponse(tenant);

        return mapped;
    }
}