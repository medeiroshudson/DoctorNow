using DoctorNow.Presentation.MobileApp.Views;
using DoctorNow.Presentation.MobileApp.Views.Doctor;

namespace DoctorNow.Presentation.MobileApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        
        Routing.RegisterRoute(nameof(DoctorHomePage), typeof(DoctorHomePage));
        Routing.RegisterRoute(nameof(DoctorPatientsPage), typeof(DoctorPatientsPage));
        Routing.RegisterRoute(nameof(DoctorPatientDetailsPage), typeof(DoctorPatientDetailsPage));
    }
}