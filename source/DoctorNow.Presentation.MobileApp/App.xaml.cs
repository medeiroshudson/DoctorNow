using DoctorNow.Presentation.MobileApp.Views;

namespace DoctorNow.Presentation.MobileApp
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = serviceProvider.GetRequiredService<LoginPage>();
        }
    }
}
