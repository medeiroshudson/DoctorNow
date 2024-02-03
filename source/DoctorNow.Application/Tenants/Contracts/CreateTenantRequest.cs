namespace DoctorNow.Application.Tenants.Contracts;

public record CreateTenantRequest(
    string Name, 
    string DocumentNumber);