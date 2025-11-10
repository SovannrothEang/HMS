using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class DashboardControl: UserControl
{
    public DashboardControl()
    {
        InitializeComponent();
        
        GlobalState.DataUpdated += OnDataUpdated;
    }

    private void OnDataUpdated()
    {
        lbStaff.Text = GlobalState.CurrentStaffs.ToString();
        lbDoctor.Text = GlobalState.CurrentDoctors.ToString();
        lbPatient.Text = GlobalState.CurrentPatients.ToString();
        this.Refresh();
    }
}
