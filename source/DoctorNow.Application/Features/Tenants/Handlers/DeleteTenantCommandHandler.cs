using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Tenants.Commands;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Handlers;

internal sealed class DeleteTenantCommandHandler(IUnitOfWork unitOfWork, ITenantRepository tenantRepository)
    : ICommandHandler<DeleteTenantCommand, bool, Error>
{
    public async Task<Result<bool, Error>> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = await tenantRepository.GetByIdAsync(request.Id, cancellationToken);

        if (tenant is null) return TenantErrors.NotFound(request.Id);

        tenant.Delete();
        
        await tenantRepository.DeleteAsync(tenant.Id, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}