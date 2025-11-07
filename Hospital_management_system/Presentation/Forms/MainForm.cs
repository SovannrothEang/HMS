using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Presentation.State;
using Hospital_management_system.Presentation.UserControls;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_management_system;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private UserControl? _currentControl;
    public MainForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;

        // Preload data


        this.Shown += (s, e) =>
        {
            ShowControl(() => _serviceProvider.GetRequiredService<DashboardControl>());
        };
        //this.HandleCreated += async (s, e) =>
        //{
        //    if (!DesignMode)
        //        await PreLoadDataAsync();
        //};
        PreLoadDataAsync().ConfigureAwait(false);
        btnDashboard.Click += (s, e) =>
        {
            ShowControl(() => _serviceProvider.GetRequiredService<DashboardControl>());
        };
        btnDoctor.Click += (s, e) =>
        {
            ShowControl(() => _serviceProvider.GetRequiredService<DoctorControl>());
        };
        btnDepartment.Click += (s, e) =>
        {
            ShowControl(() => _serviceProvider.GetRequiredService<DepartmentControl>());
        };
        btnExit.Click += (s, e) =>
        {
            var confirmResult = MessageBox.Show("Are you sure you want to exit?",
                        "Confirm Exit",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        };
    }

    private void ShowControl(Func<UserControl> controlFactory)
    {
        try
        {
            // Remove current control
            if (_currentControl != null)
            {
                this.Controls.Remove(_currentControl);
                _currentControl.Dispose();
                _currentControl = null;
            }

            // Create and show new control
            var control = controlFactory();
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
            _currentControl = control;

            // Update status
            //var statusLabel = (ToolStripStatusLabel)this.statusStrip.Items[0];
            //statusLabel.Text = $"Ready - {control.GetType().Name.Replace("Control", "")} Management";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading control: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task PreLoadDataAsync()
    {
        try
        {
            GlobalState.Departments.Clear();
            var deptRepo = _serviceProvider
                .GetRequiredService<IGenericRepository<Department>>();
            GlobalState.Departments.AddRange(
                (await deptRepo.GetAllAsync())
                .Select(d => d.ToDto()));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
