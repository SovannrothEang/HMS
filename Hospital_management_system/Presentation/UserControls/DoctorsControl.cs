using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class DoctorsControl : UserControl
{
    private readonly IGenericRepository<Doctor> _repo;
    private readonly IDoctorRepository _docRepo;
    private readonly BindingSource _bsDoctor = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private static bool IsNew = false;

    public DoctorsControl(IGenericRepository<Doctor> repo, IDoctorRepository docRepo)
    {
        _repo = repo;
        _docRepo = docRepo;

        #region UI
        InitializeComponent();
        LoadControlsConfiguration();
        dtpHireDate.Enabled = false;
        cmbDepartment.Enabled = false;
        DisableControls(true);
        #endregion

        _bsDoctor.DataSource = GlobalState.Doctors;
        dgvDoctor.DataSource = _bsDoctor;
        _bsDoctor.ResetBindings(false);

        #region Events
        dgvDoctor.DataBindingComplete += (s, e) =>
        {
            if (dgvDoctor.Columns.Contains("colId"))
                dgvDoctor.Columns["colId"].Visible = false;
        };
        dgvDoctor.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDoctor.Rows.Count) return;
            var row = dgvDoctor.Rows[e.RowIndex];
            if (row == null) return;

            if (row.DataBoundItem is not DoctorDto doctor) return;

            if (dgvDoctor.Columns.Contains("colCode"))
                row.Cells["colCode"].Value = doctor.Staff?.Code ?? string.Empty;
            if (dgvDoctor.Columns.Contains("colFirstName"))
                row.Cells["colFirstName"].Value = doctor.Staff?.FirstName ?? string.Empty;
            if (dgvDoctor.Columns.Contains("colLastName"))
                row.Cells["colLastName"].Value = doctor.Staff?.LastName ?? string.Empty;
            if (dgvDoctor.Columns.Contains("colDepartment"))
                row.Cells["colDepartment"].Value = doctor.Staff?.Department?.Name ?? string.Empty;
        };
        dgvDoctor.SelectionChanged += OnDgvDoctorSelectionChanged;
        tbSearch.KeyUp += OnTbSearchKeyUp;
        cmbCode.SelectedIndexChanged += (s, e) =>
        {
            var staffCode = cmbCode.SelectedValue;
            if (staffCode is null) return;

            var staff = GlobalState.Staffs
                .FirstOrDefault(s => s.Code == staffCode.ToString());
            var department = GlobalState.Departments
                .FirstOrDefault(d => d.DepartmentId == staff!.DepartmentId);
            cmbDepartment.Text = department!.Name.ToString();
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
                    cmbDepartment.SelectedIndex >= 0 ||
                    tbExperinse.Text != string.Empty ||
                    tbLicenseNumber.Text != string.Empty)
                {
                    var confirmResult = MessageBox.Show("Discard new doctor?",
                        "Confirm Cancel",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        IsNew = false;
                        if (dgvDoctor.CurrentRow != null)
                        {
                            OnDgvDoctorSelectionChanged(this, EventArgs.Empty);
                        }
                    }
                }
                else
                {
                    IsNew = false;
                    if (dgvDoctor.CurrentRow != null)
                    {
                        OnDgvDoctorSelectionChanged(this, EventArgs.Empty);
                    }
                }
            }

            cmbCode.DataSource = GlobalState.AllStaffDoctorsCodeList;
            DisableControls(true);
        };
        btnUpdate.Click += (s, e) =>
        {
            DisableControls(false);

            cmbCode.Enabled = false;
            var dto = dgvDoctor.CurrentRow.DataBoundItem as DoctorDto;
            cmbCode.Text = dto!.Staff!.Code.ToString();

            IsNew = false;
            cmbCode.Focus();
        };
        btnNew.Click += (s, e) =>
        {
            DisableControls(false);

            var unassignedDoctors = GlobalState.Staffs
                .Where(s => s.Position == Position.Doctor.ToString() &&
                            !GlobalState.Doctors.Any(d => d.StaffId == s.StaffId))
                .Select(s => s.Code)
                .ToList();

            cmbCode.DataSource = unassignedDoctors;

            IsNew = true;
            cmbCode.SelectedIndex = -1;
            tbExperinse.Clear();
            tbLicenseNumber.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbSpecialization.SelectedIndex = -1;
            dtpHireDate.Value = DateTime.Now;
            cmbCode.Focus();
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvDoctor.CurrentRow == null) return;
            var id = dgvDoctor.CurrentRow.Cells["colId"].Value!.ToString()!;
            var confirmResult = MessageBox.Show("Are you sure to delete this doctor?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var patients = GlobalState.Patients.Where(p => p.DoctorId == id).ToList();
                if (patients.Count > 0)
                { 
                    MessageBox.Show(
                        "There are patients in care of this doctors",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                try
                {
                    var success = await _repo.DeleteAsync(id);
                    if (success)
                    {
                        var doctor = GlobalState.Doctors
                            .FirstOrDefault(x => x.DoctorId == id);
                        if (doctor != null)
                        {
                            GlobalState.Doctors.Remove(doctor);
                            var doctorCode = GlobalState.DoctorsCodeList.FirstOrDefault(d => d == doctor.Staff.Code);
                            if (doctorCode != null)
                                GlobalState.DoctorsCodeList.Remove(doctorCode);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the staff.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _bsDoctor.ResetBindings(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting staff: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };
        btnSubmit.Click += async (s, e) =>
        {
            if (IsNew)
            {
                try
                {
                    if (await CreateDoctorAsync())
                    {
                        MessageBox.Show(
                            "Successfully created",
                            "Create doctor",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Failed to create doctor",
                            "Create doctor",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    OnDgvDoctorSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to create, error: {ex.Message}",
                        "Create doctor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                try
                {
                    var id = dgvDoctor.CurrentRow!.Cells["colId"].Value!.ToString()!;
                    if (await UpdateDoctorAsync(id))
                    {
                        MessageBox.Show(
                            "Successfully created",
                            "Update doctor",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Failed to update doctor",
                            "Update doctor",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                catch (Exception ex)
                {
                    OnDgvDoctorSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to update, error: {ex.Message}",
                        "Update doctor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }

            cmbCode.DataSource = GlobalState.AllStaffDoctorsCodeList;
            OnDgvDoctorSelectionChanged(this, EventArgs.Empty);
            DisableControls(true);
        };
        #endregion
    }

    #region UI config
    private void LoadControlsConfiguration()
    {
        dgvDoctor.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dgvDoctor.DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);

        cmbCode.DataSource = GlobalState.AllStaffDoctorsCodeList.ToList();

        dtpHireDate.Format = DateTimePickerFormat.Custom;
        dtpHireDate.CustomFormat = "dd/MM/yyyy";

        cmbSpecialization.DataSource = Enum.GetValues(typeof(Specialization));
        cmbSpecialization.SelectedIndex = -1;
        //cmbSpecialization.ValueMember = 

        cmbDepartment.DataSource = GlobalState.Departments;
        cmbDepartment.DisplayMember = "Name";
        cmbDepartment.ValueMember = "DepartmentId";
        cmbDepartment.SelectedIndex = -1;

        dgvDoctor.AutoGenerateColumns = false;

        #region Columns
        dgvDoctor.Columns.AddRange([
            new DataGridViewTextBoxColumn {
                Name = "colId",
                DataPropertyName = "DoctorId",
                Visible = false
            },
            new DataGridViewTextBoxColumn {
                Name = "colCode",
                HeaderText = "Code",
                DataPropertyName = "Staff.Code",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colFirstName",
                HeaderText = "First Name",
                DataPropertyName = "Staff.FirstName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            },
            new DataGridViewTextBoxColumn {
                Name = "colLastName",
                HeaderText = "Last Name",
                DataPropertyName = "Staff.LastName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            },
            new DataGridViewTextBoxColumn {
                Name = "colSpecialization",
                HeaderText = "Specialization",
                DataPropertyName = "Specialization",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colLicenseNumber",
                HeaderText = "License Number",
                DataPropertyName = "LicenseNumber",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            },
            new DataGridViewTextBoxColumn {
                Name = "colYearsOfExperience",
                HeaderText = "Experience",
                DataPropertyName = "YearsOfExperience",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colDepartment",
                HeaderText = "Department",
                DataPropertyName = "Staff.Department.Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            }
        ]);
        #endregion
    }
    private void DisableControls(bool con)
    {
        //controlPanel.Enabled = !con;
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
    }
    #endregion

    #region Events
    private void OnDgvDoctorSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvDoctor.CurrentRow == null) return;

        if (dgvDoctor.CurrentRow.DataBoundItem is DoctorDto selectedDoctor)
        {
            if (selectedDoctor.Staff is null || selectedDoctor.Staff!.Department is null)
            {
                var staffCode = cmbCode.SelectedValue;
                if (staffCode is null) return;

                var staff = GlobalState.Staffs
                    .FirstOrDefault(s => s.Code == staffCode.ToString());
                if (staff is null) return;
                selectedDoctor.Staff = staff;
                var department = GlobalState.Departments
                    .FirstOrDefault(d => d.DepartmentId == staff.DepartmentId);
                if (department is null) return;
                selectedDoctor.Staff.Department = department;
            }
            cmbCode.Text = selectedDoctor.Staff.Code;
            tbExperinse.Text = selectedDoctor.YearsOfExperience.ToString();
            tbLicenseNumber.Text = selectedDoctor.LicenseNumber.ToString();
            cmbSpecialization.Text = selectedDoctor.Specialization;
            cmbDepartment.Text = selectedDoctor.Staff.Department.Name;

            dtpHireDate.Value = selectedDoctor.Staff.HiredDate < dtpHireDate.MinDate
                ? dtpHireDate.MinDate
                : selectedDoctor.Staff.HiredDate;
        }
    }
    private void OnTbSearchKeyUp(object? sender, KeyEventArgs e)
    {
        if (_searchTimer == null)
        {
            _searchTimer = new System.Windows.Forms.Timer();
            _searchTimer.Interval = 150;
            _searchTimer.Tick += (s, ev) =>
            {
                _searchTimer.Stop();
                PerformSearch(tbSearch.Text.Trim());
            };
        }

        // restart debounce timer on every key
        _searchTimer.Stop();
        _searchTimer.Start();
    }
    private void PerformSearch(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            dgvDoctor.DataSource = GlobalState.Doctors;
            return;
        }

        dgvDoctor.DataSource = null;
        _bsDoctor.DataSource = GlobalState.Doctors
            .Where(d => d.Staff.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) == true
                || d.Staff.LastName.Contains(text, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();
        dgvDoctor.DataSource = _bsDoctor;
        _bsDoctor.ResetBindings(false);
    }
    #endregion

    #region Helper methods
    private async Task LoadDoctorsAsync()
    {
        btnRefresh.Enabled = false;
        dgvDoctor.Enabled = false;
        try
        {
            var doctors = await _docRepo.GetAllWithStaffsAsync();

            GlobalState.Doctors.Clear();
            foreach (var doctor in doctors)
            {
                GlobalState.Doctors.Add(doctor.ToDto());
            }

            OnDgvDoctorSelectionChanged(this, EventArgs.Empty);
            _bsDoctor.ResetBindings(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading doctors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnRefresh.Enabled = true;
            dgvDoctor.Enabled = true;
        }
    }
    private async Task<bool> CreateDoctorAsync()
    {
        if (cmbCode.SelectedItem == null)
        {
            MessageBox.Show("Please select a doctor code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (cmbSpecialization.SelectedItem == null)
        {
            MessageBox.Show("Please select a specialization.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var code = cmbCode.SelectedItem as string;
        var specialization = (Specialization)cmbSpecialization.SelectedItem;
        var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code);
        if (staff is null)
        {
            MessageBox.Show("Selected staff not found.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        //if (dgvDoctor.CurrentRow.DataBoundItem is not DoctorDto dto) return;
        var department = GlobalState.Departments
                            .FirstOrDefault(d => d.DepartmentId == staff!.DepartmentId);
        staff.Department = department;
        var doctor = await _repo
            .CreateAsync(new Doctor
            {
                DoctorId = Guid.NewGuid().ToString(),
                Code = code!,
                YearsOfExperience = int.Parse(tbExperinse.Text.Trim()),
                LicenseNumber = tbLicenseNumber.Text.Trim(),
                Specialization = specialization.ToString(),
                StaffId = staff!.StaffId,
            });
        doctor.Staff = staff.ToEntity();
        var doctorDto = doctor.ToDto();

        if (doctorDto.Staff != null) doctorDto.Staff = staff;
        if (doctorDto.Staff!.Department != null) doctorDto.Staff!.Department = department;

        GlobalState.Doctors.Add(doctorDto);
        GlobalState.DoctorsCodeList.Add(doctorDto.Staff.Code);

        IsNew = false;
        _bsDoctor.ResetBindings(false);
        return doctorDto != null;
    }
    private async Task<bool> UpdateDoctorAsync(string id)
    {
        var code = cmbCode.SelectedItem!.ToString()!;
        var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code);
        var yearsOfExperiense = int.Parse(tbExperinse.Text.Trim());
        var licenseNumber = tbLicenseNumber.Text.Trim();
        var specialization = cmbSpecialization.SelectedItem!.ToString()!;
        var row = dgvDoctor.CurrentRow.DataBoundItem as DoctorDto;

        var isSuccess = await _repo
            .UpdateAsync(id, new Doctor
            {
                DoctorId = id,
                Code = code,
                YearsOfExperience = yearsOfExperiense,
                LicenseNumber = licenseNumber,
                StoppedWork = row!.StoppedWork,
                Specialization = specialization,
            });
        if (!isSuccess) return false;

        var doctor = GlobalState.Doctors.FirstOrDefault(d => d.DoctorId == id);
        if (doctor == null) return false;

        doctor.YearsOfExperience = yearsOfExperiense;
        doctor.LicenseNumber = licenseNumber;
        doctor.StoppedWork = row.StoppedWork;
        doctor.Specialization = specialization;

        if (staff != null) doctor.Staff = staff;
        var department = GlobalState.Departments
                            .FirstOrDefault(d => d.DepartmentId == staff!.DepartmentId);
        if (department != null) doctor.Staff!.Department = department;

        IsNew = false;
        _bsDoctor.ResetBindings(false);
        cmbCode.DataSource = GlobalState.AllStaffDoctorsCodeList;
        return true;
    }
    #endregion
}
