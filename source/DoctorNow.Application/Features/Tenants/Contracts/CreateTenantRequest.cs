namespace DoctorNow.Application.Features.Tenants.Contracts;

public record CreateTenantRequest(
    string Name, 
    string DocumentNumber);