using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class PatientsControl : UserControl
{
    private readonly IGenericRepository<Patient> _repo;
    private readonly IPatientRepository _patientRepo;
    private readonly BindingSource _bsPatient = [];
    private readonly BindingSource _bsDoctorCodes = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private static bool IsNew = false;
    public PatientsControl(IGenericRepository<Patient> repo, IPatientRepository patientRepo)
    {
        _repo = repo;
        _patientRepo = patientRepo;
        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);

        _bsPatient.DataSource = GlobalState.Patients;
        dgvPatient.DataSource = _bsPatient;

        _bsDoctorCodes.DataSource = GlobalState.DoctorsCodeList;

        #region Events
        dgvPatient.DataBindingComplete += (s, e) =>
        {
            if (dgvPatient.Columns.Contains("colId"))
                dgvPatient.Columns["colId"].Visible = false;
        };
        dgvPatient.CellFormatting += (s ,e) => {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPatient.Rows.Count) return;
            var row = dgvPatient.Rows[e.RowIndex];
            if (row == null) return;

            var patient = row.DataBoundItem as PatientDto;

            if (patient != null)
                patient.Doctor = GlobalState.Doctors.First(x => x.DoctorId == patient.DoctorId);

            if (dgvPatient.Columns.Contains("colDoctor"))
                row.Cells["colDoctor"].Value = patient?.Doctor?.Staff?.Code ?? string.Empty;

            dgvPatient.Columns["colDob"].DefaultCellStyle.Format = "dd/MM/yyyy";
        };
        dgvPatient.SelectionChanged += OnDgvPatientSelectionChanged;
        tbSearch.KeyUp += OnTbSearchKeyUp;
        #endregion

        #region Click Events
        btnRefresh.Click += async (s, e) =>
        {
            await LoadPatientsAsync();
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
                    tbSickness.Text != string.Empty)
                {
                    var confirmResult = MessageBox.Show("Discard new patient?",
                        "Confirm Cancel",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        IsNew = false;
                        if (dgvPatient.CurrentRow != null)
                        {
                            OnDgvPatientSelectionChanged(this, EventArgs.Empty);
                        }
                    }
                }
                else
                {
                    IsNew = false;
                    if (dgvPatient.CurrentRow != null)
                    {
                        OnDgvPatientSelectionChanged(this, EventArgs.Empty);
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
            tbPhoneNumber.Clear();
            tbAddress.Clear();
            tbSickness.Clear();
            cmbDoctor.SelectedIndex = -1;
            tbCode.Focus();
            _bsDoctorCodes.ResetBindings(false);
        };
        btnUpdate.Click += (s, e) =>
        {
            IsNew = false;
            DisableControls(false);
            tbCode.Focus();
        };
        btnSubmit.Click += async (s, e) =>
        {
            if (IsNew)
            {
                try
                {
                    if (await CreatePatientAsync())
                    {
                        MessageBox.Show(
                            "Successfully created",
                            "Created patient",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        return;
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Failed to create patient",
                            "Created patient",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    OnDgvPatientSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to create, error: {ex.Message}",
                        "Created patient",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                try
                {
                    var id = dgvPatient.CurrentRow!.Cells["colId"].Value!.ToString()!;
                    if (await UpdatePatientAsync(id))
                    {
                        MessageBox.Show(
                            "Successfully created",
                            "Updated patient",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Failed to update patient",
                            "Updated patient",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    OnDgvPatientSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to update, error: {ex.Message}",
                        "Updated patient",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            OnDgvPatientSelectionChanged(this, EventArgs.Empty);
            DisableControls(true);
        };
        #endregion
    }

    #region UI config
    private void LoadControlsConfiguration()
    {
        dgvPatient.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dgvPatient.DefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);

        dtpDob.Format = DateTimePickerFormat.Custom;
        dtpDob.CustomFormat = "dd/MM/yyyy";
        dtpDob.ShowUpDown = false;

        cmbGender.DataSource = Enum.GetValues(typeof(PersonGender));

        cmbDoctor.DataSource = _bsDoctorCodes;
        cmbDoctor.SelectedIndex = -1;

        dgvPatient.AutoGenerateColumns = false;
        dgvPatient.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvPatient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        #region Columns
        dgvPatient.Columns.AddRange([
            new DataGridViewTextBoxColumn {
                Name = "colId",
                DataPropertyName = "PatientId",
                Visible = false
            },
            new DataGridViewTextBoxColumn {
                Name = "colCode",
                HeaderText = "Code",
                DataPropertyName = "Code",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colFirstName",
                HeaderText = "First Name",
                DataPropertyName = "FirstName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colLastName",
                HeaderText = "Last Name",
                DataPropertyName = "LastName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            },
            new DataGridViewTextBoxColumn {
                Name = "colSickness",
                HeaderText = "Sickness",
                DataPropertyName = "Sickness",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            },
            new DataGridViewTextBoxColumn {
                Name = "colDoctor",
                HeaderText = "Doctor",
                DataPropertyName = "Doctor.Staff.Code",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

        dgvPatient.Columns["colSickness"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
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
        tbSickness.Enabled = !con;
        cmbDoctor.Enabled = !con;

        btnCancel.Enabled = !con;
        btnSubmit.Enabled = !con;
        btnRefresh.Enabled = con;
        btnNew.Enabled = con;
        btnDelete.Enabled = con;
        btnUpdate.Enabled = con;
    }
    #endregion

    #region Events
    private void OnDgvPatientSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvPatient.CurrentRow == null) return;

        if (dgvPatient.CurrentRow.DataBoundItem is PatientDto selectedPatient)
        {
            var doctor = GlobalState.Doctors.FirstOrDefault(d => d.DoctorId == selectedPatient.DoctorId);

            if (doctor != null && doctor.Staff != null)
            {
                tbCode.Text = selectedPatient.Code;
                tbFirstName.Text = selectedPatient.FirstName;
                tbLastName.Text = selectedPatient.LastName;
                cmbGender.Text = selectedPatient.Gender.ToString();
                dtpDob.Value = selectedPatient.DOB;
                tbPhoneNumber.Text = selectedPatient.PhoneNumber;
                tbAddress.Text = selectedPatient.Address;
                tbSickness.Text = selectedPatient.Sickness;
                cmbDoctor.Text = doctor.Staff.Code;
            }
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
            dgvPatient.DataSource = GlobalState.Patients;
            return;
        }

        dgvPatient.DataSource = null;
        _bsPatient.DataSource = GlobalState.Patients
            .Where(d => d.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) == true
                || d.LastName.Contains(text, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();
        dgvPatient.DataSource = _bsPatient;
        _bsPatient.ResetBindings(false);
    }
    #endregion

    #region Helper Methods
    private async Task<bool> CreatePatientAsync()
    {
        var doctorCode = cmbDoctor.SelectedValue?.ToString()!;
        var doctorDto = GlobalState.Doctors.FirstOrDefault(d => d.Staff.Code == doctorCode);
        var dto = GlobalState.Doctors.FirstOrDefault(d => d.DoctorId == doctorDto!.DoctorId);
        var patient = await _repo
            .CreateAsync(new Patient
            {
                PatientId = Guid.NewGuid().ToString(),
                Code = tbCode.Text.Trim(),
                FirstName = tbFirstName.Text.Trim(),
                LastName = tbLastName.Text.Trim(),
                Gender = (PersonGender)cmbGender.SelectedItem!,
                DOB = DateTime.Parse(dtpDob.Value.ToString()),
                PhoneNumber = tbPhoneNumber.Text.Trim(),
                Address = tbAddress.Text.Trim(),
                Sickness = tbSickness.Text.Trim(),
                //Doctor = dto!.ToEntity(dto!.Staff.ToEntity()),
                DoctorId = doctorDto!.DoctorId
            });
        if (patient is null) return false;

        var patientDto = patient.ToDto();
        if (patientDto.Doctor == null)
        {
            var doctor = GlobalState.Doctors
                            .FirstOrDefault(d => d.DoctorId == patient.DoctorId);
            patientDto.Doctor = doctor;
        }

        GlobalState.Patients.Add(patientDto);
        IsNew = false;
        _bsPatient.ResetBindings(false);
        return true;
    }
    private async Task<bool> UpdatePatientAsync(string id)
    {
        var code = tbCode.Text.Trim();
        var firstName = tbFirstName.Text.Trim();
        var lastName = tbLastName.Text.Trim();
        var gender = (PersonGender)cmbGender.SelectedItem!;
        var dob = DateTime.Parse(dtpDob.Value.ToString());
        var phoneNumber = tbPhoneNumber.Text.Trim();
        var address = tbAddress.Text.Trim();
        var sickness = tbSickness.Text.Trim();
        var doctorCode = cmbDoctor.SelectedItem?.ToString()!;
        //var doctorDto = GlobalState.Doctors.FirstOrDefault(d => d.Staff.Code == doctorCode);
        var doctor = GlobalState.Doctors
                .FirstOrDefault(d => d.Staff.Code == doctorCode);
        if (doctor is null) return false;

        var isSuccess = await _repo
            .UpdateAsync(id, new Patient
            {
                PatientId = id,
                Code = code,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DOB = dob,
                PhoneNumber = phoneNumber,
                Address = address,
                Sickness = sickness,
                DoctorId = doctor.DoctorId,
            });
        if (!isSuccess) return false;

        var patient = GlobalState.Patients.FirstOrDefault(s => s.PatientId == id);
        if (patient == null) return false;

        patient.Code = code;
        patient.FirstName = firstName;
        patient.LastName = lastName;
        patient.Gender = gender;
        patient.DOB = dob;
        patient.PhoneNumber = phoneNumber;
        patient.Address = address;
        patient.Sickness = sickness;
        patient.DoctorId = doctorCode!;
        patient.Doctor = doctor;
        patient.Doctor!.Staff = doctor.Staff!;

        IsNew = false;
        _bsPatient.ResetBindings(false);
        OnDgvPatientSelectionChanged(this, EventArgs.Empty);
        return true;
    }
    private async Task LoadPatientsAsync()
    {
        dgvPatient.Enabled = false;
        btnRefresh.Enabled = false;
        try
        {
            var patients = await _patientRepo.GetAllWithDoctorAsync();

            GlobalState.Patients.Clear();
            foreach (var patient in patients)
            {
                GlobalState.Patients.Add(patient.ToDto());
            }

            OnDgvPatientSelectionChanged(this, EventArgs.Empty);
            _bsPatient.ResetBindings(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading patients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnRefresh.Enabled = true;
            dgvPatient.Enabled = true;
        }
    }
    #endregion
}