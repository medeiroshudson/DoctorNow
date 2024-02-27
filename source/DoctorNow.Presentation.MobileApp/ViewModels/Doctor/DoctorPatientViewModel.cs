using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DoctorNow.Presentation.MobileApp.Services.Abstractions;

namespace DoctorNow.Presentation.MobileApp.ViewModels.Doctor;

public partial class DoctorPatientViewModel(IPatientService patientService) 
    : BaseViewModel
{
    [RelayCommand]
    private void Load()
    {
        var entities= patientService.GetAll();
    }
}