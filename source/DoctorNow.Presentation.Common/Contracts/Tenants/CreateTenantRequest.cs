namespace DoctorNow.Presentation.Common.Contracts.Tenants;

public record CreateTenantRequest(
    string Name, 
    string DocumentNumber);