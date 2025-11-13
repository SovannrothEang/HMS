using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.Forms;
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
            this.Opacity = 0;
            await PreLoadDataAsync();
            if (!CheckUser())
                return;
            this.Opacity = 1;
            ActivateControl(this.btnDashboard, () => _serviceProvider.GetRequiredService<DashboardControl>());
        };

        #region Button Click Events
        btnDashboard.Click += (s, e) =>
        {
            ActivateControl(this.btnDashboard, () => _serviceProvider.GetRequiredService<DashboardControl>());
        };
        btnDoctor.Click += (s, e) =>
        {
            ActivateControl(this.btnDoctor, () => _serviceProvider.GetRequiredService<DoctorsControl>());
        };
        btnDepartment.Click += (s, e) =>
        {
            ActivateControl(this.btnDepartment, () => _serviceProvider.GetRequiredService<DepartmentsControl>());
        };
        btnPatient.Click += (s, e) =>
        {
            ActivateControl(this.btnPatient, () => _serviceProvider.GetRequiredService<PatientsControl>());
        };
        btnStaff.Click += (s, e) =>
        {
            ActivateControl(this.btnStaff, () => _serviceProvider.GetRequiredService<StaffsControl>());
        };
        btnUser.Click += (s, e) =>
        {
            ActivateControl(this.btnUser, () => _serviceProvider.GetRequiredService<UsersControl>());
        };
        btnLogout.Click += (s, e) =>
        {
            var confirmResult = MessageBox.Show("Are you sure you want to logout?",
                        "Confirm Logout",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                GlobalState.CurrentUsername = string.Empty;
                if (!CheckUser())
                    return;
            }
        };
        #endregion
    }

    #region Helper Methods
    private bool CheckUser()
    {
        if (!string.IsNullOrEmpty(GlobalState.CurrentUsername))
            return true;

        this.Hide();
        using (var login = _serviceProvider.GetRequiredService<LoginForm>())
        {
            bool success = false;
            login.LoginSucceeded += (s, e) => success = true;
            login.FormClosed += (s, e) =>
            {
                if (string.IsNullOrEmpty(GlobalState.CurrentUsername))
                    this.Close();
            };
            login.ShowDialog();
            if (!success)
            {
                System.Windows.Forms.Application.Exit();
                return false;
            }
        }
        lbUsername.Text = GlobalState.CurrentUsername;
        this.Show();
        return true;
    }
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
            var deptRepo = _serviceProvider.GetRequiredService<IGenericRepository<Department>>();
            var staffRepo = _serviceProvider.GetRequiredService<IStaffRepository>();
            var docRepo = _serviceProvider.GetRequiredService<IDoctorRepository>();
            var patientRepo = _serviceProvider.GetRequiredService<IPatientRepository>();
            var userRepo = _serviceProvider.GetRequiredService<IUserRepository>();

            var deptList = await deptRepo.GetAllAsync();
            var staffList = await staffRepo.GetAllWithDepartmentsAsync();
            var docList = await docRepo.GetAllWithStaffsAsync();
            var patientList = await patientRepo.GetAllWithDoctorAsync();
            var userList = await userRepo.GetAllWithStaffAsync();

            var deptDtos = deptList.Select(x => x.ToDto()).ToList();
            var staffDtos = staffList.Select(x => x.ToDto()).ToList();
            var doctorDtos = docList.Select(x => x.ToDto()).ToList();
            var patientDtos = patientList.Select(x => x.ToDto()).ToList();
            var userDtos = userList.Select(x => x.ToDto()).ToList();

            GlobalState.AllStaffDoctorsCodeList = new BindingList<string>([.. staffDtos
                .Where(s => s.Position == Position.Doctor.ToString())
                .Select(s => s.Code)]);

            GlobalState.DoctorsCodeList = new BindingList<string>([.. doctorDtos
                .Select(d => d.Staff.Code)]);

            GlobalState.AddItems<DepartmentDto>(deptDtos, GlobalState.Departments);
            GlobalState.AddItems<StaffDto>(staffDtos, GlobalState.Staffs);
            GlobalState.AddItems<DoctorDto>(doctorDtos, GlobalState.Doctors);
            GlobalState.AddItems<PatientDto>(patientDtos, GlobalState.Patients);
            GlobalState.AddItems<UserDto>(userDtos, GlobalState.Users);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion
}
