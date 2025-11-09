using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class DashboardControl: UserControl
{
    public DashboardControl()
    {
        InitializeComponent();
        

        GlobalState.DashboardUpdate += OnDataUpdated;
    }

    private void OnDataUpdated()
    {
        lbStaff.Text = GlobalState.Staffs.Count.ToString();
        lbDoctor.Text = GlobalState.Doctors.Count.ToString();
        this.Refresh();
    }
}
