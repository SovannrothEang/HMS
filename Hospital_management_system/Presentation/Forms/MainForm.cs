using Hospital_management_system.Presentation.UserControls;

namespace Hospital_management_system;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        this.Load += (s, e) =>
        {
            mainPanel.Controls.Clear();
            var dashboard = new DashboardControl();
            mainPanel.Controls.Add(dashboard);
        };
        btnDashboard.Click += (s, e) =>
        {
            mainPanel.Controls.Clear();

            var form = new DashboardControl();
            mainPanel.Controls.Add(form);
        };
        btnDoctor.Click += (s, e) =>
        {
            mainPanel.Controls.Clear();

            var form = new DoctorControl();
            mainPanel.Controls.Add(form);
        };
        btnExit.Click += (s, e) =>
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        };
    }
}
