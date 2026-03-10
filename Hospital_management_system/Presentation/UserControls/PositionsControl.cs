using Hospital_management_system.Presentation.Common;
using Hospital_management_system.Application.Common;
using Hospital_management_system.Application.Commands.Positions;
using Hospital_management_system.Application.Queries.Positions;
using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class PositionsControl : UserControl, IDisposable
{
    private readonly IMediator _mediator;
    private readonly BindingSource _bsPositions = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private static bool IsNew = false;

    public PositionsControl(IMediator mediator)
    {
        _mediator = mediator;
        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);

        _bsPositions.DataSource = GlobalState.Positions;
        dgvPosition.DataSource = _bsPositions;

        this.Load += async (s, e) =>
        {
            await LoadPositionsAsync();
            dgvPosition.Focus();
            if (dgvPosition.Rows.Count > 0)
            {
                dgvPosition.Rows[0].Selected = true;
                OnDgvPositionSelectionChanged(this, EventArgs.Empty);
            }
        };

        #region Events
        dgvPosition.SelectionChanged += OnDgvPositionSelectionChanged;
        dgvPosition.DataBindingComplete += (s, e) =>
        {
            if (dgvPosition.Columns.Contains("colId"))
                dgvPosition.Columns["colId"].Visible = false;
        };
        dgvPosition.CellFormatting += (s, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPosition.Rows.Count) return;
            if (dgvPosition.Rows[e.RowIndex].DataBoundItem is not PositionDto pos) return;

            if (dgvPosition.Columns[e.ColumnIndex].Name == "colDepartment")
                e.Value = pos.Department?.Name;
        };
        tbSearch.KeyUp += OnTbSearchKeyUp;
        #endregion

        #region Click Events
        btnRefresh.Click += async (s, e) => await LoadPositionsAsync();
        btnCancel.Click += (s, e) =>
        {
            if (IsNew)
            {
                if (tbCode.Text != string.Empty || tbName.Text != string.Empty)
                {
                    var confirmResult = MessageBox.Show("Discard new position?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        IsNew = false;
                        if (dgvPosition.CurrentRow != null) OnDgvPositionSelectionChanged(this, EventArgs.Empty);
                    }
                }
                else
                {
                    IsNew = false;
                    if (dgvPosition.CurrentRow != null) OnDgvPositionSelectionChanged(this, EventArgs.Empty);
                }
            }
            DisableControls(true);
        };
        btnNew.Click += (s, e) =>
        {
            IsNew = true;
            tbCode.Clear();
            tbName.Clear();
            tbDescription.Clear();
            cmbDepartment.SelectedIndex = -1;
            DisableControls(false);
            tbCode.Focus();
        };
        btnUpdate.Click += (s, e) =>
        {
            if (dgvPosition.CurrentRow == null) return;
            IsNew = false;
            DisableControls(false);
            tbCode.Enabled = false;
            tbName.Focus();
        };
        btnSubmit.Click += async (s, e) =>
        {
            var code = tbCode.Text.Trim();
            var name = tbName.Text.Trim();
            var description = tbDescription.Text.Trim();
            var deptId = cmbDepartment.SelectedValue?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(deptId))
            {
                MessageBox.Show("Code, Name, and Department cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result result;
            if (IsNew)
            {
                result = await _mediator.SendAsync(new CreatePositionCommand(code, name, description, deptId));
            }
            else
            {
                var pos = dgvPosition.CurrentRow?.DataBoundItem as PositionDto;
                if (pos == null) return;
                result = await _mediator.SendAsync(new UpdatePositionCommand(pos.PositionId, code, name, description, deptId, true));
            }

            if (result.IsSuccess)
            {
                await LoadPositionsAsync();
                IsNew = false;
                DisableControls(true);
                MessageBox.Show("Operation successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvPosition.CurrentRow?.DataBoundItem is not PositionDto pos) return;

            var confirmResult = MessageBox.Show("Delete this position?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var result = await _mediator.SendAsync(new DeletePositionCommand(pos.Code));
                if (result.IsSuccess) await LoadPositionsAsync();
                else MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
        #endregion
    }

    private void LoadControlsConfiguration()
    {
        dgvPosition.ApplyModernGridStyle();
        btnRefresh.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(52, 152, 219), System.Drawing.Color.White);
        btnNew.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(46, 204, 113), System.Drawing.Color.White);
        btnUpdate.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(241, 196, 15), System.Drawing.Color.White);
        btnDelete.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(231, 76, 60), System.Drawing.Color.White);
        btnSubmit.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(46, 204, 113), System.Drawing.Color.White);
        btnCancel.ApplyModernButtonStyle(System.Drawing.Color.FromArgb(149, 165, 166), System.Drawing.Color.White);
        tlpInput?.ApplyModernInputStyles();
        tbSearch?.ApplyModernTextBoxStyle();

        cmbDepartment.DataSource = GlobalState.Departments;
        cmbDepartment.DisplayMember = "Name";
        cmbDepartment.ValueMember = "DepartmentId";

        dgvPosition.AutoGenerateColumns = false;
        dgvPosition.Columns.AddRange([
            new DataGridViewTextBoxColumn { Name = "colId", DataPropertyName = "PositionId", Visible = false },
            new DataGridViewTextBoxColumn { Name = "colCode", HeaderText = "Code", DataPropertyName = "Code", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "Name", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colDepartment", HeaderText = "Department", DataPropertyName = "Department.Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colDescription", HeaderText = "Description", DataPropertyName = "Description", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colCreatedAt", HeaderText = "Created At", DataPropertyName = "CreatedAt", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells }
        ]);
        dgvPosition.Columns["colCreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    private void DisableControls(bool con)
    {
        tbCode.Enabled = tbName.Enabled = tbDescription.Enabled = cmbDepartment.Enabled = !con;
        btnCancel.Enabled = btnSubmit.Enabled = !con;
        btnRefresh.Enabled = btnNew.Enabled = btnDelete.Enabled = btnUpdate.Enabled = dgvPosition.Enabled = con;
    }

    private void OnDgvPositionSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvPosition.CurrentRow?.DataBoundItem is not PositionDto pos) return;
        tbCode.Text = pos.Code;
        tbName.Text = pos.Name;
        tbDescription.Text = pos.Description;
        cmbDepartment.SelectedValue = pos.DepartmentId;
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
        if (string.IsNullOrWhiteSpace(text)) _bsPositions.DataSource = GlobalState.Positions;
        else _bsPositions.DataSource = GlobalState.Positions.Where(p => 
            p.Name.Contains(text, StringComparison.OrdinalIgnoreCase) || 
            p.Code.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
        _bsPositions.ResetBindings(false);
    }

    private async Task LoadPositionsAsync()
    {
        dgvPosition.Enabled = btnRefresh.Enabled = false;
        try
        {
            var positions = await _mediator.SendAsync(new GetPositionsQuery());
            GlobalState.Positions.Clear();
            foreach (var p in positions) GlobalState.Positions.Add(p);
            _bsPositions.ResetBindings(false);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        finally { dgvPosition.Enabled = btnRefresh.Enabled = true; }
    }

    public new void Dispose() { _searchTimer?.Dispose(); base.Dispose(); }
}
