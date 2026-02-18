using Hospital_management_system.Application.Common;
using Hospital_management_system.Application.DTOs;
using Hospital_management_system.Application.Mapper;
using Hospital_management_system.Application.Commands.Patients;
using Hospital_management_system.Application.Queries.Patients;
using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.ValueObjects;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls;

public partial class PatientsControl : UserControl, IDisposable
{
    private readonly IMediator _mediator;
    private readonly BindingSource _bsPatient = [];
    private System.Windows.Forms.Timer? _searchTimer;

    private static bool IsNew = false;

    public PatientsControl(IMediator mediator)
    {
        _mediator = mediator;
        InitializeComponent();
        LoadControlsConfiguration();
        DisableControls(true);

        _bsPatient.DataSource = GlobalState.Patients;
        dgvPatient.DataSource = _bsPatient;

        #region Events
        dgvPatient.DataBindingComplete += (s, e) =>
        {
            if (dgvPatient.Columns.Contains("colId")) dgvPatient.Columns["colId"].Visible = false;
            if (dgvPatient.Columns.Contains("colDoctorId")) dgvPatient.Columns["colDoctorId"].Visible = false;
        };
        dgvPatient.SelectionChanged += OnDgvPatientSelectionChanged;
        tbSearch.KeyUp += OnTbSearchKeyUp;
        #endregion

        #region Click Events
        btnRefresh.Click += async (s, e) => await LoadPatientsAsync();
        btnCancel.Click += (s, e) =>
        {
            if (IsNew)
            {
                if (tbCode.Text != string.Empty || tbFirstName.Text != string.Empty || tbLastName.Text != string.Empty)
                {
                    var result = MessageBox.Show("Discard new patient?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) IsNew = false;
                }
                else IsNew = false;
            }
            if (!IsNew) OnDgvPatientSelectionChanged(this, EventArgs.Empty);
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
            if (dgvPatient.CurrentRow == null) return;
            IsNew = false;
            DisableControls(false);
            tbCode.Enabled = false;
            tbFirstName.Focus();
        };
        btnDelete.Click += async (s, e) =>
        {
            if (dgvPatient.CurrentRow?.DataBoundItem is not PatientDto patient) return;

            var confirmResult = MessageBox.Show("Delete this patient?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var result = await _mediator.SendAsync(new DeletePatientCommand(patient.Code));
                if (result.IsSuccess) await LoadPatientsAsync();
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
            var sickness = tbSickness.Text.Trim();
            var docCode = cmbDoctor.Text;
            var doctor = GlobalState.Doctors.FirstOrDefault(d => d.Code == docCode);

            if (doctor == null) { MessageBox.Show("Please select a valid doctor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            Result result;
            if (IsNew)
            {
                result = await _mediator.SendAsync(new CreatePatientCommand(code, firstName, lastName, dob, gender, phone, address, null, sickness, doctor.DoctorId));
            }
            else
            {
                var patient = dgvPatient.CurrentRow?.DataBoundItem as PatientDto;
                if (patient == null) return;
                result = await _mediator.SendAsync(new UpdatePatientCommand(patient.PatientId, code, firstName, lastName, dob, gender, phone, address, null, sickness, doctor.DoctorId, true));
            }

            if (result.IsSuccess)
            {
                await LoadPatientsAsync();
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
        dgvPatient.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
        dgvPatient.DefaultCellStyle.Font = new Font("Arial", 11F);
        
        dtpDob.Format = DateTimePickerFormat.Custom;
        dtpDob.CustomFormat = "dd/MM/yyyy";
        
        cmbGender.DataSource = Enum.GetValues(typeof(PersonGender));
        cmbDoctor.DataSource = GlobalState.Doctors.Select(d => d.Code).ToList();

        dgvPatient.AutoGenerateColumns = false;
        dgvPatient.Columns.AddRange([
            new DataGridViewTextBoxColumn { Name = "colId", DataPropertyName = "PatientId", Visible = false },
            new DataGridViewTextBoxColumn { Name = "colCode", HeaderText = "Code", DataPropertyName = "Code", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells },
            new DataGridViewTextBoxColumn { Name = "colFirstName", HeaderText = "First Name", DataPropertyName = "FirstName", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colLastName", HeaderText = "Last Name", DataPropertyName = "LastName", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colGender", HeaderText = "Gender", DataPropertyName = "Gender", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colDob", HeaderText = "DOB", DataPropertyName = "DOB", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colPhone", HeaderText = "Phone", DataPropertyName = "PhoneNumber", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
            new DataGridViewTextBoxColumn { Name = "colAddress", HeaderText = "Address", DataPropertyName = "Address", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colSickness", HeaderText = "Sickness", DataPropertyName = "Sickness", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = "colDoctor", HeaderText = "Doctor", DataPropertyName = "Doctor.Code", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }
        ]);
        dgvPatient.Columns["colDob"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    private void DisableControls(bool con)
    {
        tbCode.Enabled = tbFirstName.Enabled = tbLastName.Enabled = cmbGender.Enabled = dtpDob.Enabled = 
        tbPhoneNumber.Enabled = tbAddress.Enabled = tbSickness.Enabled = cmbDoctor.Enabled = !con;
        btnCancel.Enabled = btnSubmit.Enabled = !con;
        btnRefresh.Enabled = btnNew.Enabled = btnDelete.Enabled = btnUpdate.Enabled = dgvPatient.Enabled = con;
    }

    private void ClearInputControls()
    {
        tbCode.Clear(); tbFirstName.Clear(); tbLastName.Clear(); tbPhoneNumber.Clear();
        tbAddress.Clear(); tbSickness.Clear(); cmbGender.SelectedIndex = cmbDoctor.SelectedIndex = -1;
    }

    private void OnDgvPatientSelectionChanged(object? sender, EventArgs e)
    {
        if (dgvPatient.CurrentRow?.DataBoundItem is not PatientDto patient) return;
        tbCode.Text = patient.Code;
        tbFirstName.Text = patient.FirstName;
        tbLastName.Text = patient.LastName;
        cmbGender.Text = patient.Gender.ToString();
        dtpDob.Value = patient.DOB;
        tbPhoneNumber.Text = patient.PhoneNumber;
        tbAddress.Text = patient.Address;
        tbSickness.Text = patient.Sickness;
        if (patient.Doctor != null) cmbDoctor.Text = patient.Doctor.Code;
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
        if (string.IsNullOrWhiteSpace(text)) _bsPatient.DataSource = GlobalState.Patients;
        else _bsPatient.DataSource = GlobalState.Patients.Where(p => 
            p.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) || 
            p.LastName.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
        _bsPatient.ResetBindings(false);
    }

    private async Task LoadPatientsAsync()
    {
        dgvPatient.Enabled = btnRefresh.Enabled = false;
        try
        {
            var patients = await _mediator.SendAsync(new GetPatientsQuery());
            GlobalState.Patients.Clear();
            foreach (var p in patients) GlobalState.Patients.Add(p.ToDto());
            _bsPatient.ResetBindings(false);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        finally { dgvPatient.Enabled = btnRefresh.Enabled = true; }
    }

    public new void Dispose() { _searchTimer?.Dispose(); base.Dispose(); }
}
