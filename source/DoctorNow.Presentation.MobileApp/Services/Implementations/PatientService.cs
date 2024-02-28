using DoctorNow.Domain.Patients;
using DoctorNow.Presentation.MobileApp.Services.Abstractions;

namespace DoctorNow.Presentation.MobileApp.Services.Implementations;

public class PatientService : IPatientService
{
    private readonly List<Patient> _patients = [
        Patient.Create("Hudson Medeiros", "medeiroshudson@outlook.com", "(21) 97164-0039"),
        Patient.Create("Rafaela Evelyn Pereira", "rafaela_pereira@esctech.com.br", "(69) 98996-8303"),
        Patient.Create("Tereza Isis Alana Moura", "terezaisismoura@unicohost.com.br", "(21) 99958-0988"),
        Patient.Create("Natália Silvana da Conceição", "natalia_daconceicao@ne.com", "(81) 2711-9527"),
        Patient.Create("Otávio Benedito Peixoto", "otavio-peixoto98@aol.com", "(84) 98807-5645"),
        Patient.Create("Nelson Benjamin Carvalho", "nelson_carvalho@magicday.com.br", "(87) 98759-6673"),
        Patient.Create("Vitor Lucas Francisco Silva", "vitorlucassilva@unimedrio.com.br", "(91) 98885-6425"),
        Patient.Create("Márcia Antonella da Silva", "marcia_antonella_dasilva@anac.gov.br", "(11) 99499-2499"),
        Patient.Create("Sophia Elaine Aurora Aparício", "sophia-aparicio86@deltaturismo.com.br", "(61) 99250-4096"),
        Patient.Create("Sebastião Raimundo Kevin Assis", "sebastiao-assis87@br.ibm.com", "(68) 99148-1694"),
        Patient.Create("Isabelly Maitê Alícia da Luz", "isabellymaitedaluz@alliancarh.com.br", "(84) 98560-1099"),
    ];

    public async Task<ICollection<Patient>> GetAll()
    {
        await Task.Delay(1000);

        return _patients;
    }

    public async Task<Patient?> GetById(Guid id)
    {
        await Task.Delay(500);
        
        return _patients.FirstOrDefault(x => x.Id == id);
    }
    
    public async Task<Patient> Add(Patient patient)
    {
        await Task.Delay(500);

        var created = Patient.Create(patient.Name, patient.Email, patient.TelephoneNumber);
        
        _patients.Add(created);

        return created;
    }
}