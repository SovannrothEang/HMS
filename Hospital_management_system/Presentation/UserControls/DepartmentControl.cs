using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class DepartmentControl : UserControl
{
    private readonly IGenericRepository<Department> _repo;
    private readonly BindingSource _bsDepartments = [];

    private static bool IsNew = false;

    public DepartmentControl(IGenericRepository<Department> repo)
    {
        _repo = repo;
        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);

        _bsDepartments.DataSource = GlobalState.Departments; // set BindingSource data source
        dgvDept.DataSource = _bsDepartments; // bind DataGridView to BindingSource
        _bsDepartments.ResetBindings(false);

        #region DGV events
        dgvDept.SelectionChanged += OnDgvDeptSelectionChanged;
        dgvDept.DataBindingComplete += (s, e) =>
        {
            if (dgvDept.Columns.Contains("colId"))
                dgvDept.Columns["colId"].Visible = false;
        };
        //this.Load += async (s, e) => await LoadDepartmentsAsync();
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
            IsNew = false;
            DisableControls(false);
            tbCode.Focus();
        };
        btnSubmit.Click += async (s, e) =>
        {
            var code = tbCode.Text.Trim();
            var name = tbName.Text.Trim();
            var description = tbDescription?.Text.Trim();

            if (!IsNew)
            {
                var id = dgvDept.CurrentRow!.Cells["colId"].Value!.ToString()!;
                try
                {
                    await _repo.UpdateAsync(id, new Department
                    {
                        DepartmentId = id,
                        Code = code,
                        Name = name,
                        Description = description
                    });
                    var d = GlobalState.Departments.FirstOrDefault(x => x.DepartmentId == id);
                    if (d != null)
                    {
                        d.Code = code;
                        d.Name = name;
                        d.Description = description;
                    }

                    IsNew = false;
                    _bsDepartments.ResetBindings(false);

                    MessageBox.Show(
                        "Successfully updated",
                        "Updated department",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to update, error: {ex.Message}",
                        "Updated department",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            else
            {
                try
                {
                    var department = await _repo
                        .CreateAsync(new Department
                        {
                            DepartmentId = Guid.NewGuid().ToString(),
                            Code = code,
                            Name = name,
                            Description = description
                        });
                GlobalState.Departments.Add(department.ToDto());
                IsNew = false;
                _bsDepartments.ResetBindings(false);

                    MessageBox.Show(
                        "Successfully created",
                        "Created department",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to create, error: {ex.Message}",
                        "Created department",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            DisableControls(true);
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvDept.CurrentRow == null) return;
            var id = dgvDept.CurrentRow.Cells["colId"].Value!.ToString()!;
            var confirmResult = MessageBox.Show("Are you sure to delete this department?", 
                "Confirm Delete", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var staffs = GlobalState.Staffs.Where(d => d.DepartmentId == id).ToList();
                if (staffs.Count > 0)
                {
                    MessageBox.Show(
                        "This department is having staffs!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                var success = await _repo.DeleteAsync(id);
                if (success)
                {
                    var d = GlobalState.Departments.FirstOrDefault(x => x.DepartmentId == id);
                    if (d != null)
                    {
                        GlobalState.Departments.Remove(d);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to delete the department.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _bsDepartments.ResetBindings(false);
            }
        };
        #endregion
    }
    #region UI config
    private void LoadControlsConfiguration()
    {
        dgvDept.AutoGenerateColumns = false;

        #region Columns
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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
        #endregion
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
    }
    #endregion

    private async Task LoadDepartmentsAsync()
    {
        dgvDept.Enabled = false;
        btnRefresh.Enabled = false;
        try
        {
            var departments = await _repo.GetAllAsync();

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

    private void OnDgvDeptSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvDept.CurrentRow == null) return;

        if (dgvDept.CurrentRow.DataBoundItem is DepartmentDto selectedDept)
        {
            tbCode.Text = selectedDept.Code;
            tbName.Text = selectedDept.Name;
            tbDescription.Text = selectedDept.Description;
        }
    }
}
