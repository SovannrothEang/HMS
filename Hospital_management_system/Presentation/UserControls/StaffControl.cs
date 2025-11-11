using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class StaffControl : UserControl
{
    private readonly IGenericRepository<Staff> _repo;
    private readonly IStaffRepository _staffRepo;
    private readonly BindingSource _bsStaffs = [];

    private static bool IsNew = false;
    public StaffControl(IGenericRepository<Staff> repo, IStaffRepository staffRepo)
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

        #region Dgv Events
        dgvStaff.DataBindingComplete += (s, e) =>
        {
            if (dgvStaff.Columns.Contains("colId"))
                dgvStaff.Columns["colId"].Visible = false;
        };
        dgvStaff.CellFormatting += (s, e) =>
        {
            StaffDto? staff = dgvStaff.Rows[e.RowIndex].DataBoundItem as StaffDto;
            //dgvStaff.Rows[e.RowIndex].Cells["colDob"].Value = staff?.DOB.ToShortDateString();
            dgvStaff.Rows[e.RowIndex].Cells["colDepartment"].Value = staff?.Department?.Name;
            dgvStaff.Columns["colDob"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            IsNew = false;
            DisableControls(false);
            tbCode.Focus();
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvStaff.CurrentRow == null) return;
            var id = dgvStaff.CurrentRow.Cells["colId"].Value!.ToString()!;
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
                    await CreateStaffAsync();

                    MessageBox.Show(
                        "Successfully created",
                        "Created staff",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    OnDgvStaffSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to create, error: {ex.Message}",
                        "Created staff",
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
                    await UpdateStaffAsync(id);

                    MessageBox.Show(
                        "Successfully created",
                        "Updated staff",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    OnDgvStaffSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to update, error: {ex.Message}",
                        "Updated staff",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            OnDgvStaffSelectionChanged(this, EventArgs.Empty);
            DisableControls(true);
        };
        _staffRepo = staffRepo;
        #endregion
    }

    #region UI config
    private void LoadControlsConfiguration()
    {
        dtpDob.Format = DateTimePickerFormat.Custom;
        dtpDob.Value = DateTime.Now;

        cmbGender.DataSource = Enum.GetValues(typeof(PersonGender));
        //cmbGender.SelectedIndex = 0;

        cmbPosition.DataSource = Enum.GetValues(typeof(Position));
        cmbPosition.DisplayMember = "ToString";
        //cmbPosition.SelectedIndex = 0;

        cmbDepartment.DataSource = GlobalState.Departments;
        cmbDepartment.DisplayMember = "Name";
        cmbDepartment.ValueMember = "DepartmentId";
        //cmbDepartment.SelectedIndex = 0;

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
        cmbDepartment.Enabled = !con;

        btnCancel.Enabled = !con;
        btnSubmit.Enabled = !con;
        btnRefresh.Enabled = con;
        btnNew.Enabled = con;
        btnDelete.Enabled = con;
        btnUpdate.Enabled = con;
    }
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
            cmbPosition.Text = selectedStaff.Position;
            tbSalary.Text = selectedStaff.Salary.ToString();
            cmbDepartment.SelectedValue = selectedStaff.DepartmentId;
        }
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
    private async Task CreateStaffAsync()
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
                            Salary = decimal.Parse(tbSalary.Text.Trim()),
                            DepartmentId = cmbDepartment.SelectedValue!.ToString()!
                        });
        var staffDto = staff.ToDto();
        var department = GlobalState.Departments
                            .FirstOrDefault(d => d.DepartmentId == staff.DepartmentId);
        if (department != null) staffDto.Department = department;

        GlobalState.Staffs.Add(staffDto);
        IsNew = false;
        _bsStaffs.ResetBindings(false);
    }
    private async Task UpdateStaffAsync(string id)
    {
        var code = tbCode.Text.Trim();
        var firstName = tbFirstName.Text.Trim();
        var lastName = tbLastName.Text.Trim();
        //var gender = Enum.GetName(typeof(Gender), cmbGender.SelectedItem!);
        var gender = (PersonGender)cmbGender.SelectedItem!;
        var dob = DateTime.Parse(dtpDob.Value.ToString());
        var phoneNumber = tbPhoneNumber.Text.Trim();
        var address = tbAddress.Text.Trim();
        var email = tbEmail.Text.Trim();
        var position = cmbPosition.Text;
        var salary = decimal.Parse(tbSalary.Text.Trim());
        var departmentId = cmbDepartment.SelectedValue!.ToString();

        var staff = await _repo
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
                            Salary = salary,
                            DepartmentId = departmentId!
                        });
        var s = GlobalState.Staffs.FirstOrDefault(s => s.StaffId == id);
        if (s != null)
        {
            s.Code = code;
            s.FirstName = firstName;
            s.LastName = lastName;
            s.Gender = gender;
            s.DOB = dob;
            s.PhoneNumber = phoneNumber;
            s.Address = address;
            s.Email = email;
            s.Position = position;
            s.Salary = salary;
            s.DepartmentId = departmentId!;
            var department = GlobalState.Departments
                                .FirstOrDefault(d => d.DepartmentId == s.DepartmentId);
            if (department != null) s.Department = department;
        }
        IsNew = false;
        _bsStaffs.ResetBindings(false);
    }
    #endregion
}
