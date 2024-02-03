using DoctorNow.Domain.SharedKernel.Interfaces;

namespace DoctorNow.Domain.SharedKernel;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];
        
    protected Entity() {}

    protected Entity(Guid id)
    {
        this.Id = id;
    }
    
    public Guid Id { get; private init; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool Deleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<IDomainEvent> DomainEvents => _domainEvents.ToList();

    protected void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}