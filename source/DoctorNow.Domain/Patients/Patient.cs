using DoctorNow.Domain.Patients.Events;
using DoctorNow.Domain.Users;
using DoctorNow.Domain.SharedKernel;

namespace DoctorNow.Domain.Patients;

public class Patient : Entity
{
    protected Patient() { }
    
    private Patient(
        Guid id, string name, string email, string telephoneNumber) : base(id)
    {
        this.Name = name;
        this.Email = email;
        this.TelephoneNumber = telephoneNumber;
    }
    
    public User User { get; init; }
    public Guid UserId { get; init; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string TelephoneNumber { get; private set; }
    
    
    public static Patient Create(string name, string email, string telephoneNumber)
    {
        var patient = new Patient(Guid.NewGuid(), name, email, telephoneNumber)
            { CreatedAt = DateTime.UtcNow };

        patient.Raise(new PatientCreatedEvent(patient.Id));

        return patient;
    }
}