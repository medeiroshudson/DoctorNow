using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DoctorNow.Presentation.MobileApp.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    [RelayCommand]
    private static async Task Logoff()
    {
        await Shell.Current!.GoToAsync("//login");
    }
} 