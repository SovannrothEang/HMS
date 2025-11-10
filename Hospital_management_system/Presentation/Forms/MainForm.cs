using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;
using Hospital_management_system.Presentation.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Hospital_management_system;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private UserControl? _currentControl;
    private Button _activeButton = null!;
    public MainForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;

        this.Load += async (s, e) =>
        {
            ActivateControl(this.btnDashboard, () => _serviceProvider.GetRequiredService<DashboardControl>());
            await PreLoadDataAsync();
        };
        #region Button Click Events
        btnDashboard.Click += (s, e) =>
        {
            ActivateControl(this.btnDashboard, () => _serviceProvider.GetRequiredService<DashboardControl>());
        };
        btnDoctor.Click += (s, e) =>
        {
            ActivateControl(this.btnDoctor, () => _serviceProvider.GetRequiredService<DoctorControl>());
        };
        btnDepartment.Click += (s, e) =>
        {
            ActivateControl(this.btnDepartment, () => _serviceProvider.GetRequiredService<DepartmentControl>());
        };
        btnPatient.Click += (s, e) =>
        {
            ActivateControl(this.btnPatient, () => _serviceProvider.GetRequiredService<PatientControl>());
        };
        btnStaff.Click += (s, e) =>
        {
            ActivateControl(this.btnStaff, () => _serviceProvider.GetRequiredService<StaffControl>());
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
        #endregion
    }
    #region Helper Methods
    private void ActivateControl(Button btn, Func<UserControl> controlFactory)
    {
        ResetButtonStyle(_activeButton);
        SetButtonStyle(btn);

        _activeButton = btn;

        ShowControl(controlFactory);
    }
    private static void SetButtonStyle(Button btn)
    {
        btn.BackColor = Color.Black;
        btn.ForeColor = Color.White;
    }
    private static void ResetButtonStyle(Button? btn)
    {
        if (btn == null) return;

        btn.BackColor = Color.White;
        btn.ForeColor = Color.Black;
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
            var deptDtos = await Task.Run(async () =>
            {
                var repo = _serviceProvider.GetRequiredService<IGenericRepository<Department>>();
                var list = await repo.GetAllAsync();

                return list.Select(x => x.ToDto()).ToList();
            });

            var staffDtos = await Task.Run(async () =>
            {
                var repo = _serviceProvider.GetRequiredService<IStaffRepository>();
                var list = await repo.GetAllWithDepartmentsAsync();
                return list.Select(x => x.ToDto()).ToList();
            });

            var doctorDtos = await Task.Run(async () =>
            {
                var repo = _serviceProvider.GetRequiredService<IDoctorRepository>();
                var list = await repo.GetAllWithStaffsAsync();

                return list.Select(x => x.ToDto()).ToList();
            });

            var patientDto = await Task.Run(async () =>
            {
                var repo = _serviceProvider.GetRequiredService<IPatientRepository>();
                var list = await repo.GetAllWithDoctorAsync();

                return list.Select(x => x.ToDto()).ToList();
            });

            GlobalState.AllStaffDoctorsCodeList = new BindingList<string>([.. staffDtos
                .Where(s => s.Position == Position.Doctor.ToString())
                .Select(s => s.Code)]);

            GlobalState.DoctorsCodeList = new BindingList<string>([.. doctorDtos
                .Select(d => d.Staff.Code)]);

            Invoke(() =>
            {
                //GlobalState.Departments = new BindingList<DepartmentDto>(deptDtos);
                //GlobalState.Staffs = new BindingList<StaffDto>(staffDtos);
                //GlobalState.Doctors = new BindingList<DoctorDto>(doctorDtos);

                GlobalState.AddItems<DepartmentDto>(deptDtos, GlobalState.Departments);
                GlobalState.AddItems<StaffDto>(staffDtos, GlobalState.Staffs);
                GlobalState.AddItems<DoctorDto>(doctorDtos, GlobalState.Doctors);
                GlobalState.AddItems<PatientDto>(patientDto, GlobalState.Patients);
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion
}
