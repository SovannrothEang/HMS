using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class PatientControl : UserControl
{
    private readonly IGenericRepository<Patient> _repo;
    private readonly IPatientRepository _patientRepo;
    private readonly BindingSource _bsPatient = [];

    private static bool IsNew = false;
    public PatientControl(IGenericRepository<Patient> repo, IPatientRepository patientRepo)
    {
        _repo = repo;
        _patientRepo = patientRepo;
        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);

        _bsPatient.DataSource = GlobalState.Patients;
        dgvPatient.DataSource = _bsPatient;

        dgvPatient.DataBindingComplete += (s, e) =>
        {
            if (dgvPatient.Columns.Contains("colId"))
                dgvPatient.Columns["colId"].Visible = false;
        };
        dgvPatient.CellFormatting += (s ,e) => {
            try
            {
                PatientDto? patient = dgvPatient.Rows[e.RowIndex].DataBoundItem as PatientDto;
                if (patient != null)
                    patient.Doctor = GlobalState.Doctors.First(x => x.DoctorId == patient.DoctorId);
                //dgvStaff.Rows[e.RowIndex].Cells["colDob"].Value = staff?.DOB.ToShortDateString();
                dgvPatient.Rows[e.RowIndex].Cells["colDoctor"].Value = patient?.Doctor?.Staff?.Code;
            }
            catch
            {
                MessageBox.Show("Error cell formatting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };

        dgvPatient.SelectionChanged += OnDgvPatientSelectionChanged;
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
                    var confirmResult = MessageBox.Show("Discard new staff?",
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
                    await CreatePatientAsync();

                    MessageBox.Show(
                        "Successfully created",
                        "Created staff",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
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
                    await UpdatePatientAsync(id);

                    MessageBox.Show(
                        "Successfully created",
                        "Updated patient",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    OnDgvPatientSelectionChanged(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Failed to create, error: {ex.Message}",
                        "Updated staff",
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
        dtpDob.Format = DateTimePickerFormat.Custom;
        dtpDob.Value = DateTime.Now;

        cmbGender.DataSource = Enum.GetValues(typeof(Gender));

        cmbDoctor.DataSource = GlobalState.DoctorsCodeList;
        cmbDoctor.SelectedIndex = -1;

        dgvPatient.AutoGenerateColumns = false;
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
                Name = "colSickness",
                HeaderText = "Sickness",
                DataPropertyName = "Sickness",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn {
                Name = "colDoctor",
                HeaderText = "Doctor",
                DataPropertyName = "Doctor.Staff.Code",
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
    #endregion

    #region Helper Methods
    private async Task CreatePatientAsync()
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
                            Gender = (Gender)cmbGender.SelectedItem!,
                            DOB = DateTime.Parse(dtpDob.Value.ToString()),
                            PhoneNumber = tbPhoneNumber.Text.Trim(),
                            Address = tbAddress.Text.Trim(),
                            Sickness = tbSickness.Text.Trim(),
                            //Doctor = dto!.ToEntity(dto!.Staff.ToEntity()),
                            DoctorId = doctorDto!.DoctorId
                        });
        var patientDto = patient.ToDto();
        var doctor = GlobalState.Doctors
                            .FirstOrDefault(d => d.DoctorId == patient.DoctorId);
        if (doctor != null) patientDto.Doctor = doctor;

        GlobalState.Patients.Add(patientDto);
        IsNew = false;
        _bsPatient.ResetBindings(false);
    }
    private async Task UpdatePatientAsync(string id)
    {
        var code = tbCode.Text.Trim();
        var firstName = tbFirstName.Text.Trim();
        var lastName = tbLastName.Text.Trim();
        //var gender = Enum.GetName(typeof(Gender), cmbGender.SelectedItem!);
        var gender = (Gender)cmbGender.SelectedItem!;
        var dob = DateTime.Parse(dtpDob.Value.ToString());
        var phoneNumber = tbPhoneNumber.Text.Trim();
        var address = tbAddress.Text.Trim();
        var sickness = tbSickness.Text.Trim();
        var doctorCode = cmbDoctor.SelectedItem?.ToString()!;
        //var doctorDto = GlobalState.Doctors.FirstOrDefault(d => d.Staff.Code == doctorCode);
        var doctor = GlobalState.Doctors
                .FirstOrDefault(d => d.Staff.Code == doctorCode);
        if (doctor is null) return;
        var patient = await _repo
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
        var p = GlobalState.Patients.FirstOrDefault(s => s.PatientId == id);
        if (p != null)
        {
            p.Code = code;
            p.FirstName = firstName;
            p.LastName = lastName;
            p.Gender = gender;
            p.DOB = dob;
            p.PhoneNumber = phoneNumber;
            p.Address = address;
            p.Sickness = sickness;
            p.DoctorId = doctorCode!;
            p.Doctor = doctor;
            p.Doctor!.Staff = doctor.Staff!;
            //var department = GlobalState.Departments
            //                    .FirstOrDefault(d => d.DepartmentId == p.DepartmentId);
        }
        IsNew = false;
        _bsPatient.ResetBindings(false);
        OnDgvPatientSelectionChanged(this, EventArgs.Empty);
    }
    private async Task LoadPatientsAsync()
    {
        dgvPatient.Enabled = false;
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
            dgvPatient.Enabled = true;
        }
    }
    #endregion
}