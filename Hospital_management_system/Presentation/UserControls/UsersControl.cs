using Hospital_management_system.Application.Common;
using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Application.Commands.Users;
using Hospital_management_system.Application.Queries.Users;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class UsersControl : UserControl, IDisposable
{
    private readonly IMediator _mediator;
    private readonly BindingSource _bsUser = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private bool IsNew = false;

    public UsersControl(IMediator mediator)
    {
        _mediator = mediator;

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
            if (dgvUser.Columns.Contains("colId")) dgvUser.Columns["colId"].Visible = false;
        };
        dgvUser.SelectionChanged += OnDgvUserSelectionChanged;
        dgvUser.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvUser.Rows.Count) return;
            if (dgvUser.Rows[e.RowIndex].DataBoundItem is not UserDto user) return;

            if (dgvUser.Columns[e.ColumnIndex].Name == "colFirstName")
                e.Value = user.Staff?.FirstName;
            else if (dgvUser.Columns[e.ColumnIndex].Name == "colLastName")
                e.Value = user.Staff?.LastName;
            else if (dgvUser.Columns[e.ColumnIndex].Name == "colGender")
                e.Value = user.Staff?.Gender;
            else if (dgvUser.Columns[e.ColumnIndex].Name == "colDob")
                e.Value = user.Staff?.DOB;
            else if (dgvUser.Columns[e.ColumnIndex].Name == "colPhone")
                e.Value = user.Staff?.PhoneNumber;
            else if (dgvUser.Columns[e.ColumnIndex].Name == "colEmail")
                e.Value = user.Staff?.Email;
            else if (dgvUser.Columns[e.ColumnIndex].Name == "colPosition")
                e.Value = user.Staff?.Position;
            else if (dgvUser.Columns[e.ColumnIndex].Name == "colDepartment")
                e.Value = user.Staff?.Department?.Name;
        };
        cmbCode.SelectedIndexChanged += CmbCodeSelectedIndexChanged;
        tbSearch.KeyUp += OnTbSearchKeyUp;
        #endregion

        #region Button events
        btnRefresh.Click += async (s, e) => await LoadUsersAsync();
        btnNew.Click += (s, e) =>
        {
            var userStaffIds = GlobalState.Users.Select(u => u.StaffId).ToList();
            cmbCode.DataSource = GlobalState.Staffs
                .Where(s => !userStaffIds.Contains(s.StaffId))
                .Select(s => s.Code).ToList();

            IsNew = true;
            DisableControls(false);
            ClearInputControls();
            cmbCode.Focus();
        };
        btnUpdate.Click += (s, e) =>
        {
            if (dgvUser.CurrentRow == null) return;
            IsNew = false;
            DisableControls(false);
            cmbCode.Enabled = false;
            tbUsername.Focus();
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvUser.CurrentRow?.DataBoundItem is not UserDto user) return;

            var confirmResult = MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var result = await _mediator.SendAsync(new DeleteUserCommand(user.Code));
                if (result.IsSuccess) await LoadUsersAsync();
                else MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        btnCancel.Click += (s, e) =>
        {
            if (IsNew)
            {
                if (tbUsername.Text != string.Empty || tbPassword.Text != string.Empty)
                {
                    var result = MessageBox.Show("Discard new user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) IsNew = false;
                }
                else IsNew = false;
            }
            if (!IsNew) OnDgvUserSelectionChanged(this, EventArgs.Empty);
            DisableControls(true);
        };
        btnSubmit.Click += async (s, e) =>
        {
            var code = cmbCode.Text;
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(username) || (IsNew && string.IsNullOrWhiteSpace(password)))
            {
                MessageBox.Show("Username and password are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result result;
            if (IsNew)
            {
                var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code);
                if (staff == null) return;
                result = await _mediator.SendAsync(new CreateUserCommand(code, username, password, staff.StaffId));
            }
            else
            {
                var user = dgvUser.CurrentRow?.DataBoundItem as UserDto;
                if (user == null) return;
                result = await _mediator.SendAsync(new UpdateUserCommand(user.UserId, user.Code, username, password, user.StaffId, true));
            }

            if (result.IsSuccess)
            {
                await LoadUsersAsync();
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
        tbFirstName.Enabled = tbLastName.Enabled = cmbGender.Enabled = dtpDob.Enabled = 
        tbPhoneNumber.Enabled = tbEmail.Enabled = cmbPosition.Enabled = cmbDepartment.Enabled = false;

        dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
        dgvUser.DefaultCellStyle.Font = new Font("Arial", 11F);
        
        dtpDob.Format = DateTimePickerFormat.Custom;
        dtpDob.CustomFormat = "dd/MM/yyyy";
        
        cmbGender.DataSource = Enum.GetValues(typeof(PersonGender));
        cmbPosition.DataSource = Enum.GetValues(typeof(Position));
        cmbDepartment.DataSource = GlobalState.Departments;
        cmbDepartment.DisplayMember = "Name";

        dgvUser.AutoGenerateColumns = false;
        dgvUser.Columns.AddRange([
            new DataGridViewTextBoxColumn { Name = "colId", DataPropertyName = "UserId", Visible = false },
            new DataGridViewTextBoxColumn { Name = "colCode", HeaderText = "Code", DataPropertyName = "Code", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colFirstName", HeaderText = "First Name", DataPropertyName = "Staff.FirstName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colLastName", HeaderText = "Last Name", DataPropertyName = "Staff.LastName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colUsername", HeaderText = "Username", DataPropertyName = "Username", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colGender", HeaderText = "Gender", DataPropertyName = "Staff.Gender", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colDob", HeaderText = "DOB", DataPropertyName = "Staff.DOB", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colPhone", HeaderText = "Phone", DataPropertyName = "Staff.PhoneNumber", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email", DataPropertyName = "Staff.Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colPosition", HeaderText = "Position", DataPropertyName = "Staff.Position", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colDepartment", HeaderText = "Department", DataPropertyName = "Staff.Department.Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells }
        ]);
        dgvUser.Columns["colDob"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    private void DisableControls(bool con)
    {
        cmbCode.Enabled = tbUsername.Enabled = tbPassword.Enabled = !con;
        btnCancel.Enabled = btnSubmit.Enabled = !con;
        btnRefresh.Enabled = btnNew.Enabled = btnDelete.Enabled = btnUpdate.Enabled = dgvUser.Enabled = con;
    }

    private void ClearInputControls()
    {
        tbUsername.Clear(); tbPassword.Clear(); tbFirstName.Clear(); tbLastName.Clear();
        tbPhoneNumber.Clear(); tbEmail.Clear(); cmbCode.SelectedIndex = -1;
    }

    private void OnDgvUserSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvUser.CurrentRow?.DataBoundItem is not UserDto user) return;
        cmbCode.Text = user.Code;
        tbUsername.Text = user.Username;
        tbPassword.Text = string.Empty;
        if (user.Staff != null)
        {
            tbFirstName.Text = user.Staff.FirstName;
            tbLastName.Text = user.Staff.LastName;
            cmbGender.SelectedItem = user.Staff.Gender;
            dtpDob.Value = user.Staff.DOB < dtpDob.MinDate ? dtpDob.MinDate : user.Staff.DOB;
            tbPhoneNumber.Text = user.Staff.PhoneNumber;
            tbEmail.Text = user.Staff.Email;
            cmbPosition.SelectedItem = user.Staff.Position;
            cmbDepartment.Text = user.Staff.Department?.Name ?? string.Empty;
        }
    }

    private void CmbCodeSelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cmbCode.SelectedItem is not string code) return;
        var staff = GlobalState.Staffs.FirstOrDefault(s => s.Code == code);
        if (staff == null) return;
        tbFirstName.Text = staff.FirstName;
        tbLastName.Text = staff.LastName;
        cmbGender.SelectedItem = staff.Gender;
        dtpDob.Value = staff.DOB < dtpDob.MinDate ? dtpDob.MinDate : staff.DOB;
        tbPhoneNumber.Text = staff.PhoneNumber;
        tbEmail.Text = staff.Email;
        cmbPosition.SelectedItem = staff.Position;
        cmbDepartment.Text = staff.Department?.Name ?? string.Empty;
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
        if (string.IsNullOrWhiteSpace(text)) _bsUser.DataSource = GlobalState.Users;
        else _bsUser.DataSource = GlobalState.Users.Where(u => 
            u.Username.Contains(text, StringComparison.OrdinalIgnoreCase) || 
            u.Code.Contains(text, StringComparison.OrdinalIgnoreCase) ||
            (u.Staff?.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false)).ToList();
        _bsUser.ResetBindings(false);
    }

    private async Task LoadUsersAsync()
    {
        dgvUser.Enabled = btnRefresh.Enabled = false;
        try
        {
            var users = await _mediator.SendAsync(new GetUsersQuery());
            GlobalState.Users.Clear();
            foreach (var u in users) GlobalState.Users.Add(u.ToDto());
            _bsUser.ResetBindings(false);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        finally { dgvUser.Enabled = btnRefresh.Enabled = true; }
    }

    public new void Dispose() { _searchTimer?.Dispose(); base.Dispose(); }
}
