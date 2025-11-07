using Hospital_management_system.Application.DTO;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class StaffControl : UserControl
{
    private readonly IGenericRepository<Staff> _repo;
    private readonly BindingSource _bsStaffs = [];

    private static bool IsNew = false;
    public StaffControl(IGenericRepository<Staff> repo)
    {
        _repo = repo;
        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);
        
        _bsStaffs.DataSource = GlobalState.Staffs;
        dgvStaff.DataSource = _bsStaffs;

        //this.Load += async (s, e) =>
        //{
        //    await LoadStaffsAsync();
        //};
        btnNew.Click += (s, e) =>
        {
            IsNew = true;
            DisableControls(false);
        };
    }
    #region UI config
    private void LoadControlsConfiguration()
    {
        cmbGender.DataSource = Enum.GetValues(typeof(Gender));
        cmbGender.DisplayMember = "ToString";
        cmbGender.SelectedIndex = 0;

        cmbPosition.DataSource = Enum.GetValues(typeof(Position));
        cmbPosition.DisplayMember = "ToString";
        cmbPosition.SelectedIndex = 0;

        cmbDepartment.DataSource = GlobalState.Departments;
        cmbDepartment.DisplayMember = "Name";
        cmbDepartment.ValueMember = "DepartmentId";
        cmbDepartment.SelectedIndex = 0;

        dgvStaff.AutoGenerateColumns = false;
        #region Columns
        dgvStaff.Columns.AddRange([
            new DataGridViewTextBoxColumn {
                Name = "colId",
                DataPropertyName = "StaffId",
                Visible = false
            },
            new DataGridViewTextBoxColumn {
                Name = "colCode",
                HeaderText = "Code",
                DataPropertyName = "Code",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colFirstName",
                HeaderText = "First Name",
                DataPropertyName = "FirstName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            },
            new DataGridViewTextBoxColumn {
                Name = "colLastName",
                HeaderText = "Last Name",
                DataPropertyName = "LastName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            },
            new DataGridViewTextBoxColumn {
                Name = "colGender",
                HeaderText = "Gender",
                DataPropertyName = "Gender",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colDob",
                HeaderText = "Date of birth",
                DataPropertyName = "DOB",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colPhone",
                HeaderText = "Phone Number",
                DataPropertyName = "PhoneNumber",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colAddress",
                HeaderText = "Address",
                DataPropertyName = "Address",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colPosition",
                HeaderText = "Position",
                DataPropertyName = "Position",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colSalary",
                HeaderText = "Salary",
                DataPropertyName = "Salary",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colDepartment",
                HeaderText = "Department",
                DataPropertyName = "Department",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            //new DataGridViewTextBoxColumn {
            //    Name = "colCreatedAt",
            //    HeaderText = "Created At",
            //    DataPropertyName = "CreatedAt",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //},
            //new DataGridViewTextBoxColumn {
            //    Name = "colUpdatedAt",
            //    HeaderText = "Updated At",
            //    DataPropertyName = "UpdatedAt",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //}
        ]);
        #endregion
    }
    private void DisableControls(bool con)
    {
        tbCode.Enabled = !con;
        tbFirstName.Enabled = !con;
        tbLastName.Enabled = !con;
        cmbGender.Enabled = !con;
        dtpDob.Enabled = !con;
        tbPhoneNumber.Enabled = !con;
        tbAddress.Enabled = !con;
        tbEmail.Enabled = !con;
        cmbPosition.Enabled = !con;
        tbSalary.Enabled = !con;
        cmbDepartment.Enabled = !con;
    }
    private void ClearControls()
    {
        tbCode.Clear();
        tbFirstName.Clear();
        tbLastName.Clear();
        cmbGender.SelectedIndex = 0;
        //dtpDob.Clear();
        tbPhoneNumber.Clear();
        tbAddress.Clear();
        tbEmail.Clear();
        cmbPosition.SelectedIndex = 0;
        tbSalary.Clear();
        cmbDepartment.SelectedIndex = 0;
    }
    #endregion

    #region Events
    private void OnSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvStaff.CurrentRow == null) return;

        if (dgvStaff.CurrentRow.DataBoundItem is StaffDto selectedStaff)
        {
            tbCode.Text = selectedStaff.Code;
            tbFirstName.Text = selectedStaff.Firstname;
            tbLastName.Text = selectedStaff.Lastname;
            cmbGender.Text = selectedStaff.Gender.ToString();
            dtpDob.Text = selectedStaff.DOB.ToString();
            tbPhoneNumber.Text = selectedStaff.PhoneNumber;
            tbAddress.Text = selectedStaff.Address;
            tbEmail.Text = selectedStaff.Email;
            cmbPosition.Text = selectedStaff.Position.ToString();
            tbSalary.Text = selectedStaff.Salary.ToString();
            cmbDepartment.Text = selectedStaff.DepartmentId;
        }
    }
    #endregion
    private async Task LoadStaffsAsync()
    {
        dgvStaff.Enabled = false;
        try
        {
            var staffs = await _repo.GetAllAsync();

            GlobalState.Staffs.Clear();
            foreach (var staff in staffs)
            {
                GlobalState.Staffs.Add(staff.ToDto());
            }
            _bsStaffs.ResetBindings(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading staffs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            dgvStaff.Enabled = true;
        }
    }
}
