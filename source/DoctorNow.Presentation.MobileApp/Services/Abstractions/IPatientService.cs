using DoctorNow.Domain.Patients;

namespace DoctorNow.Presentation.MobileApp.Services.Abstractions;

public interface IPatientService
{
    Task<ICollection<Patient>> GetAll();
    Task<Patient?> GetById(Guid id);
    Task<Patient> Add(Patient patient);
}