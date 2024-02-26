using DoctorNow.Domain.Patients.Events;
using DoctorNow.Domain.Users;
using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Domain.Patients;

public class Patient : Entity
{
    protected Patient() { }
    
    private Patient(
        Guid id, string name) : base(id)
    {
        this.Name = name;
    }
    
    public string Name { get; private set; }
    
    public Guid UserId { get; init; }
    public User User { get; init; }
    
    public static Patient Create(string name)
    {
        var patient = new Patient(Guid.NewGuid(), name)
            { CreatedAt = DateTime.UtcNow };

        patient.Raise(new PatientCreatedEvent(patient.Id));

        return patient;
    }
}