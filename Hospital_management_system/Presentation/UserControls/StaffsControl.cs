using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class StaffsControl : UserControl
{
    private readonly IGenericRepository<Staff> _repo;
    private readonly IStaffRepository _staffRepo;
    private readonly BindingSource _bsStaffs = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private static bool IsNew = false;

    public StaffsControl(IGenericRepository<Staff> repo, IStaffRepository staffRepo)
    {
        _repo = repo;
        _staffRepo = staffRepo;

        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);

        _bsStaffs.DataSource = GlobalState.Staffs;
        dgvStaff.DataSource = _bsStaffs;

        //this.Load += async (s, e) =>
        //{
        //    await LoadStaffsAsync();
        //};
        tbSearch.KeyUp += OnTbSearchKeyUp;

        #region Events
        dgvStaff.DataBindingComplete += (s, e) =>
        {
            if (dgvStaff.Columns.Contains("colId"))
                dgvStaff.Columns["colId"].Visible = false;
        };
        dgvStaff.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvStaff.Rows.Count) return;
            var row = dgvStaff.Rows[e.RowIndex];
            if (row == null) return;

            if (row.DataBoundItem is not StaffDto staff) return;
            var department = GlobalState.Departments.FirstOrDefault(d => d.DepartmentId == staff.DepartmentId);
            //dgvStaff.Rows[e.RowIndex].Cells["colDob"].Value = staff?.DOB.ToShortDateString();
            dgvStaff.Rows[e.RowIndex].Cells["colDepartment"].Value = department?.Name;
        };
        dgvStaff.SelectionChanged += OnDgvStaffSelectionChanged;
        #endregion

        #region Click Events
        btnRefresh.Click += async (s, e) =>
        {
            await LoadStaffsAsync();
        };
        btnCancel.Click += (s, e) =>
        {
            if (IsNew)
            {
                if (tbCode.Text != string.Empty ||
                    tbFirstName.Text != string.Empty ||
                    tbLastName.Text != string.Empty ||
                    tbPhoneNumber.Text != string.Empty ||
                    tbAddress.Text != string.Empty ||
                    tbEmail.Text != string.Empty ||
                    tbSalary.Text != string.Empty)
                {
                    var confirmResult = MessageBox.Show("Discard new staff?",
                        "Confirm Cancel",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        IsNew = false;
                        if (dgvStaff.CurrentRow != null)
                        {
                            OnDgvStaffSelectionChanged(this, EventArgs.Empty);
                        }
                    }
                }
                else
                {
                    IsNew = false;
                    if (dgvStaff.CurrentRow != null)
                    {
                        OnDgvStaffSelectionChanged(this, EventArgs.Empty);
                    }
                }
            }
            DisableControls(true);
        };
        btnNew.Click += (s, e) =>
        {
            IsNew = true;
            DisableControls(false);
            tbCode.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            cmbGender.SelectedIndex = -1;
            //dtpDob.Clear();
            tbPhoneNumber.Clear();
            tbAddress.Clear();
            tbEmail.Clear();
            cmbPosition.SelectedIndex = -1;
            tbSalary.Clear();
            cmbDepartment.SelectedIndex = -1;
            tbCode.Focus();
        };
        btnUpdate.Click += (s, e) =>
        {
            if (dgvStaff.CurrentRow == null)
            {
                if (dgvStaff.Rows.Count > 0)
                {
                    dgvStaff.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Please select a staff to update.", "No Staff Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            IsNew = false;
            DisableControls(false);
            tbCode.Focus();
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvStaff.CurrentRow == null)
            {
                if (dgvStaff.Rows.Count > 0)
                {
                    dgvStaff.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Please select a staff to update.", "No Staff Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            var id = dgvStaff.CurrentRow!.Cells["colId"].Value!.ToString()!;
            var confirmResult = MessageBox.Show("Are you sure to delete this staff?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var isDoctor = GlobalState.Doctors.FirstOrDefault(d => d.StaffId == id);
                if (isDoctor is not null)
                {
                    var patients = GlobalState.Patients.Where(p => p.DoctorId == isDoctor.DoctorId).ToList();
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
                    MessageBox.Show(
                        "There is a record of doctor with this staff",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                var isUser = GlobalState.Users.FirstOrDefault(u => u.StaffId == id);
                if (isUser is not null)
                {
                    MessageBox.Show(
                        "There is a record of user with this staff",
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
                        var staff = GlobalState.Staffs
                            .FirstOrDefault(x => x.StaffId == id);
                        if (staff != null)
                        {
                            var department = GlobalState.Departments
                                .FirstOrDefault(d => d.DepartmentId == staff?.DepartmentId);
                            staff.Department = department;
                            GlobalState.Staffs.Remove(staff);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the staff.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _bsStaffs.ResetBindings(false);
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
                    if (await CreateStaffAsync())
                    {
                        MessageBox.Show(
                            "Successfully created",
                            "Create staff",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Failed to create staff",
                            "Created staff",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    OnDgvStaffSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to create, error: {ex.Message}",
                        "Create staff",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                try
                {
                    var id = dgvStaff.CurrentRow!.Cells["colId"].Value!.ToString()!;
                    if (await UpdateStaffAsync(id))
                    {
                        MessageBox.Show(
                            "Successfully updated",
                            "Update staff",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Failed to update staff",
                            "Update staff",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    OnDgvStaffSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to update, error: {ex.Message}",
                        "Update staff",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            OnDgvStaffSelectionChanged(this, EventArgs.Empty);
            DisableControls(true);
        };
        #endregion

        dgvStaff.Columns["colDob"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    #region UI config
    private void LoadControlsConfiguration()
    {
        dgvStaff.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dgvStaff.DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);

        dtpDob.Format = DateTimePickerFormat.Custom;
        dtpDob.CustomFormat = "dd/MM/yyyy";

        dtpHireDate.Format = DateTimePickerFormat.Custom;
        dtpHireDate.CustomFormat = "dd/MM/yyyy";

        cmbGender.DataSource = Enum.GetValues(typeof(PersonGender));
        cmbPosition.DataSource = Enum.GetValues(typeof(Position));

        cmbDepartment.DataSource = GlobalState.Departments;
        cmbDepartment.DisplayMember = "Name";
        cmbDepartment.ValueMember = "DepartmentId";

        dgvStaff.AutoGenerateColumns = false;
        dgvStaff.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvStaff.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
                DataPropertyName = "Department.Name",
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

        dgvStaff.Columns["colAddress"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
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
        dtpHireDate.Enabled = !con;
        cmbDepartment.Enabled = !con;

        btnCancel.Enabled = !con;
        btnSubmit.Enabled = !con;
        btnRefresh.Enabled = con;
        btnNew.Enabled = con;
        btnDelete.Enabled = con;
        btnUpdate.Enabled = con;
        dgvStaff.Enabled = con;
    }
    #endregion

    #region Button events

    #endregion

    #region Events
    private void OnDgvStaffSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvStaff.CurrentRow == null) return;

        if (dgvStaff.CurrentRow.DataBoundItem is StaffDto selectedStaff)
        {
            tbCode.Text = selectedStaff.Code;
            tbFirstName.Text = selectedStaff.FirstName;
            tbLastName.Text = selectedStaff.LastName;
            cmbGender.SelectedItem = selectedStaff.Gender;
            dtpDob.Value = selectedStaff.DOB;
            tbPhoneNumber.Text = selectedStaff.PhoneNumber;
            tbAddress.Text = selectedStaff.Address;
            tbEmail.Text = selectedStaff.Email;
            cmbPosition.Text = selectedStaff.Position.ToString();
            tbSalary.Text = selectedStaff.Salary.ToString();
            if (selectedStaff.HiredDate < dtpHireDate.MinDate)
            {
                dtpHireDate.Value = dtpHireDate.MinDate;
            }
            else
            {
                dtpHireDate.Value = selectedStaff.HiredDate;
            }
            cmbDepartment.SelectedValue = selectedStaff.DepartmentId;
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
            dgvStaff.DataSource = GlobalState.Staffs;
            return;
        }

        dgvStaff.DataSource = null;
        _bsStaffs.DataSource = GlobalState.Staffs
            .Where(d => d.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) == true
                || d.LastName.Contains(text, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();
        dgvStaff.DataSource = _bsStaffs;
        _bsStaffs.ResetBindings(false);
    }
    #endregion

    #region Helper Methods
    private async Task LoadStaffsAsync()
    {
        dgvStaff.Enabled = false;
        btnRefresh.Enabled = false;

        try
        {
            var staffs = await _staffRepo.GetAllWithDepartmentsAsync();

            GlobalState.Staffs.Clear();
            foreach (var staff in staffs)
            {
                GlobalState.Staffs.Add(staff.ToDto());
            }

            OnDgvStaffSelectionChanged(this, EventArgs.Empty);
            _bsStaffs.ResetBindings(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading staffs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            dgvStaff.Enabled = true;
            btnRefresh.Enabled = true;
        }
    }
    private async Task<bool> CreateStaffAsync()
    {
        var staff = await _repo
            .CreateAsync(new Staff
            {
                StaffId = Guid.NewGuid().ToString(),
                Code = tbCode.Text.Trim(),
                FirstName = tbFirstName.Text.Trim(),
                LastName = tbLastName.Text.Trim(),
                Gender = (PersonGender)cmbGender.SelectedItem!,
                DOB = DateTime.Parse(dtpDob.Value.ToString()),
                PhoneNumber = tbPhoneNumber.Text.Trim(),
                Address = tbAddress.Text.Trim(),
                Email = tbEmail.Text.Trim(),
                Position = cmbPosition.Text,
                HiredDate = dtpHireDate.Value.Date,
                Salary = decimal.Parse(tbSalary.Text.Trim()),
                DepartmentId = cmbDepartment.SelectedValue!.ToString()!
            });
        if (staff == null) return false;

        var staffDto = staff.ToDto();
        var department = GlobalState.Departments
                            .FirstOrDefault(d => d.DepartmentId == staff.DepartmentId);
        if (department != null) staffDto.Department = department;

        GlobalState.Staffs.Add(staffDto);
        IsNew = false;
        _bsStaffs.ResetBindings(false);
        return true;
    }
    private async Task<bool> UpdateStaffAsync(string id)
    {
        var code = tbCode.Text.Trim();
        var firstName = tbFirstName.Text.Trim();
        var lastName = tbLastName.Text.Trim();
        var gender = (PersonGender)cmbGender.SelectedItem!;
        var dob = dtpDob.Value.Date;
        var phoneNumber = tbPhoneNumber.Text.Trim();
        var address = tbAddress.Text.Trim();
        var email = tbEmail.Text.Trim();
        var position = cmbPosition.Text;
        var salary = decimal.Parse(tbSalary.Text.Trim());
        var hiredDate = dtpHireDate.Value.Date;
        var departmentId = cmbDepartment.SelectedValue!.ToString();

        var isSuccess = await _repo
            .UpdateAsync(id, new Staff
            {
                StaffId = id,
                Code = code,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DOB = dob,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email,
                Position = position,
                HiredDate = hiredDate,
                Salary = salary,
                DepartmentId = departmentId!
            });
        if (!isSuccess) return false;

        var staff = GlobalState.Staffs.FirstOrDefault(s => s.StaffId == id);
        if (staff == null) return false;

        staff.Code = code;
        staff.FirstName = firstName;
        staff.LastName = lastName;
        staff.Gender = gender;
        staff.DOB = dob;
        staff.PhoneNumber = phoneNumber;
        staff.Address = address;
        staff.Email = email;
        staff.Position = Enum.Parse<Position>(position, true);
        staff.HiredDate = hiredDate;
        staff.Salary = salary;
        staff.DepartmentId = departmentId!;
        var department = GlobalState.Departments
                            .FirstOrDefault(d => d.DepartmentId == staff.DepartmentId);
        if (department != null) staff.Department = department;

        IsNew = false;
        _bsStaffs.ResetBindings(false);
        return true;
    }
    #endregion
}
