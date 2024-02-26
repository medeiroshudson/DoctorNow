using DoctorNow.Domain.SharedKernel.Interfaces;

namespace DoctorNow.Domain.Patients.Events;

public sealed record PatientCreatedEvent(Guid PatientId) : IDomainEvent;