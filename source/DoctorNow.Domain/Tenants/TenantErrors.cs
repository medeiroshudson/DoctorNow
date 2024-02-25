using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Domain.Tenants;

public static class TenantErrors
{
    private const string NotFoundErrorCode = "Tenant.NotFound";
    private const string DocumentNumberNotUniqueErrorCode = "Tenant.DocumentNumberNotUnique";
    
    public static Error NotFound(Guid tenantId) =>
        Error.NotFound(NotFoundErrorCode, $"The Tenant with Id '{tenantId}' was not found.");
    
    public static Error DocumentNumberNotUnique(string documentNumber) =>
        Error.Conflict(DocumentNumberNotUniqueErrorCode, $"The Tenant document number '{documentNumber}' is not unique.");
}