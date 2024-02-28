using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DoctorNow.Domain.Patients;
using DoctorNow.Presentation.MobileApp.Services.Abstractions;

namespace DoctorNow.Presentation.MobileApp.ViewModels.Doctor;

[QueryProperty(nameof(Patient.Id), nameof(Patient.Id))]
public partial class DoctorPatientDetailsViewModel(IPatientService patientService) 
    : BaseViewModel
{
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty] 
    private string? _id;

    [ObservableProperty] 
    private Patient _patient;
    
    [RelayCommand] 
    private async Task LoadData()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            var guidId = Guid.Parse(Id!);
            Patient = await patientService.GetById(guidId);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception);
            
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to get {nameof(Patient)}: {exception.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private static async Task GoBack()
        => await Shell.Current!.GoToAsync("..");
}