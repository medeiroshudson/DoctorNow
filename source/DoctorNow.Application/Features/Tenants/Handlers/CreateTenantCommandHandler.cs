using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Tenants.Commands;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Handlers;

internal sealed class CreateTenantCommandHandler(IUnitOfWork unitOfWork, ITenantRepository tenantRepository)
    : ICommandHandler<CreateTenantCommand, Tenant, Error>
{
    public async Task<Result<Tenant, Error>> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = Tenant.Create(request.Name, request.DocumentNumber);

        var isUniqueDocumentNumber = await tenantRepository.IsDocumentNumberUnique(tenant.DocumentNumber);
        
        if (isUniqueDocumentNumber == false) 
            return TenantErrors.DocumentNumberNotUnique(tenant.DocumentNumber);

        await tenantRepository.AddAsync(tenant, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return tenant;
    }
}