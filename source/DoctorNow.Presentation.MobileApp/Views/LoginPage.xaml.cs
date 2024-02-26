using DoctorNow.Presentation.MobileApp.Views.Doctor;

namespace DoctorNow.Presentation.MobileApp.Views;

public partial class LoginPage : BasePage
{
    public LoginPage()
    {
        
    }

    public override void Build()
    {
        InitializeComponent();
    }

    private void OnClicked_Login(object sender, EventArgs e)
        => Application.Current!.MainPage = new NavigationPage(new DoctorTabbedPages());
}