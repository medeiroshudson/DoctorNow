using DoctorNow.Domain.Patients;
using DoctorNow.Presentation.MobileApp.Services.Abstractions;

namespace DoctorNow.Presentation.MobileApp.Services.Implementations;

public class PatientService : IPatientService
{
    private readonly List<Patient> _patients = [
        Patient.Create("Hudson Medeiros"),
        Patient.Create("Fulano de Tal")
    ];

    public async Task<ICollection<Patient>> GetAll()
    {
        await Task.Delay(1000);

        return _patients;
    }
    
    public async Task<Patient> Add(Patient patient)
    {
        await Task.Delay(500);

        var created = Patient.Create(patient.Name);
        
        _patients.Add(created);

        return created;
    }
}