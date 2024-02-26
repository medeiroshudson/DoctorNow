using DoctorNow.Presentation.MobileApp.ViewModels;

namespace DoctorNow.Presentation.MobileApp.Views;

public partial class LoginPage : BasePage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }

    public override void Build()
    {
        
    }
}