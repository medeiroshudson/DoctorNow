using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.Tenants;
using DoctorNow.Domain.Users.Events;

namespace DoctorNow.Domain.Users;

public class User : Entity
{
    protected User() { }

    private User(
        Guid id, 
        Tenant tenant, 
        string name, 
        string email,
        string password) : base(id)
    {
        this.Tenant = tenant;
        this.Name = name;
        this.Email = email;
        this.Password = password;
    }
    
    public Guid TenantId { get; init; }
    public virtual Tenant Tenant { get; init; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    
    public static User Create(Tenant tenant, string name, string email, string password)
    {
        var user = new User(
            Guid.NewGuid(), tenant, name, email, password) { CreatedAt = DateTime.UtcNow };

        user.Raise(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}