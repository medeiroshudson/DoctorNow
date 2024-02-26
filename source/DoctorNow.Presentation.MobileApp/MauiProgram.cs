using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using DoctorNow.Presentation.MobileApp.Services.Abstractions;
using DoctorNow.Presentation.MobileApp.Services.Implementations;
using DoctorNow.Presentation.MobileApp.ViewModels;
using DoctorNow.Presentation.MobileApp.ViewModels.Doctor;

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
            
            builder.Services.AddSingleton<DoctorPatientViewModel>();
            
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
