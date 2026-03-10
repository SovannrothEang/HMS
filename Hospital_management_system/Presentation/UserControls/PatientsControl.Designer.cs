namespace Hospital_management_system.Presentation.UserControls
{
    partial class PatientsControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            cmbGender = new ComboBox();
            dtpDob = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            tbAddress = new TextBox();
            label4 = new Label();
            tbPhoneNumber = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tbLastName = new TextBox();
            btnUpdate = new Button();
            tbSearch = new TextBox();
            btnDelete = new Button();
            btnNew = new Button();
            btnSubmit = new Button();
            btnCancel = new Button();
            lbName = new Label();
            tbFirstName = new TextBox();
            lbCode = new Label();
            tbCode = new TextBox();
            dgvPatient = new DataGridView();
            btnRefresh = new Button();
            tlpInput = new TableLayoutPanel();
            label7 = new Label();
            tbSickness = new TextBox();
            cmbDoctor = new ComboBox();
            pnlHeader = new Panel();
            tlpActions = new TableLayoutPanel();
            pnlLeftActions = new FlowLayoutPanel();
            pnlCenterActions = new FlowLayoutPanel();
            pnlRightActions = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvPatient).BeginInit();
            tlpInput.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpActions.SuspendLayout();
            pnlLeftActions.SuspendLayout();
            pnlCenterActions.SuspendLayout();
            pnlRightActions.SuspendLayout();
            SuspendLayout();

            // pnlHeader
            pnlHeader.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(tlpInput);
            pnlHeader.Location = new Point(25, 25);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1250, 150);
            pnlHeader.TabIndex = 76;

            // tlpInput
            tlpInput.ColumnCount = 6;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpInput.Controls.Add(lbCode, 0, 0);
            tlpInput.Controls.Add(tbCode, 1, 0);
            tlpInput.Controls.Add(label2, 2, 0);
            tlpInput.Controls.Add(cmbGender, 3, 0);
            tlpInput.Controls.Add(label5, 4, 0);
            tlpInput.Controls.Add(tbAddress, 5, 0);
            tlpInput.Controls.Add(lbName, 0, 1);
            tlpInput.Controls.Add(tbFirstName, 1, 1);
            tlpInput.Controls.Add(label3, 2, 1);
            tlpInput.Controls.Add(dtpDob, 3, 1);
            tlpInput.Controls.Add(label7, 4, 1);
            tlpInput.Controls.Add(tbSickness, 5, 1);
            tlpInput.Controls.Add(label1, 0, 2);
            tlpInput.Controls.Add(tbLastName, 1, 2);
            tlpInput.Controls.Add(label4, 2, 2);
            tlpInput.Controls.Add(tbPhoneNumber, 3, 2);
            tlpInput.Controls.Add(label6, 4, 2);
            tlpInput.Controls.Add(cmbDoctor, 5, 2);
            tlpInput.Dock = DockStyle.Fill;
            tlpInput.Location = new Point(0, 0);
            tlpInput.Name = "tlpInput";
            tlpInput.Padding = new Padding(10);
            tlpInput.RowCount = 3;
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpInput.Size = new Size(1250, 150);

            lbCode.Text = "Code";
            lbCode.TextAlign = ContentAlignment.MiddleLeft;
            tbCode.Dock = DockStyle.Fill;
            label2.Text = "Gender";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            cmbGender.Dock = DockStyle.Fill;
            label5.Text = "Address";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            tbAddress.Dock = DockStyle.Fill;

            lbName.Text = "First Name";
            lbName.TextAlign = ContentAlignment.MiddleLeft;
            tbFirstName.Dock = DockStyle.Fill;
            label3.Text = "DOB";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            dtpDob.Dock = DockStyle.Fill;
            label7.Text = "Sickness";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            tbSickness.Dock = DockStyle.Fill;

            label1.Text = "Last Name";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            tbLastName.Dock = DockStyle.Fill;
            label4.Text = "Phone";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            tbPhoneNumber.Dock = DockStyle.Fill;
            label6.Text = "Doctor";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            cmbDoctor.Dock = DockStyle.Fill;

            // tlpActions
            tlpActions.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            tlpActions.ColumnCount = 3;
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpActions.Controls.Add(pnlLeftActions, 0, 0);
            tlpActions.Controls.Add(pnlCenterActions, 1, 0);
            tlpActions.Controls.Add(pnlRightActions, 2, 0);
            tlpActions.Location = new Point(25, 205);
            tlpActions.Name = "tlpActions";
            tlpActions.RowCount = 1;
            tlpActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpActions.Size = new Size(1250, 50);

            // pnlLeftActions
            pnlLeftActions.Controls.Add(tbSearch);
            pnlLeftActions.Controls.Add(btnRefresh);
            pnlLeftActions.Dock = DockStyle.Fill;
            pnlLeftActions.Location = new Point(0, 0);
            pnlLeftActions.Name = "pnlLeftActions";

            tbSearch.Margin = new Padding(0, 5, 5, 0);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(402, 38);
            tbSearch.PlaceholderText = "Search patients...";

            btnRefresh.Margin = new Padding(5, 3, 5, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.Text = "Refresh";

            // pnlCenterActions
            pnlCenterActions.Controls.Add(btnDelete);
            pnlCenterActions.Controls.Add(btnUpdate);
            pnlCenterActions.Controls.Add(btnNew);
            pnlCenterActions.Dock = DockStyle.Fill;
            pnlCenterActions.Location = new Point(500, 0);
            pnlCenterActions.Name = "pnlCenterActions";

            btnDelete.Margin = new Padding(5, 3, 5, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.Text = "Delete";

            btnUpdate.Margin = new Padding(5, 3, 5, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.Text = "Update";

            btnNew.Margin = new Padding(5, 3, 5, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.Text = "New";

            // pnlRightActions
            pnlRightActions.Controls.Add(btnSubmit);
            pnlRightActions.Controls.Add(btnCancel);
            pnlRightActions.Dock = DockStyle.Fill;
            pnlRightActions.FlowDirection = FlowDirection.RightToLeft;
            pnlRightActions.Location = new Point(812, 0);
            pnlRightActions.Name = "pnlRightActions";

            btnSubmit.Margin = new Padding(5, 3, 0, 0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(100, 38);
            btnSubmit.Text = "Submit";

            btnCancel.Margin = new Padding(5, 3, 5, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.Text = "Cancel";

            // dgvPatient
            dgvPatient.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            dgvPatient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatient.BackgroundColor = Color.White;
            dgvPatient.BorderStyle = BorderStyle.None;
            dgvPatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatient.Location = new Point(25, 260);
            dgvPatient.MultiSelect = false;
            dgvPatient.Name = "dgvPatient";
            dgvPatient.ReadOnly = true;
            dgvPatient.RowHeadersVisible = false;
            dgvPatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatient.Size = new Size(1250, 415);
            dgvPatient.TabIndex = 61;

            // PatientsControl
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(dgvPatient);
            Controls.Add(tlpActions);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "PatientsControl";
            Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)dgvPatient).EndInit();
            tlpInput.ResumeLayout(false);
            tlpInput.PerformLayout();
            pnlHeader.ResumeLayout(false);
            tlpActions.ResumeLayout(false);
            pnlLeftActions.ResumeLayout(false);
            pnlLeftActions.PerformLayout();
            pnlCenterActions.ResumeLayout(false);
            pnlRightActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cmbGender;
        private DateTimePicker dtpDob;
        private Label label6;
        private Label label5;
        private TextBox tbAddress;
        private Label label4;
        private TextBox tbPhoneNumber;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbLastName;
        private Button btnUpdate;
        private TextBox tbSearch;
        private Button btnDelete;
        private Button btnNew;
        private Button btnSubmit;
        private Button btnCancel;
        private Label lbName;
        private TextBox tbFirstName;
        private Label lbCode;
        private TextBox tbCode;
        private DataGridView dgvPatient;
        private Button btnRefresh;
        private TableLayoutPanel tlpInput;
        private Label label7;
        private TextBox tbSickness;
        private ComboBox cmbDoctor;
        private Panel pnlHeader;
        private TableLayoutPanel tlpActions;
        private FlowLayoutPanel pnlLeftActions;
        private FlowLayoutPanel pnlCenterActions;
        private FlowLayoutPanel pnlRightActions;
    }
}
