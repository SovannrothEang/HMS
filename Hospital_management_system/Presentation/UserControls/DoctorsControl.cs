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
            var staff = GlobalState.Staffs.FirstOrDefault(s => s.StaffId == doctor.StaffId);
            if (staff is null) return;

            if (dgvDoctor.Columns.Contains("colCode"))
                row.Cells["colCode"].Value = staff.Code;
            if (dgvDoctor.Columns.Contains("colFirstName"))
                row.Cells["colFirstName"].Value = staff.FirstName;
            if (dgvDoctor.Columns.Contains("colLastName"))
                row.Cells["colLastName"].Value = staff.LastName;
            if (dgvDoctor.Columns.Contains("colDepartment"))
                row.Cells["colDepartment"].Value = staff.Department!.Name;
        };
        dgvDoctor.SelectionChanged += OnDgvDoctorSelectionChanged;
        tbSearch.KeyUp += OnTbSearchKeyUp;
        cmbCode.SelectedIndexChanged += (s, e) =>
        {
            var staffCode = cmbCode.SelectedValue;
            if (staffCode is null) return;

            var staff = GlobalState.Staffs
                .FirstOrDefault(s => s.Code == staffCode.ToString());
            if (staff == null) return;

            var department = GlobalState.Departments
                .FirstOrDefault(d => d.DepartmentId == staff!.DepartmentId);
            if (department == null) return;

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

            cmbCode.DataSource = null;
            cmbCode.DataSource = GlobalState.Staffs
                .Where(s => s.Position == Position.Doctor)
                .Select(s => s.Code)
                .ToList();
            DisableControls(true);
        };
        btnUpdate.Click += (s, e) =>
        {
            if (dgvDoctor.CurrentRow == null)
            {
                if (dgvDoctor.Rows.Count > 0)
                {
                    dgvDoctor.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Please select a doctor to update.", "No Doctor Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DisableControls(false);
            cmbCode.Enabled = false;
            IsNew = false;
            cmbCode.Focus();
        };
        btnNew.Click += (s, e) =>
        {
            DisableControls(false);

            var allDoctor = GlobalState.Doctors.Select(s => s.StaffId).ToList();
            cmbCode.DataSource = null;
            cmbCode.DataSource = GlobalState.Staffs
                .Where(s => s.Position == Position.Doctor
                    && allDoctor.Contains(s.StaffId) == false)
                .Select(s => s.Code)
                .ToList();
            cmbCode.SelectedIndex = -1;

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
            if (dgvDoctor.CurrentRow == null)
            {
                if (dgvDoctor.Rows.Count > 0)
                {
                    dgvDoctor.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Please select a doctor to update.", "No Doctor Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            var id = dgvDoctor.CurrentRow!.Cells["colId"].Value!.ToString()!;
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
                            .FirstOrDefault(x => x.DoctorId == id) ?? throw new ArgumentException(nameof(id));
                        GlobalState.Doctors.Remove(doctor);
                        cmbCode.DataSource = null;
                        cmbCode.DataSource = GlobalState.Staffs
                            .Where(s => s.Position == Position.Doctor
                                && GlobalState.Doctors.Any(d => d.StaffId != s.StaffId))
                            .Select(s => s.Code)
                            .ToList();
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
            try
            {
                if (IsNew)
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
                else
                {
                    var id = dgvDoctor.CurrentRow!.Cells["colId"].Value!.ToString()!;
                    if (await UpdateDoctorAsync(id))
                    {
                        MessageBox.Show(
                            "Successfully updated",
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
            }
            catch (Exception ex)
            {
                if (IsNew)
                {
                    MessageBox.Show(
                        $"Failed to create, error: {ex.Message}",
                        "Create doctor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"Failed to update, error: {ex.Message}",
                        "Update doctor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            finally
            {
                cmbCode.DataSource = null;
                cmbCode.DataSource = GlobalState.Staffs
                    .Where(s => s.Position == Position.Doctor
                        && GlobalState.Doctors.Any(d => d.StaffId != s.StaffId))
                    .Select(s => s.Code)
                    .ToList();
                IsNew = false;
                OnDgvDoctorSelectionChanged(this, EventArgs.Empty);
                DisableControls(true);
            }
        };
        #endregion
    }

    #region UI config
    private void LoadControlsConfiguration()
    {
        dgvDoctor.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dgvDoctor.DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);

        var doctors = GlobalState.Doctors.Select(d => d.StaffId).ToList();
        cmbCode.DataSource = null;
        cmbCode.DataSource = GlobalState.Staffs
            .Where(s => s.Position == Position.Doctor)
            .Select(s => s.Code)
            .ToList();

        dtpHireDate.Format = DateTimePickerFormat.Custom;
        dtpHireDate.CustomFormat = "dd/MM/yyyy";

        cmbSpecialization.DataSource = Enum.GetValues(typeof(Specialization));
        cmbSpecialization.SelectedIndex = -1;

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
        dgvDoctor.Enabled = con;
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
                selectedDoctor.Staff = staff;
                var department = GlobalState.Departments
                    .FirstOrDefault(d => d.DepartmentId == staff.DepartmentId);
            }
            selectedDoctor.Staff ??= GlobalState.Staffs
                    .FirstOrDefault(s => s.Code == selectedDoctor.Code);
            if (selectedDoctor.Staff is null) return;
            selectedDoctor.Staff.Department ??= GlobalState.Departments
                    .FirstOrDefault(d => d.DepartmentId == selectedDoctor.Staff.DepartmentId);
            if (selectedDoctor.Staff.Department is null) return;

            cmbCode.Text = selectedDoctor.Code;
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
            .Where(d => d.Staff?.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) == true
                || d.Staff?.LastName.Contains(text, StringComparison.OrdinalIgnoreCase) == true)
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
        if (cmbCode.Text is not String code)
        {
            MessageBox.Show("Please select a doctor code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (cmbSpecialization.Text is not String specialization)
        {
            MessageBox.Show("Please select a specialization.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code);
        if (staff is null)
        {
            MessageBox.Show("Selected staff not found.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        var department = GlobalState.Departments
            .FirstOrDefault(d => d.DepartmentId == staff!.DepartmentId);

        var newDoctor = new Doctor
        {
            DoctorId = Guid.NewGuid().ToString(),
            Code = code,
            YearsOfExperience = int.Parse(tbExperinse.Text.Trim()),
            LicenseNumber = tbLicenseNumber.Text.Trim(),
            Specialization = specialization.ToString(),
            StaffId = staff.StaffId,
        };
        var doctor = await _repo.CreateAsync(newDoctor);
        var doctorDto = doctor.ToDto();

        doctorDto.Staff ??= staff;
        doctorDto.Staff.Department ??= department;

        GlobalState.Doctors.Add(doctorDto);

        IsNew = false;
        _bsDoctor.ResetBindings(false);
        return doctorDto != null;
    }
    private async Task<bool> UpdateDoctorAsync(string id)
    {
        if (cmbCode.Text is not String code)
            return false;
        if (cmbSpecialization.Text is not String specialization)
            return false;

        var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code)
            ?? throw new ArgumentNullException(nameof(id)); ;
        var yearsOfExperiense = int.Parse(tbExperinse.Text.Trim());
        var licenseNumber = tbLicenseNumber.Text.Trim();

        var isSuccess = await _repo
            .UpdateAsync(id, new Doctor
            {
                DoctorId = id,
                Code = code,
                YearsOfExperience = yearsOfExperiense,
                LicenseNumber = licenseNumber,
                Specialization = specialization,
                StaffId = staff.StaffId,
            });
        if (!isSuccess)
            throw new Exception("Error occurs while trying to update in database!");

        var doctor = GlobalState.Doctors.FirstOrDefault(d => d.DoctorId == id)
            ?? throw new ArgumentNullException(nameof(id)); ;

        doctor.Code = code;
        doctor.YearsOfExperience = yearsOfExperiense;
        doctor.LicenseNumber = licenseNumber;
        doctor.Specialization = specialization;
        doctor.Staff ??= staff;
        doctor.Staff.Department ??= GlobalState.Departments
            .FirstOrDefault(d => d.DepartmentId == staff!.DepartmentId);

        IsNew = false;
        _bsDoctor.ResetBindings(false);
        return true;
    }
    #endregion
}
