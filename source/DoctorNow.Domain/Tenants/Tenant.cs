using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants.Events;
using DoctorNow.Domain.Users;

namespace DoctorNow.Domain.Tenants;

public class Tenant : Entity
{
    private readonly List<User> _users = [];
    
    protected Tenant() { }
    
    private Tenant(Guid id, string name, string documentNumber, TenantStatus status) : base(id)
    {
        this.Name = name;
        this.DocumentNumber = documentNumber;
        this.Status = status;
    }
    
    public string Name { get; private set; }
    public string DocumentNumber { get; private set; }
    public TenantStatus Status { get; private set; }

    public virtual IReadOnlyCollection<User> Users => _users;
    
    public static Tenant Create(string name, string documentNumber)
    {
        var tenant = new Tenant(
            Guid.NewGuid(), name, documentNumber, TenantStatus.Active);
        
        tenant.CreatedAt = DateTime.UtcNow;
        
        tenant.Raise(new TenantCreatedDomainEvent(tenant.Id));

        return tenant;
    }

    public void Update(string name, string documentNumber, TenantStatus status)
    {
        Name = name;
        DocumentNumber = documentNumber;
        Status = status;
        UpdatedAt = DateTime.UtcNow;
        
        this.Raise(new TenantUpdatedDomainEvent(this.Id));
    }

    public void Delete()
    {
        Deleted = true;
        DeletedAt = DateTime.UtcNow;
        
        this.Raise(new TenantDeletedDomainEvent(this.Id));
    }
}