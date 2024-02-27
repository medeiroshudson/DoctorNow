using DoctorNow.Presentation.MobileApp.ViewModels.Doctor;

namespace DoctorNow.Presentation.MobileApp.Views.Doctor;

public partial class DoctorPatientsPage : BasePage
{
    public DoctorPatientsPage(DoctorPatientViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}