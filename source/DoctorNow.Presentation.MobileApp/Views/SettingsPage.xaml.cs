using DoctorNow.Presentation.MobileApp.ViewModels;

namespace DoctorNow.Presentation.MobileApp.Views;

public partial class SettingsPage : BasePage
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}