using Hospital_management_system.Presentation.Common;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class DashboardControl : UserControl
{
    public DashboardControl()
    {
        InitializeComponent();
        SetupGrids();
        
        GlobalState.DataUpdated += OnDataUpdated;
        this.Load += (s, e) =>
        {
            OnDataUpdated();
        };
    }

    private void SetupGrids()
    {
        // Setup Patients Grid
        dgvRecentPatients.AutoGenerateColumns = false;
        dgvRecentPatients.Columns.Clear();
        dgvRecentPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Code", HeaderText = "Code", Width = 80 });
        dgvRecentPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FirstName", HeaderText = "First Name", Width = 150 });
        dgvRecentPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LastName", HeaderText = "Last Name", Width = 150 });
        dgvRecentPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", HeaderText = "Gender", Width = 100 });
        dgvRecentPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Sickness", HeaderText = "Sickness", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

        // Setup Departments Grid
        dgvDepartments.AutoGenerateColumns = false;
        dgvDepartments.Columns.Clear();
        dgvDepartments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Code", HeaderText = "Code", Width = 80 });
        dgvDepartments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
    }

    private void OnDataUpdated()
    {
        if (InvokeRequired)
        {
            Invoke(new Action(OnDataUpdated));
            return;
        }

        // Update Total Labels
        lblTotalStaffs.Text = GlobalState.Staffs.Count.ToString();
        lblTotalDoctors.Text = GlobalState.Doctors.Count.ToString();
        lblTotalPatients.Text = GlobalState.Patients.Count.ToString();
        lblTotalDepartments.Text = GlobalState.Departments.Count.ToString();

        // Update Data Grids
        var recentPatients = GlobalState.Patients.OrderByDescending(p => p.PatientId).Take(15).ToList();
        dgvRecentPatients.DataSource = new BindingList<PatientDto>(recentPatients);

        var topDepartments = GlobalState.Departments.OrderBy(d => d.DepartmentId).Take(15).ToList();
        dgvDepartments.DataSource = new BindingList<DepartmentDto>(topDepartments);
    }
}
