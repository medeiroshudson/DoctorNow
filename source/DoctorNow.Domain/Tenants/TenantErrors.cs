using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Domain.Tenants;

public static class TenantErrors
{
    public const string NotFoundErrorCode = "Tenant.NotFound";
    public static Error NotFound(Guid tenantId) =>
        new(NotFoundErrorCode, $"The Tenant with Id '{tenantId}' was not found.");
    
    public const string DocumentNumberNotUniqueErrorCode = "Tenant.DocumentNumberNotUnique";
    public static Error DocumentNumberNotUnique(string documentNumber) =>
        new(DocumentNumberNotUniqueErrorCode, $"The Tenant document number '{documentNumber}' is not unique.");
}