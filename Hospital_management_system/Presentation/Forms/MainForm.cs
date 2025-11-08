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
        //this.HandleCreated += async (s, e) =>
        //{
        //    if (!DesignMode)
        //        await PreLoadDataAsync();
        //};

        this.Shown += async (s, e) =>
        {
            ShowControl(() => _serviceProvider.GetRequiredService<DashboardControl>());
            await PreLoadDataAsync();
        };
        //this.Load += async (s, e) =>
        //{
        //    await PreLoadDataAsync();
        //};

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
        btnStaff.Click += (s, e) =>
        {
            ShowControl(() => _serviceProvider.GetRequiredService<StaffControl>());
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
            #region Departments
            GlobalState.Departments.Clear();
            var departments = await Task.Run(async () =>
            {
                var deptRepo = _serviceProvider
                    .GetRequiredService<IGenericRepository<Department>>();
                return await deptRepo.GetAllAsync();
            });
            foreach (var department in departments)
            {
                GlobalState.Departments.Add(department.ToDto());
            }
            #endregion

            #region Staffs
            GlobalState.Staffs.Clear();
            var staffs = await Task.Run(async () =>
            {
                var staffRepo = _serviceProvider
                    .GetRequiredService<IStaffRepository>();
                return await staffRepo.GetAllWithDepartments();
            });
            foreach (var staff in staffs)
            {
                GlobalState.Staffs.Add(staff.ToDto());
            }
            #endregion
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
