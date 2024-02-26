using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorNow.Presentation.MobileApp.ViewModels;

namespace DoctorNow.Presentation.MobileApp.Views;

public partial class SettingsPage : BasePage
{
    public SettingsPage()
    {
        InitializeComponent();
        BindingContext = new SettingsViewModel();
    }

    public override void Build()
    {
        
    }
}