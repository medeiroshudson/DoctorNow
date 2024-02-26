using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorNow.Presentation.MobileApp.Views;

public partial class SettingsPage : BasePage
{
    public SettingsPage()
    {
    }

    public override void Build()
    {
        InitializeComponent();
    }

    private void OnClicked_Logout(object sender, EventArgs e)
        => Application.Current!.MainPage = new NavigationPage(new LoginPage());
}