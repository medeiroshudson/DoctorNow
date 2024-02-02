using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Domain.Tenants;

public static class TenantErrors
{
    public static Error NotFound(Guid tenantId) =>
        new("Tenant.NotFound", $"The Tenant with Id '{tenantId}' was not found.");
    
    public static Error DocumentNumberNotUnique(string documentNumber) =>
        new("Tenant.DocumentNumberNotUnique", $"The Tenant document number {documentNumber} is not unique.");
}