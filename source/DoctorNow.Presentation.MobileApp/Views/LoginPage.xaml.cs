using DoctorNow.Presentation.MobileApp.Pages;
using DoctorNow.Presentation.MobileApp.ViewModels;

namespace DoctorNow.Presentation.MobileApp.Views;

public partial class LoginPage : BasePage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}