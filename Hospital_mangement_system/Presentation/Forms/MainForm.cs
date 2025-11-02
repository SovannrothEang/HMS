using Hospital_mangement_system.Presentation.UserControls;

namespace Hospital_mangement_system;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        this.Load += (s, e) =>
        {
            panelBody.Controls.Clear();
            var dashboard = new Dashboard();
            panelBody.Controls.Add(dashboard);
        };
        btnDashboard.Click += (s, e) =>
        {
            panelBody.Controls.Clear();

            var form = new Dashboard();
            panelBody.Controls.Add(form);
        };
        btnDoctor.Click += (s, e) =>
        {
            panelBody.Controls.Clear();

            var form = new Doctor();
            panelBody.Controls.Add(form);
        };
    }
}
