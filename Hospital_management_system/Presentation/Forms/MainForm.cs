using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;
using Hospital_management_system.Presentation.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Numerics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            //Thread.Sleep(500);
            await PreLoadDataAsync();
        };
        //this.Load += async (s, e) =>
        //{
        //    await PreLoadDataAsync();
        //};
        #region Button Click Events
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
        btnPatient.Click += (s, e) =>
        {
            ShowControl(() => _serviceProvider.GetRequiredService<PatientControl>());
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
        #endregion
    }
    #region Helper Methods
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
                var list = await repo.GetAllWithDepartments();
                return list.Select(x => x.ToDto()).ToList();
            });

            var doctorDtos = await Task.Run(async () =>
            {
                var repo = _serviceProvider.GetRequiredService<IDoctorRepository>();
                var list = await repo.GetAllWithStaffAsync();

                return list.Select(x => x.ToDto()).ToList();
            });

            GlobalState.DoctorsCodeList = new BindingList<string>([.. staffDtos
                .Where(s => s.Position == Position.Doctor.ToString())
                .Select(s => s.Code)]);

            //

            Invoke(() =>
            {
                //GlobalState.Departments = new BindingList<DepartmentDto>(deptDtos);
                //GlobalState.Staffs = new BindingList<StaffDto>(staffDtos);
                //GlobalState.Doctors = new BindingList<DoctorDto>(doctorDtos);

                GlobalState.AddItems<DepartmentDto>(deptDtos, GlobalState.Departments);
                GlobalState.AddItems<StaffDto>(staffDtos, GlobalState.Staffs);
                GlobalState.AddItems<DoctorDto>(doctorDtos, GlobalState.Doctors);
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion

    //private async Task PreLoadDataAsync()
    //{
    //    try
    //    {
    //        #region Departments
    //        var departments = await Task.Run(async () =>
    //        {
    //            var deptRepo = _serviceProvider
    //                .GetRequiredService<IGenericRepository<Department>>();
    //            return await deptRepo.GetAllAsync();
    //        });
    //        var deptDtos = departments.Select(d => d.ToDto()).ToList();
    //        GlobalState.AddItems<DepartmentDto>(deptDtos, GlobalState.Departments);

    //        //foreach (var department in departments)
    //        //{
    //        //    GlobalState.Departments.Add(department.ToDto());
    //        //}
    //        #endregion

    //        #region Staffs
    //        var staffs = await Task.Run(async () =>
    //        {
    //            var staffRepo = _serviceProvider
    //                .GetRequiredService<IStaffRepository>();
    //            return await staffRepo.GetAllWithDepartments();
    //        });
    //        var staffDtos = staffs.Select(s => s.ToDto()).ToList();
    //        GlobalState.AddItems<StaffDto>(staffDtos, GlobalState.Staffs);
    //        //foreach (var staff in staffs)
    //        //{
    //        //    GlobalState.Staffs.Add(staff.ToDto());
    //        //    if (staff.Position == "Doctor")
    //        //    {
    //        //        GlobalState.DoctorsCodeList.Add(staff.Code);
    //        //    }
    //        //}
    //        #endregion

    //        #region Doctors
    //        var doctors = await Task.Run(async () =>
    //        {
    //            var doctorRepo = _serviceProvider
    //                .GetRequiredService<IGenericRepository<Doctor>>();
    //            return await doctorRepo.GetAllAsync();
    //            //var doctorRepo = _serviceProvider
    //            //    .GetRequiredService<IDoctorRepository>();
    //            //return await doctorRepo.GetAllWithStaffAsync();
    //        });
    //        foreach (var doctor in doctors)
    //        {
    //            var staff = GlobalState.Staffs
    //                .First(s => s.StaffId == doctor.DoctorId);
    //            var department = GlobalState.Departments
    //                .First(d => d.DepartmentId == staff?.DepartmentId);
    //            staff.Department = department;
    //            doctor.Staff = staff.ToEntity();
    //            var doctorDto = doctor.ToDto();
    //        }
    //        //var doctorDtos = doctors.Select(d => d.ToDto()).ToList();
    //        var doctorDtos = doctors.Select(d =>
    //        {
    //            var staff = GlobalState.Staffs
    //                .First(s => s.StaffId == d.DoctorId);
    //            var department = GlobalState.Departments
    //                .First(d => d.DepartmentId == staff?.DepartmentId);
    //            staff.Department = department;
    //            d.Staff = staff.ToEntity();
    //            return d.ToDto();
    //        });
    //        GlobalState.AddItems<DoctorDto>(doctorDtos, GlobalState.Doctors);
    //        //foreach (var doctor in doctors)
    //        //{
    //        //    var staff = GlobalState.Staffs
    //        //        .First(s => s.StaffId == doctor.DoctorId);
    //        //    var department = GlobalState.Departments
    //        //        .First(d => d.DepartmentId == staff?.DepartmentId);
    //        //    staff.Department = department;
    //        //    doctor.Staff = staff.ToEntity();
    //        //    var doctorDto = doctor.ToDto();
    //        //    GlobalState.Doctors.Add(doctorDto);
    //        //}
    //        #endregion
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}
}
