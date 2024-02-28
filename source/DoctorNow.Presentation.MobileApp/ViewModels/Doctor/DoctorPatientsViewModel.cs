using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DoctorNow.Domain.Patients;
using DoctorNow.Presentation.MobileApp.Services.Abstractions;
using DoctorNow.Presentation.MobileApp.Views.Doctor;

namespace DoctorNow.Presentation.MobileApp.ViewModels.Doctor;

public partial class DoctorPatientsViewModel(IPatientService patientService) 
    : BaseViewModel
{
    [ObservableProperty]
    private bool _isBusy;
    
    [ObservableProperty]
    private ObservableCollection<Patient> _patients = [];
    
    [RelayCommand] 
    private async Task LoadData()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            var entities = await patientService.GetAll();

            if (Patients.Count != 0) Patients.Clear();

            foreach (var entity in entities)
                Patients.Add(entity);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception);
            
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to get {nameof(Patients)}: {exception.Message}", "OK");

            await Shell.Current.GoToAsync(nameof(DoctorPatientsPage));
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private static async Task Details(Guid id)
    {
        try
        {
            await Shell.Current!.GoToAsync($"{nameof(DoctorPatientDetailsPage)}?Id={id}");
        }
        catch (Exception exception)
        {
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to get {nameof(Patients)}: {exception.Message}", "OK");
            
            await Shell.Current.GoToAsync(nameof(DoctorPatientsPage));
        }
    }
}