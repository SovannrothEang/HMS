using Hospital_management_system.Presentation.Common;
using Hospital_management_system.Application.Common;
using Hospital_management_system.Application.Commands.Doctors;
using Hospital_management_system.Application.Queries.Doctors;
using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class DoctorsControl : UserControl, IDisposable
{
    private readonly IMediator _mediator;
    private readonly BindingSource _bsDoctor = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private static bool IsNew = false;

    public DoctorsControl(IMediator mediator)
    {
        _mediator = mediator;

        #region UI
        InitializeComponent();
        LoadControlsConfiguration();
        dtpHireDate.Enabled = false;
        cmbDepartment.Enabled = false;
        DisableControls(true);
        #endregion

        _bsDoctor.DataSource = GlobalState.Doctors;
        dgvDoctor.DataSource = _bsDoctor;

        #region Events
        dgvDoctor.DataBindingComplete += (s, e) =>
        {
            if (dgvDoctor.Columns.Contains("colId"))
                dgvDoctor.Columns["colId"].Visible = false;
        };
        dgvDoctor.SelectionChanged += OnDgvDoctorSelectionChanged;
        dgvDoctor.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDoctor.Rows.Count) return;
            if (dgvDoctor.Rows[e.RowIndex].DataBoundItem is not DoctorDto doc) return;

            if (dgvDoctor.Columns[e.ColumnIndex].Name == "colFirstName")
                e.Value = doc.Staff?.FirstName;
            else if (dgvDoctor.Columns[e.ColumnIndex].Name == "colLastName")
                e.Value = doc.Staff?.LastName;
            else if (dgvDoctor.Columns[e.ColumnIndex].Name == "colDepartment")
                e.Value = doc.Staff?.Department?.Name;
        };
        tbSearch.KeyUp += OnTbSearchKeyUp;
        cmbCode.SelectedIndexChanged += (s, e) =>
        {
            var staffCode = cmbCode.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(staffCode)) return;

            var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == staffCode);
            if (staff == null) return;

            var department = GlobalState.Departments.FirstOrDefault(d => d.DepartmentId == staff.DepartmentId);
            if (department == null) return;

            cmbDepartment.Text = department.Name;
        };
        #endregion

        #region Button Events
        btnRefresh.Click += async (s, e) => await LoadDoctorsAsync();
        btnCancel.Click += (s, e) =>
        {
            if (IsNew)
            {
                if (cmbCode.SelectedIndex >= 0 ||
                    cmbSpecialization.SelectedIndex >= 0 ||
                    tbExperinse.Text != string.Empty ||
                    tbLicenseNumber.Text != string.Empty)
                {
                    var confirmResult = MessageBox.Show("Discard new doctor?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes) IsNew = false;
                }
                else IsNew = false;
            }
            
            if (!IsNew) OnDgvDoctorSelectionChanged(this, EventArgs.Empty);
            DisableControls(true);
        };
        btnUpdate.Click += (s, e) =>
        {
            if (dgvDoctor.CurrentRow == null) return;
            IsNew = false;
            DisableControls(false);
            cmbCode.Enabled = false;
            tbExperinse.Focus();
        };
        btnNew.Click += (s, e) =>
        {
            DisableControls(false);
            var doctorStaffIds = GlobalState.Doctors.Select(d => d.StaffId).ToList();
            cmbCode.DataSource = GlobalState.Staffs
                .Where(s => s.Position?.Name == "Doctor" && !doctorStaffIds.Contains(s.StaffId))
                .Select(s => s.Code).ToList();
            
            IsNew = true;
            cmbCode.SelectedIndex = -1;
            tbExperinse.Clear();
            tbLicenseNumber.Clear();
            cmbSpecialization.SelectedIndex = -1;
            cmbDepartment.Text = string.Empty;
            cmbCode.Focus();
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvDoctor.CurrentRow?.DataBoundItem is not DoctorDto doctor) return;

            var confirmResult = MessageBox.Show("Delete this doctor?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var result = await _mediator.SendAsync(new DeleteDoctorCommand(doctor.Code));
                if (result.IsSuccess) await LoadDoctorsAsync();
                else MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        btnSubmit.Click += async (s, e) =>
        {
            var code = cmbCode.Text;
            var specialization = cmbSpecialization.Text;
            var experience = int.TryParse(tbExperinse.Text, out var exp) ? exp : 0;
            var license = tbLicenseNumber.Text.Trim();
            
            Result result;
            if (IsNew)
            {
                var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code);
                if (staff == null) return;
                result = await _mediator.SendAsync(new CreateDoctorCommand(code, specialization, license, experience, staff.StaffId));
            }
            else
            {
                var doctor = dgvDoctor.CurrentRow?.DataBoundItem as DoctorDto;
                if (doctor == null) return;
                result = await _mediator.SendAsync(new UpdateDoctorCommand(doctor.DoctorId, doctor.Code, specialization, license, experience, false, doctor.StaffId));
            }

            if (result.IsSuccess)
            {
                await LoadDoctorsAsync();
                IsNew = false;
                DisableControls(true);
                MessageBox.Show("Operation successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };
        #endregion
    }

    private void LoadControlsConfiguration()
    {
        dgvDoctor.ApplyModernGridStyle();
        btnRefresh.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(52, 152, 219), System.Drawing.Color.White);
        btnNew.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(46, 204, 113), System.Drawing.Color.White);
        btnUpdate.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(241, 196, 15), System.Drawing.Color.White);
        btnDelete.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(231, 76, 60), System.Drawing.Color.White);
        btnSubmit.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(46, 204, 113), System.Drawing.Color.White);
        btnCancel.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(149, 165, 166), System.Drawing.Color.White);
        tlpInput?.ApplyModernInputStyles();
        tbSearch?.ApplyModernTextBoxStyle();

        
        
        
        cmbCode.DataSource = GlobalState.Staffs.Where(s => s.Position?.Name == "Doctor").Select(s => s.Code).ToList();
        cmbSpecialization.DataSource = Enum.GetValues(typeof(Specialization));
        cmbDepartment.DataSource = GlobalState.Departments;
        cmbDepartment.DisplayMember = "Name";
        
        dgvDoctor.AutoGenerateColumns = false;
        dgvDoctor.Columns.AddRange([
            new DataGridViewTextBoxColumn { Name = "colId", DataPropertyName = "DoctorId", Visible = false },
            new DataGridViewTextBoxColumn { Name = "colCode", HeaderText = "Code", DataPropertyName = "Code", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
            new DataGridViewTextBoxColumn { Name = "colFirstName", HeaderText = "First Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colLastName", HeaderText = "Last Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colSpecialization", HeaderText = "Specialization", DataPropertyName = "Specialization", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colLicenseNumber", HeaderText = "License", DataPropertyName = "LicenseNumber", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colYearsOfExperience", HeaderText = "Experience", DataPropertyName = "YearsOfExperience", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
            new DataGridViewTextBoxColumn { Name = "colDepartment", HeaderText = "Department", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }
        ]);
    }

    private void DisableControls(bool con)
    {
        cmbCode.Enabled = !con;
        tbLicenseNumber.Enabled = !con;
        tbExperinse.Enabled = !con;
        cmbSpecialization.Enabled = !con;
        btnCancel.Enabled = !con;
        btnSubmit.Enabled = !con;
        btnRefresh.Enabled = con;
        btnNew.Enabled = con;
        btnDelete.Enabled = con;
        btnUpdate.Enabled = con;
        dgvDoctor.Enabled = con;
    }

    private void OnDgvDoctorSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvDoctor.CurrentRow?.DataBoundItem is not DoctorDto doc) return;
        cmbCode.Text = doc.Code;
        tbExperinse.Text = doc.YearsOfExperience.ToString();
        tbLicenseNumber.Text = doc.LicenseNumber;
        if (Enum.TryParse<Specialization>(doc.Specialization, true, out var spec))
        {
            cmbSpecialization.SelectedItem = spec;
        }
        else
        {
            cmbSpecialization.SelectedIndex = -1;
        }
        if (doc.Staff?.Department != null) cmbDepartment.Text = doc.Staff.Department.Name;
        if (doc.Staff != null)
        {
            dtpHireDate.Value = doc.Staff.HiredDate < dtpHireDate.MinDate 
                ? dtpHireDate.MinDate 
                 : doc.Staff.HiredDate;
        }
    }

    private void OnTbSearchKeyUp(object? sender, KeyEventArgs e)
    {
        if (_searchTimer == null)
        {
            _searchTimer = new System.Windows.Forms.Timer { Interval = 150 };
            _searchTimer.Tick += (s, ev) => { _searchTimer.Stop(); PerformSearch(tbSearch.Text.Trim()); };
        }
        _searchTimer.Stop(); _searchTimer.Start();
    }

    private void PerformSearch(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) _bsDoctor.DataSource = GlobalState.Doctors;
        else _bsDoctor.DataSource = GlobalState.Doctors.Where(d => 
            (d.Staff?.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false) || 
            (d.Staff?.LastName.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false)).ToList();
        _bsDoctor.ResetBindings(false);
    }

    private async Task LoadDoctorsAsync()
    {
        dgvDoctor.Enabled = btnRefresh.Enabled = false;
        try
        {
            var doctors = await _mediator.SendAsync(new GetDoctorsQuery());
            GlobalState.Doctors.Clear();
            foreach (var d in doctors) GlobalState.Doctors.Add(d.ToDto());
            _bsDoctor.ResetBindings(false);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        finally { dgvDoctor.Enabled = btnRefresh.Enabled = true; }
    }

    public new void Dispose() { _searchTimer?.Dispose(); base.Dispose(); }
}
