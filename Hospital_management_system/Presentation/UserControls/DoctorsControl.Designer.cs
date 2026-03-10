namespace Hospital_management_system.Presentation.UserControls
{
    partial class DoctorsControl
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
            cmbCode = new ComboBox();
            lbCode = new Label();
            lbName = new Label();
            cmbSpecialization = new ComboBox();
            label1 = new Label();
            tbLicenseNumber = new TextBox();
            label2 = new Label();
            tbExperinse = new TextBox();
            label3 = new Label();
            dtpHireDate = new DateTimePicker();
            label9 = new Label();
            cmbDepartment = new ComboBox();
            btnUpdate = new Button();
            tbSearch = new TextBox();
            btnDelete = new Button();
            btnNew = new Button();
            btnSubmit = new Button();
            btnCancel = new Button();
            dgvDoctor = new DataGridView();
            btnRefresh = new Button();
            pnlHeader = new Panel();
            tlpInput = new TableLayoutPanel();
            tlpActions = new TableLayoutPanel();
            pnlLeftActions = new FlowLayoutPanel();
            pnlCenterActions = new FlowLayoutPanel();
            pnlRightActions = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvDoctor).BeginInit();
            pnlHeader.SuspendLayout();
            tlpInput.SuspendLayout();
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
            pnlHeader.Size = new Size(1250, 110);
            pnlHeader.TabIndex = 78;

            // tlpInput
            tlpInput.ColumnCount = 6;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpInput.Controls.Add(lbCode, 0, 0);
            tlpInput.Controls.Add(cmbCode, 1, 0);
            tlpInput.Controls.Add(label1, 2, 0);
            tlpInput.Controls.Add(tbLicenseNumber, 3, 0);
            tlpInput.Controls.Add(label3, 4, 0);
            tlpInput.Controls.Add(dtpHireDate, 5, 0);
            tlpInput.Controls.Add(lbName, 0, 1);
            tlpInput.Controls.Add(cmbSpecialization, 1, 1);
            tlpInput.Controls.Add(label2, 2, 1);
            tlpInput.Controls.Add(tbExperinse, 3, 1);
            tlpInput.Controls.Add(label9, 4, 1);
            tlpInput.Controls.Add(cmbDepartment, 5, 1);
            tlpInput.Dock = DockStyle.Fill;
            tlpInput.Location = new Point(0, 0);
            tlpInput.Name = "tlpInput";
            tlpInput.Padding = new Padding(10);
            tlpInput.RowCount = 2;
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpInput.Size = new Size(1250, 110);

            lbCode.Dock = DockStyle.Fill;
            lbCode.Location = new Point(13, 10);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(114, 45);
            lbCode.Text = "Code";
            lbCode.TextAlign = ContentAlignment.MiddleLeft;

            cmbCode.Dock = DockStyle.Fill;
            cmbCode.Location = new Point(133, 15);
            cmbCode.Margin = new Padding(3, 8, 3, 3);
            cmbCode.Name = "cmbCode";

            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(420, 10);
            label1.Name = "label1";
            label1.Size = new Size(114, 45);
            label1.Text = "License";
            label1.TextAlign = ContentAlignment.MiddleLeft;

            tbLicenseNumber.Dock = DockStyle.Fill;
            tbLicenseNumber.Location = new Point(540, 15);
            tbLicenseNumber.Margin = new Padding(3, 8, 3, 3);
            tbLicenseNumber.Name = "tbLicenseNumber";

            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(827, 10);
            label3.Name = "label3";
            label3.Size = new Size(114, 45);
            label3.Text = "Hire Date";
            label3.TextAlign = ContentAlignment.MiddleLeft;

            dtpHireDate.Dock = DockStyle.Fill;
            dtpHireDate.Location = new Point(947, 15);
            dtpHireDate.Margin = new Padding(3, 8, 3, 3);
            dtpHireDate.Name = "dtpHireDate";

            lbName.Dock = DockStyle.Fill;
            lbName.Location = new Point(13, 55);
            lbName.Name = "lbName";
            lbName.Size = new Size(114, 45);
            lbName.Text = "Specialization";
            lbName.TextAlign = ContentAlignment.MiddleLeft;

            cmbSpecialization.Dock = DockStyle.Fill;
            cmbSpecialization.Location = new Point(133, 60);
            cmbSpecialization.Margin = new Padding(3, 8, 3, 3);
            cmbSpecialization.Name = "cmbSpecialization";

            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(420, 55);
            label2.Name = "label2";
            label2.Size = new Size(114, 45);
            label2.Text = "Experience";
            label2.TextAlign = ContentAlignment.MiddleLeft;

            tbExperinse.Dock = DockStyle.Fill;
            tbExperinse.Location = new Point(540, 60);
            tbExperinse.Margin = new Padding(3, 8, 3, 3);
            tbExperinse.Name = "tbExperinse";

            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(827, 55);
            label9.Name = "label9";
            label9.Size = new Size(114, 45);
            label9.Text = "Department";
            label9.TextAlign = ContentAlignment.MiddleLeft;

            cmbDepartment.Dock = DockStyle.Fill;
            cmbDepartment.Location = new Point(947, 60);
            cmbDepartment.Margin = new Padding(3, 8, 3, 3);
            cmbDepartment.Name = "cmbDepartment";

            // tlpActions
            tlpActions.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            tlpActions.ColumnCount = 3;
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpActions.Controls.Add(pnlLeftActions, 0, 0);
            tlpActions.Controls.Add(pnlCenterActions, 1, 0);
            tlpActions.Controls.Add(pnlRightActions, 2, 0);
            tlpActions.Location = new Point(25, 150);
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
            tbSearch.PlaceholderText = "Search doctors...";

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

            // dgvDoctor
            dgvDoctor.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            dgvDoctor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoctor.BackgroundColor = Color.White;
            dgvDoctor.BorderStyle = BorderStyle.None;
            dgvDoctor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoctor.Location = new Point(25, 215);
            dgvDoctor.MultiSelect = false;
            dgvDoctor.Name = "dgvDoctor";
            dgvDoctor.ReadOnly = true;
            dgvDoctor.RowHeadersVisible = false;
            dgvDoctor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctor.Size = new Size(1250, 460);
            dgvDoctor.TabIndex = 61;

            // DoctorsControl
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(dgvDoctor);
            Controls.Add(tlpActions);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "DoctorsControl";
            Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)dgvDoctor).EndInit();
            pnlHeader.ResumeLayout(false);
            tlpInput.ResumeLayout(false);
            tlpActions.ResumeLayout(false);
            pnlLeftActions.ResumeLayout(false);
            pnlLeftActions.PerformLayout();
            pnlCenterActions.ResumeLayout(false);
            pnlRightActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbDepartment;
        private ComboBox cmbSpecialization;
        private DateTimePicker dtpHireDate;
        private Label label9;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbLicenseNumber;
        private Button btnUpdate;
        private TextBox tbSearch;
        private Button btnDelete;
        private Button btnNew;
        private Button btnSubmit;
        private Button btnCancel;
        private Label lbName;
        private TextBox tbExperinse;
        private Label lbCode;
        private DataGridView dgvDoctor;
        private Button btnRefresh;
        private ComboBox cmbCode;
        private Panel pnlHeader;
        private TableLayoutPanel tlpInput;
        private TableLayoutPanel tlpActions;
        private FlowLayoutPanel pnlLeftActions;
        private FlowLayoutPanel pnlCenterActions;
        private FlowLayoutPanel pnlRightActions;
    }
}
