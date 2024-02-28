using DoctorNow.Presentation.MobileApp.ViewModels.Doctor;

namespace DoctorNow.Presentation.MobileApp.Views.Doctor;

public partial class DoctorPatientDetailsPage : BasePage
{
    public DoctorPatientDetailsPage(DoctorPatientDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}