using DoctorNow.Domain.SharedKernel.Interfaces;

namespace DoctorNow.Domain.Tenants;

public interface ITenantRepository : IRepository<Tenant>
{
    Task<bool> IsDocumentNumberUnique(string documentNumber);
}