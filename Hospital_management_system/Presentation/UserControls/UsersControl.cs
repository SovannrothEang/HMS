using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class UsersControl : UserControl
{
    private readonly IGenericRepository<User> _repo;
    private readonly IUserRepository _userRepo;
    private readonly BindingSource _bsUser = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private bool IsNew = false;

    public UsersControl(IGenericRepository<User> repo, IUserRepository userRepo)
    {
        _repo = repo;
        _userRepo = userRepo;

        #region UI
        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);
        #endregion

        _bsUser.DataSource = GlobalState.Users;
        dgvUser.DataSource = _bsUser;

        #region Events
        dgvUser.DataBindingComplete += (s, e) =>
        {
            if (dgvUser.Columns.Contains("colId"))
                dgvUser.Columns["colId"].Visible = false;
        };
        dgvUser.CellFormatting += DgvUserCellFormatting;
        dgvUser.SelectionChanged += OnDgvUserSelectionChanged;

        cmbCode.SelectedIndexChanged += CmbCodeSelectedIndexChanged;
        tbSearch.KeyUp += OnTbSearchKeyUp;
        #endregion

        #region Button events
        btnRefresh.Click += async (s, e) =>
        {
            await LoadUsersAsync();
        };
        btnNew.Click += (s, e) =>
        {
            var users = GlobalState.Users.Select(s => s.StaffId).ToList();
            cmbCode.DataSource = null;
            cmbCode.DataSource = GlobalState.Staffs
                .Where(s => users.Contains(s.StaffId) == false)
                .Select(s => s.Code)
                .ToList();

            cmbCode.SelectedIndex = -1;
            IsNew = true;
            DisableControls(false);
            tbUsername.Clear();
            tbPassword.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            cmbGender.SelectedIndex = -1;
            tbPhoneNumber.Clear();
            tbEmail.Clear();
            cmbPosition.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbCode.Focus();
        };
        btnUpdate.Click += (s, e) =>
        {
            if (dgvUser.CurrentRow == null)
            {
                if (dgvUser.Rows.Count > 0)
                {
                    dgvUser.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Please select a user to update.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            IsNew = false;
            DisableControls(false);
            tbUsername.Focus();
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvUser.CurrentRow == null)
            {
                if (dgvUser.Rows.Count > 0)
                {
                    dgvUser.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Please select a user to update.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            var id = dgvUser.CurrentRow!.Cells["colId"].Value!.ToString()!;
            var confirmResult = MessageBox.Show("Are you sure to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    var success = await _repo.DeleteAsync(id);
                    if (success)
                    {
                        var user = GlobalState.Users
                            .FirstOrDefault(x => x.UserId == id);
                        if (user != null)
                            GlobalState.Users.Remove(user);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the user.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _bsUser.ResetBindings(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };
        btnCancel.Click += (s, e) =>
        {
            if (IsNew)
            {
                if (tbUsername.Text != string.Empty ||
                    tbPassword.Text != string.Empty)
                {
                    var confirmResult = MessageBox.Show("Discard new user?",
                        "Confirm Cancel",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        IsNew = false;
                        if (dgvUser.CurrentRow != null)
                        {
                            OnDgvUserSelectionChanged(this, EventArgs.Empty);
                        }
                    }
                }
                else
                {
                    IsNew = false;
                    if (dgvUser.CurrentRow != null)
                    {
                        OnDgvUserSelectionChanged(this, EventArgs.Empty);
                    }
                }
            }
            DisableControls(true);
        };
        btnSubmit.Click += async (s, e) =>
        {
            if (IsNew)
            {
                try
                {
                    if (await CreateAsync())
                    {
                        MessageBox.Show(
                            "Successfully created",
                            "Create user",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Failed to create user",
                            "Create user",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    OnDgvUserSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to create, error: {ex.Message}",
                        "Create user",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                try
                {
                    var id = dgvUser.CurrentRow!.Cells["colId"].Value!.ToString()!;
                    if (await UpdateAsync(id))
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
                            $"Failed to update user",
                            "Update staff",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    OnDgvUserSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to update, error: {ex.Message}",
                        "Update staff",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            OnDgvUserSelectionChanged(this, EventArgs.Empty);
            DisableControls(true);
        };
        #endregion
    }

    #region UI config
    private void LoadControlsConfiguration()
    {
        #region Disabled
        tbFirstName.Enabled = false;
        tbLastName.Enabled = false;
        cmbGender.Enabled = false;
        dtpDob.Enabled = false;
        tbPhoneNumber.Enabled = false;
        tbEmail.Enabled = false;
        cmbPosition.Enabled = false;
        cmbDepartment.Enabled = false;
        #endregion

        dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dgvUser.DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);

        var users = GlobalState.Users.Select(u => u.StaffId).ToList();
        cmbCode.DataSource = GlobalState.Staffs
            .Where(s => users.Contains(s.StaffId) == false)
            .Select(s => s.Code)
            .ToList();

        dtpDob.Format = DateTimePickerFormat.Custom;
        dtpDob.CustomFormat = "dd/MM/yyyy";

        cmbGender.DataSource = Enum.GetValues(typeof(PersonGender));

        cmbPosition.DataSource = Enum.GetValues(typeof(Position));

        cmbDepartment.DataSource = GlobalState.Departments.ToList();
        cmbDepartment.DisplayMember = "Name";
        cmbDepartment.ValueMember = "DepartmentId";

        dgvUser.AutoGenerateColumns = false;
        dgvUser.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvUser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        #region Columns
        dgvUser.Columns.AddRange([
            new DataGridViewTextBoxColumn {
                Name = "colId",
                DataPropertyName = "UserId",
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
                Name = "colUsername",
                HeaderText = "Username",
                DataPropertyName = "Username",
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
                Name = "colDepartment",
                HeaderText = "Department",
                DataPropertyName = "Department.Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
        ]);

        dgvUser.Columns["colAddress"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        #endregion

        dgvUser.Columns["colDob"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }
    private void DisableControls(bool con)
    {
        cmbCode.Enabled = !con;
        tbUsername.Enabled = !con;
        tbPassword.Enabled = !con;

        btnCancel.Enabled = !con;
        btnSubmit.Enabled = !con;
        btnRefresh.Enabled = con;
        btnNew.Enabled = con;
        btnDelete.Enabled = con;
        btnUpdate.Enabled = con;
        dgvUser.Enabled = con;
    }
    #endregion

    #region Events
    private void OnDgvUserSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvUser.CurrentRow == null) return;

        if (dgvUser.CurrentRow.DataBoundItem is UserDto selectedUser)
        {
            selectedUser.Staff ??= GlobalState.Staffs
                .First(s => s.StaffId == selectedUser.StaffId);

            cmbCode.Text = selectedUser.Code;
            tbFirstName.Text = selectedUser.Staff.FirstName;
            tbLastName.Text = selectedUser.Staff.LastName;
            tbUsername.Text = selectedUser.Username;
            tbPassword.Text = string.Empty;
            cmbGender.SelectedItem = selectedUser.Staff.Gender;
            dtpDob.Value = selectedUser.Staff.DOB;
            tbPhoneNumber.Text = selectedUser.Staff.PhoneNumber;
            tbEmail.Text = selectedUser.Staff.Email;
            cmbPosition.Text = selectedUser.Staff.Position.ToString();
            if (selectedUser.Staff.DOB < dtpDob.MinDate)
            {
                dtpDob.Value = dtpDob.MinDate;
            }
            else
            {
                dtpDob.Value = selectedUser.Staff.DOB;
            }
            cmbDepartment.SelectedValue = selectedUser.Staff.DepartmentId;
        }
    }
    private void CmbCodeSelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cmbCode.SelectedItem is not string code) return;
        var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code);
        if (staff is null) return;
        staff.Department ??= GlobalState.Departments.First(d => d.DepartmentId == staff.DepartmentId);

        tbFirstName.Text = staff.FirstName;
        tbLastName.Text = staff.LastName;
        cmbGender.SelectedItem = staff.Gender;
        dtpDob.Value = staff.DOB;
        tbPhoneNumber.Text = staff.PhoneNumber;
        tbEmail.Text = staff.Email;
        cmbDepartment.Text = staff.Department.Name;
        cmbPosition.Text = staff.Position.ToString();
    }
    private void DgvUserCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvUser.Rows.Count) return;
        var row = dgvUser.Rows[e.RowIndex];
        if (row is null) return;

        if (row.DataBoundItem is not UserDto user) return;
        var staff = GlobalState.Staffs.FirstOrDefault(s => s.StaffId == user.StaffId);
        if (staff is null) return;

        //dgvStaff.Rows[e.RowIndex].Cells["colDob"].Value = staff?.DOB.ToShortDateString();
        row.Cells["colFirstName"].Value = staff.FirstName;
        row.Cells["colLastName"].Value = staff.LastName;
        row.Cells["colGender"].Value = staff.Gender;
        row.Cells["colDob"].Value = staff.DOB;
        row.Cells["colAddress"].Value = staff.Address;
        row.Cells["colPhone"].Value = staff.PhoneNumber;
        row.Cells["colEmail"].Value = staff.Email;
        row.Cells["colPosition"].Value = staff.Position;
        row.Cells["colDepartment"].Value = staff.Department!.Name;
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
            dgvUser.DataSource = GlobalState.Users;
            return;
        }

        dgvUser.DataSource = null;
        _bsUser.DataSource = GlobalState.Users
            .Where(u => u.Code.Contains(text, StringComparison.OrdinalIgnoreCase) == true
                || u.Username.Contains(text, StringComparison.OrdinalIgnoreCase) == true 
                || u.Staff?.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) == true
                || u.Staff?.LastName.Contains(text, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();
        dgvUser.DataSource = _bsUser;
        _bsUser.ResetBindings(false);
    }
    #endregion

    #region Helper methods
    private async Task LoadUsersAsync()
    {
        dgvUser.Enabled = false;
        btnRefresh.Enabled = false;

        try
        {
            var users = await _userRepo.GetAllWithStaffAsync();

            GlobalState.Users.Clear();
            foreach (var user in users)
            {
                GlobalState.Users.Add(user.ToDto());
            }

            OnDgvUserSelectionChanged(this, EventArgs.Empty);
            _bsUser.ResetBindings(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            dgvUser.Enabled = true;
            btnRefresh.Enabled = true;
        }
    }
    private async Task<bool> CreateAsync()
    {
        var code = cmbCode.Text.Trim();
        var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code);
        if (staff == null) return false;
        var username = tbUsername.Text.Trim();
        var password = tbPassword.Text.Trim();
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Username and password are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var existingUser = await _userRepo.GetByUsernameAsync(username);
        if (existingUser != null)
        {
            MessageBox.Show("Username already exists. Please choose a different username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var newUser = new User
        {
            UserId = Guid.NewGuid().ToString(),
            StaffId = staff.StaffId,
            Code = code,
            Username = username,
            Password = password,
        };

        var user = await _repo
            .CreateAsync(newUser);
        if (user == null) return false;

        var userDto = user.ToDto();
        userDto.Staff = staff;
        var department = GlobalState.Departments
                            .FirstOrDefault(d => d.DepartmentId == staff.DepartmentId);
        if (department != null) userDto.Staff.Department = department;

        GlobalState.Users.Add(userDto);
        IsNew = false;
        _bsUser.ResetBindings(false);
        return true;
    }
    private async Task<bool> UpdateAsync(string id)
    {
        var code = cmbCode.Text.Trim();
        var username = tbUsername.Text.Trim();
        var password = tbPassword.Text.Trim();
        var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code)
            ?? throw new ArgumentNullException(nameof(id));
        var isSuccess = await _repo
            .UpdateAsync(id, new User
            {
                UserId = id,
                Code = code,
                Username = username,
                Password = password,
                StaffId = staff.StaffId,
            });
        if (!isSuccess)
            throw new Exception("Error occurs while trying to update in database!");

        var user = GlobalState.Users.FirstOrDefault(s => s.UserId == id)
            ?? throw new ArgumentNullException(nameof(id));

        user.Code = code;
        user.Username = username;

        IsNew = false;
        _bsUser.ResetBindings(false);
        return true;
    }
    #endregion
}
