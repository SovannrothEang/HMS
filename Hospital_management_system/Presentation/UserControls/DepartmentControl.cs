using Hospital_management_system.Application.DTO;
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
        DisableControls();

        _bsDepartments.DataSource = GlobalState.Departments; // set BindingSource data source
        deprtDgv.DataSource = _bsDepartments; // bind DataGridView to BindingSource

        //this.HandleCreated += async (s, e) => 
        //{
        //    if (!DesignMode)
        //        await LoadDepartmentsAsync();
        //};
        deprtDgv.SelectionChanged += DeprtDgv_SelectionChanged;
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
                        if (deprtDgv.CurrentRow != null)
                        {
                            DeprtDgv_SelectionChanged(this, EventArgs.Empty);
                        }
                    }
                }
                else
                {
                    IsNew = false;
                    if (deprtDgv.CurrentRow != null)
                    {
                        DeprtDgv_SelectionChanged(this, EventArgs.Empty);
                    }
                }
            }
            DisableControls();
        };
        btnNew.Click += (s, e) =>
        {
            IsNew = true;
            tbCode.Clear();
            tbName.Clear();
            tbDescription.Clear();
            DisableControls(false);
            tbCode.Cursor = this.Cursor;
        };
        btnUpdate.Click += (s, e) =>
        {
            IsNew = false;
            DisableControls(false);
            tbCode.Cursor = this.Cursor;
        };
        btnSubmit.Click += async (s, e) =>
        {
            var code = tbCode.Text.Trim();
            var name = tbName.Text.Trim();
            var description = tbDescription?.Text.Trim();

            if (!IsNew)
            {
                var id = deprtDgv.CurrentRow!.Cells["colId"].Value!.ToString()!;
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

                _bsDepartments.ResetBindings(false);
            }
            else
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
            }
            DisableControls();
        };
        btnDelete.Click += async (s, e) =>
        {
            if (deprtDgv.CurrentRow == null) return;
            var id = deprtDgv.CurrentRow.Cells["colId"].Value!.ToString()!;
            var confirmResult = MessageBox.Show("Are you sure to delete this department?", 
                "Confirm Delete", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var success = await _repo.DeleteAsync(id);
                if (success)
                {
                    var d = GlobalState.Departments.FirstOrDefault(x => x.DepartmentId == id);
                    if (d != null)
                    {
                        GlobalState.Departments.Remove(d);
                    }
                    _bsDepartments.ResetBindings(false);
                }
                else
                {
                    MessageBox.Show("Failed to delete the department.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        };
    }

    private void LoadControlsConfiguration()
    {
        deprtDgv.AutoGenerateColumns = false;
        deprtDgv.Columns.AddRange([
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
    }

    private void DisableControls(bool con = true)
    {
        if (!con)
        {
            tbCode.ReadOnly = false;
            tbName.ReadOnly = false;
            tbDescription.ReadOnly = false;
        }
        else
        {
            tbCode.ReadOnly = true;
            tbName.ReadOnly = true;
            tbDescription.ReadOnly = true;
        }
    }

    private async Task LoadDepartmentsAsync()
    {
        try
        {
            deprtDgv.Enabled = false;
            var departments = await _repo.GetAllAsync();
            GlobalState.Departments.Clear();
            GlobalState.Departments.AddRange(departments.Select(d => d.ToDto()));
            _bsDepartments.ResetBindings(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            deprtDgv.Enabled = true;
        }
    }

    private void DeprtDgv_SelectionChanged(object? sender, EventArgs e)
    {
        if (deprtDgv.CurrentRow == null) return;

        if (deprtDgv.CurrentRow.DataBoundItem is DepartmentDto selectedDept)
        {
            tbCode.Text = selectedDept.Code;
            tbName.Text = selectedDept.Name;
            tbDescription.Text = selectedDept.Description;
        }
    }
}
