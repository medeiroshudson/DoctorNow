using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DoctorNow.Presentation.MobileApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _email;
    
    [ObservableProperty]
    private string? _password;

    [RelayCommand]
    private static void Authenticate()
    {
        Application.Current!.MainPage = new AppShell();
    }
}