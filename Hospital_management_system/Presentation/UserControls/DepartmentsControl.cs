using Hospital_management_system.Application.Common;
using Hospital_management_system.Application.Commands.Departments;
using Hospital_management_system.Application.Queries.Departments;
using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class DepartmentsControl : UserControl, IDisposable
{
    private readonly IMediator _mediator;
    private readonly BindingSource _bsDepartments = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private static bool IsNew = false;

    public DepartmentsControl(IMediator mediator)
    {
        _mediator = mediator;
        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);

        _bsDepartments.DataSource = GlobalState.Departments;
        dgvDept.DataSource = _bsDepartments;

        #region Events
        dgvDept.SelectionChanged += OnDgvDeptSelectionChanged;
        dgvDept.DataBindingComplete += (s, e) =>
        {
            if (dgvDept.Columns.Contains("colId"))
                dgvDept.Columns["colId"].Visible = false;
        };
        tbSearch.KeyUp += OnTbSearchKeyUp;
        #endregion

        #region Click Events
        btnRefresh.Click += async (s, e) =>
        {
            await LoadDepartmentsAsync();
        };
        btnCancel.Click += (s, e) =>
        {
            if (IsNew)
            {
                if (tbCode.Text != string.Empty ||
                    tbName.Text != string.Empty ||
                    tbDescription.Text != string.Empty)
                {
                    var confirmResult = MessageBox.Show("Discard new department?", 
                        "Confirm Cancel", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        IsNew = false;
                        if (dgvDept.CurrentRow != null)
                        {
                            OnDgvDeptSelectionChanged(this, EventArgs.Empty);
                        }
                    }
                }
                else
                {
                    IsNew = false;
                    if (dgvDept.CurrentRow != null)
                    {
                        OnDgvDeptSelectionChanged(this, EventArgs.Empty);
                    }
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
            DisableControls(false);
            tbCode.Focus();
        };
        btnUpdate.Click += (s, e) =>
        {
            if (dgvDept.CurrentRow == null)
            {
                if (dgvDept.Rows.Count > 0)
                {
                    dgvDept.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Please select a department to update.", "No Department Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            IsNew = false;
            DisableControls(false);
            tbCode.Focus();
        };
        btnSubmit.Click += async (s, e) =>
        {
            var code = tbCode.Text.Trim();
            var name = tbName.Text.Trim();
            var description = tbDescription?.Text.Trim() ?? string.Empty;

            if (IsNew)
            {
                var command = new CreateDepartmentCommand(code, name, description);
                var result = await _mediator.SendAsync(command);

                if (result.IsFailure)
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Refresh state - in real MVP, the presenter would do this
                await LoadDepartmentsAsync();
                
                IsNew = false;
                MessageBox.Show("Successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else    
            {
                var command = new UpdateDepartmentCommand(code, name, description);
                var result = await _mediator.SendAsync(command);

                if (result.IsFailure)
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await LoadDepartmentsAsync();
                
                IsNew = false;
                MessageBox.Show("Successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            OnDgvDeptSelectionChanged(this, EventArgs.Empty);
            DisableControls(true);
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvDept.CurrentRow == null) return;
            
            var code = dgvDept.CurrentRow.Cells["colCode"].Value!.ToString()!;
            var confirmResult = MessageBox.Show("Are you sure to delete this department?", 
                "Confirm Delete", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                var command = new DeleteDepartmentCommand(code);
                var result = await _mediator.SendAsync(command);

                if (result.IsFailure)
                {
                    MessageBox.Show(result.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await LoadDepartmentsAsync();
            }
        };
        #endregion
    }

    #region UI config
    private void LoadControlsConfiguration()
    {
        dgvDept.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dgvDept.DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);

        dgvDept.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvDept.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        dgvDept.AutoGenerateColumns = false;

        dgvDept.Columns.AddRange([
            new DataGridViewTextBoxColumn {
                Name = "colId",
                DataPropertyName = "DepartmentId",
                Visible = false
            },
            new DataGridViewTextBoxColumn {
                Name = "colCode",
                HeaderText = "Code",
                DataPropertyName = "Code",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colName",
                HeaderText = "Name",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            },
            new DataGridViewTextBoxColumn {
                Name = "colDescription",
                HeaderText = "Description",
                DataPropertyName = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            },
            new DataGridViewTextBoxColumn {
                Name = "colCreatedAt",
                HeaderText = "Created At",
                DataPropertyName = "CreatedAt",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colUpdatedAt",
                HeaderText = "Updated At",
                DataPropertyName = "UpdatedAt",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            }
        ]);

        dgvDept.Columns["colCreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
        dgvDept.Columns["colUpdatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }
    private void DisableControls(bool con)
    {
        tbCode.Enabled = !con;
        tbName.Enabled = !con;
        tbDescription.Enabled = !con;

        btnSubmit.Enabled = !con;
        btnCancel.Enabled = !con;
        btnRefresh.Enabled = con;
        btnNew.Enabled = con;
        btnDelete.Enabled = con;
        btnUpdate.Enabled = con;
        dgvDept.Enabled = con;
    }
    #endregion

    #region Events
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

        _searchTimer.Stop();
        _searchTimer.Start();
    }
    private void PerformSearch(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            _bsDepartments.DataSource = GlobalState.Departments;
        }
        else
        {
            _bsDepartments.DataSource = GlobalState.Departments
                .Where(d => d.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        _bsDepartments.ResetBindings(false);
    }
    private void OnDgvDeptSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvDept.CurrentRow?.DataBoundItem is DepartmentDto selectedDept)
        {
            tbCode.Text = selectedDept.Code;
            tbName.Text = selectedDept.Name;
            tbDescription.Text = selectedDept.Description;
        }
    }
    #endregion

    #region Helper methods
    private async Task LoadDepartmentsAsync()
    {
        dgvDept.Enabled = false;
        btnRefresh.Enabled = false;
        try
        {
            var query = new GetDepartmentsQuery();
            var departments = await _mediator.SendAsync(query);

            GlobalState.Departments.Clear();
            foreach (var department in departments)
            {
                GlobalState.Departments.Add(department.ToDto());
            }

            _bsDepartments.ResetBindings(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            dgvDept.Enabled = true;
            btnRefresh.Enabled = true;
        }
    }
    #endregion

    public new void Dispose()
    {
        _searchTimer?.Dispose();
        base.Dispose();
    }
}
