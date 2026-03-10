using Hospital_management_system.Presentation.Common;
using Hospital_management_system.Application.Common;
using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Application.Commands.Staffs;
using Hospital_management_system.Application.Queries.Staffs;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class StaffsControl : UserControl, IDisposable
{
    private readonly IMediator _mediator;
    private readonly BindingSource _bsStaffs = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private static bool IsNew = false;

    public StaffsControl(IMediator mediator)
    {
        _mediator = mediator;

        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);

        _bsStaffs.DataSource = GlobalState.Staffs;
        dgvStaff.DataSource = _bsStaffs;

        tbSearch.KeyUp += OnTbSearchKeyUp;

        #region Events
        dgvStaff.DataBindingComplete += (s, e) =>
        {
            if (dgvStaff.Columns.Contains("colId"))
                dgvStaff.Columns["colId"].Visible = false;
        };
        dgvStaff.SelectionChanged += OnDgvStaffSelectionChanged;
        dgvStaff.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvStaff.Rows.Count) return;
            if (dgvStaff.Rows[e.RowIndex].DataBoundItem is not StaffDto staff) return;

            if (dgvStaff.Columns[e.ColumnIndex].Name == "colDepartment")
                e.Value = staff.Department?.Name;
            else if (dgvStaff.Columns[e.ColumnIndex].Name == "colPosition")
                e.Value = staff.Position?.Name;
        };
        #endregion

        #region Click Events
        btnRefresh.Click += async (s, e) => await LoadStaffsAsync();
        btnCancel.Click += (s, e) =>
        {
            if (IsNew)
            {
                if (tbCode.Text != string.Empty || tbFirstName.Text != string.Empty || tbLastName.Text != string.Empty)
                {
                    var result = MessageBox.Show("Discard new staff?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) IsNew = false;
                }
                else IsNew = false;
            }
            if (!IsNew) OnDgvStaffSelectionChanged(this, EventArgs.Empty);
            DisableControls(true);
        };
        btnNew.Click += (s, e) =>
        {
            IsNew = true;
            DisableControls(false);
            ClearInputControls();
            tbCode.Focus();
        };
        btnUpdate.Click += (s, e) =>
        {
            if (dgvStaff.CurrentRow == null) return;
            IsNew = false;
            DisableControls(false);
            tbCode.Enabled = false;
            tbFirstName.Focus();
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvStaff.CurrentRow?.DataBoundItem is not StaffDto staff) return;

            var confirmResult = MessageBox.Show("Delete this staff?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var result = await _mediator.SendAsync(new DeleteStaffCommand(staff.Code));
                if (result.IsSuccess) await LoadStaffsAsync();
                else MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        btnSubmit.Click += async (s, e) =>
        {
            var code = tbCode.Text.Trim();
            var firstName = tbFirstName.Text.Trim();
            var lastName = tbLastName.Text.Trim();
            var gender = (PersonGender)cmbGender.SelectedItem!;
            var dob = dtpDob.Value.Date;
            var phone = tbPhoneNumber.Text.Trim();
            var address = tbAddress.Text.Trim();
            var email = tbEmail.Text.Trim();
            var positionId = cmbPosition.SelectedValue?.ToString() ?? string.Empty;
            var salary = decimal.TryParse(tbSalary.Text, out var sal) ? sal : 0;
            var hiredDate = dtpHireDate.Value.Date;
            var deptId = cmbDepartment.SelectedValue?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(positionId))
            {
                MessageBox.Show("Please select a position.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result result;
            if (IsNew)
            {
                result = await _mediator.SendAsync(new CreateStaffCommand(code, firstName, lastName, dob, gender, phone, address, email, positionId, hiredDate, salary, deptId));
            }
            else
            {
                var staff = dgvStaff.CurrentRow?.DataBoundItem as StaffDto;
                if (staff == null) return;

                // Guard: Prevent changing position from Doctor if Doctor info exists
                if (staff.Position?.Name == "Doctor" && positionId != staff.PositionId)
                {
                    if (GlobalState.Doctors.Any(d => d.StaffId == staff.StaffId))
                    {
                        MessageBox.Show("Cannot change position from Doctor because this staff member has associated Doctor information. Please delete the Doctor record from the Doctors module first.", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                result = await _mediator.SendAsync(new UpdateStaffCommand(staff.StaffId, code, firstName, lastName, dob, gender, phone, address, email, positionId, hiredDate, salary, deptId, true));
            }

            if (result.IsSuccess)
            {
                await LoadStaffsAsync();
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
        dgvStaff.ApplyModernGridStyle();
        btnRefresh.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(52, 152, 219), System.Drawing.Color.White);
        btnNew.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(46, 204, 113), System.Drawing.Color.White);
        btnUpdate.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(241, 196, 15), System.Drawing.Color.White);
        btnDelete.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(231, 76, 60), System.Drawing.Color.White);
        btnSubmit.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(46, 204, 113), System.Drawing.Color.White);
        btnCancel.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(149, 165, 166), System.Drawing.Color.White);
        tlpInput?.ApplyModernInputStyles();
        tbSearch?.ApplyModernTextBoxStyle();

        
        
        
        dtpDob.Format = dtpHireDate.Format = DateTimePickerFormat.Custom;
        dtpDob.CustomFormat = dtpHireDate.CustomFormat = "dd/MM/yyyy";
        
        cmbGender.DataSource = Enum.GetValues(typeof(PersonGender));
        
        cmbPosition.DataSource = GlobalState.Positions;
        cmbPosition.DisplayMember = "Name";
        cmbPosition.ValueMember = "PositionId";

        cmbDepartment.DataSource = GlobalState.Departments;
        cmbDepartment.DisplayMember = "Name";
        cmbDepartment.ValueMember = "DepartmentId";

        dgvStaff.AutoGenerateColumns = false;
        dgvStaff.Columns.AddRange([
            new DataGridViewTextBoxColumn { Name = "colId", DataPropertyName = "StaffId", Visible = false },
            new DataGridViewTextBoxColumn { Name = "colCode", HeaderText = "Code", DataPropertyName = "Code", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colFirstName", HeaderText = "First Name", DataPropertyName = "FirstName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colLastName", HeaderText = "Last Name", DataPropertyName = "LastName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colGender", HeaderText = "Gender", DataPropertyName = "Gender", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colDob", HeaderText = "DOB", DataPropertyName = "DOB", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colPhone", HeaderText = "Phone", DataPropertyName = "PhoneNumber", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email", DataPropertyName = "Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colPosition", HeaderText = "Position", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colSalary", HeaderText = "Salary", DataPropertyName = "Salary", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colDepartment", HeaderText = "Department", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells }
        ]);
        dgvStaff.Columns["colDob"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    private void DisableControls(bool con)
    {
        tbCode.Enabled = tbFirstName.Enabled = tbLastName.Enabled = cmbGender.Enabled = dtpDob.Enabled = 
        tbPhoneNumber.Enabled = tbAddress.Enabled = tbEmail.Enabled = cmbPosition.Enabled = 
        tbSalary.Enabled = dtpHireDate.Enabled = cmbDepartment.Enabled = !con;
        btnCancel.Enabled = btnSubmit.Enabled = !con;
        btnRefresh.Enabled = btnNew.Enabled = btnDelete.Enabled = btnUpdate.Enabled = dgvStaff.Enabled = con;
    }

    private void ClearInputControls()
    {
        tbCode.Clear(); tbFirstName.Clear(); tbLastName.Clear(); tbPhoneNumber.Clear();
        tbAddress.Clear(); tbEmail.Clear(); tbSalary.Clear();
        cmbGender.SelectedIndex = cmbPosition.SelectedIndex = cmbDepartment.SelectedIndex = -1;
    }

    private void OnDgvStaffSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvStaff.CurrentRow?.DataBoundItem is not StaffDto staff) return;
        tbCode.Text = staff.Code;
        tbFirstName.Text = staff.FirstName;
        tbLastName.Text = staff.LastName;
        cmbGender.SelectedItem = staff.Gender;
        dtpDob.Value = staff.DOB < dtpDob.MinDate ? dtpDob.MinDate : staff.DOB;
        tbPhoneNumber.Text = staff.PhoneNumber;
        tbAddress.Text = staff.Address;
        tbEmail.Text = staff.Email;
        cmbPosition.SelectedValue = staff.PositionId;
        tbSalary.Text = staff.Salary.ToString();
        dtpHireDate.Value = staff.HiredDate < dtpHireDate.MinDate ? dtpHireDate.MinDate : staff.HiredDate;
        if (!string.IsNullOrEmpty(staff.DepartmentId))
        {
            cmbDepartment.SelectedValue = staff.DepartmentId;
        }
        else
        {
            cmbDepartment.SelectedIndex = -1;
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
        if (string.IsNullOrWhiteSpace(text)) _bsStaffs.DataSource = GlobalState.Staffs;
        else _bsStaffs.DataSource = GlobalState.Staffs.Where(s => 
            s.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) || 
            s.LastName.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
        _bsStaffs.ResetBindings(false);
    }

    private async Task LoadStaffsAsync()
    {
        dgvStaff.Enabled = btnRefresh.Enabled = false;
        try
        {
            var staffs = await _mediator.SendAsync(new GetStaffsQuery());
            GlobalState.Staffs.Clear();
            foreach (var s in staffs) GlobalState.Staffs.Add(s.ToDto());
            _bsStaffs.ResetBindings(false);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        finally { dgvStaff.Enabled = btnRefresh.Enabled = true; }
    }

    public new void Dispose() { _searchTimer?.Dispose(); base.Dispose(); }
}
