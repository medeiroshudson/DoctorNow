using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorNow.Presentation.MobileApp.ViewModels.Doctor;

namespace DoctorNow.Presentation.MobileApp.Views.Doctor;

public partial class DoctorHomePage : BasePage
{
    public DoctorHomePage(DoctorHomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}