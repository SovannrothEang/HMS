using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class DashboardControl: UserControl
{
    public DashboardControl()
    {
        InitializeComponent();
        
        GlobalState.DataUpdated += OnDataUpdated;
        //this.Load += (s, e) =>
        //{
        //    OnDataUpdated();
        //};
    }

    private void OnDataUpdated()
    {
        lbStaff.Text = GlobalState.Staffs.Count.ToString();
        lbDoctor.Text = GlobalState.Doctors.Count.ToString();
        lbPatient.Text = GlobalState.Patients.Count.ToString();
        //this.Refresh();
        lbStaff.Refresh();
        lbDoctor.Refresh();
        lbPatient.Refresh();
    }
}
