using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DoctorNow.Presentation.MobileApp.Views;

namespace DoctorNow.Presentation.MobileApp.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    [RelayCommand]
    private static void Logoff()
    {
        Application.Current!.MainPage = new LoginPage();
    }
}