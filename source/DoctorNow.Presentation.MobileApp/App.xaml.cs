using DoctorNow.Presentation.MobileApp.Views;

namespace DoctorNow.Presentation.MobileApp
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }
    }
}
