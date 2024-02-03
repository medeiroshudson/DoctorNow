using DoctorNow.Application.Abstractions.Messaging;
using DoctorNow.Application.Features.Tenants.Commands;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Domain.Tenants;

namespace DoctorNow.Application.Features.Tenants.Handlers;

internal sealed class CreateTenantCommandHandler : ICommandHandler<CreateTenantCommand, Tenant>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantRepository _tenantRepository;

    public CreateTenantCommandHandler(IUnitOfWork unitOfWork, ITenantRepository tenantRepository)
    {
        _unitOfWork = unitOfWork;
        _tenantRepository = tenantRepository;
    }

    public async Task<Result<Tenant>> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = Tenant.Create(request.Name, request.DocumentNumber);

        var isUniqueDocumentNumber = await _tenantRepository.IsDocumentNumberUnique(tenant.DocumentNumber);
        
        if (isUniqueDocumentNumber == false)
            return Result.Failure<Tenant>(TenantErrors.DocumentNumberNotUnique(tenant.DocumentNumber));

        await _tenantRepository.AddAsync(tenant, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(tenant);
    }
}