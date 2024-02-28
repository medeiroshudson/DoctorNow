using CommunityToolkit.Mvvm.Input;
using DoctorNow.Presentation.MobileApp.Views;

namespace DoctorNow.Presentation.MobileApp.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    [RelayCommand]
    private static void Logoff()
    {
        Shell.Current!.GoToAsync("//login");
    }
} 