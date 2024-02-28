using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using DoctorNow.Presentation.MobileApp.Services.Abstractions;
using DoctorNow.Presentation.MobileApp.Services.Implementations;
using DoctorNow.Presentation.MobileApp.ViewModels;
using DoctorNow.Presentation.MobileApp.ViewModels.Doctor;
using DoctorNow.Presentation.MobileApp.Views;
using DoctorNow.Presentation.MobileApp.Views.Doctor;

namespace DoctorNow.Presentation.MobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.UseMauiApp<App>()
                .UseFonts()
                .UseMauiCommunityToolkit();

            builder.Services.AddSingleton<AppShell>();

            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginViewModel>();
            
            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddSingleton<SettingsViewModel>();
            
            builder.Services.AddSingleton<DoctorHomePage>();
            builder.Services.AddSingleton<DoctorHomeViewModel>();
            
            builder.Services.AddSingleton<DoctorPatientsPage>();
            builder.Services.AddSingleton<DoctorPatientsViewModel>();

            builder.Services.AddTransient<DoctorPatientDetailsPage>();
            builder.Services.AddTransient<DoctorPatientDetailsViewModel>();

            builder.Services.AddSingleton<IPatientService, PatientService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder UseFonts(this MauiAppBuilder builder)
        {
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("Montserrat-Medium.ttf", "RegularFont");
                fonts.AddFont("Montserrat-SemiBold.ttf", "MediumFont");
                fonts.AddFont("Montserrat-Bold.ttf", "BoldFont");
            });

            return builder;
        }
    }
}
