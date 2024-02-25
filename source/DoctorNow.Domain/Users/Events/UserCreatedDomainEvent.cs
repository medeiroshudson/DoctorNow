using DoctorNow.Domain.SharedKernel.Interfaces;

namespace DoctorNow.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;