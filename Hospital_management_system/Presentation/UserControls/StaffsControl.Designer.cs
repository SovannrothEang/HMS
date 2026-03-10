namespace Hospital_management_system.Presentation.UserControls
{
    partial class StaffsControl
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
            dgvStaff = new DataGridView();
            btnRefresh = new Button();
            label1 = new Label();
            tbLastName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbPhoneNumber = new TextBox();
            label5 = new Label();
            tbAddress = new TextBox();
            label6 = new Label();
            tbEmail = new TextBox();
            label7 = new Label();
            label8 = new Label();
            tbSalary = new TextBox();
            label9 = new Label();
            dtpDob = new DateTimePicker();
            cmbGender = new ComboBox();
            cmbPosition = new ComboBox();
            cmbDepartment = new ComboBox();
            tlpInput = new TableLayoutPanel();
            label10 = new Label();
            dtpHireDate = new DateTimePicker();
            pnlHeader = new Panel();
            tlpActions = new TableLayoutPanel();
            pnlLeftActions = new FlowLayoutPanel();
            pnlCenterActions = new FlowLayoutPanel();
            pnlRightActions = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
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
            pnlHeader.Size = new Size(1250, 163);
            pnlHeader.TabIndex = 47;

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
            tlpInput.Controls.Add(label4, 2, 0);
            tlpInput.Controls.Add(tbPhoneNumber, 3, 0);
            tlpInput.Controls.Add(label9, 4, 0);
            tlpInput.Controls.Add(cmbDepartment, 5, 0);
            tlpInput.Controls.Add(lbName, 0, 1);
            tlpInput.Controls.Add(tbFirstName, 1, 1);
            tlpInput.Controls.Add(label5, 2, 1);
            tlpInput.Controls.Add(tbAddress, 3, 1);
            tlpInput.Controls.Add(label7, 4, 1);
            tlpInput.Controls.Add(cmbPosition, 5, 1);
            tlpInput.Controls.Add(label1, 0, 2);
            tlpInput.Controls.Add(tbLastName, 1, 2);
            tlpInput.Controls.Add(label6, 2, 2);
            tlpInput.Controls.Add(tbEmail, 3, 2);
            tlpInput.Controls.Add(label8, 4, 2);
            tlpInput.Controls.Add(tbSalary, 5, 2);
            tlpInput.Controls.Add(label2, 0, 3);
            tlpInput.Controls.Add(cmbGender, 1, 3);
            tlpInput.Controls.Add(label3, 2, 3);
            tlpInput.Controls.Add(dtpDob, 3, 3);
            tlpInput.Controls.Add(label10, 4, 3);
            tlpInput.Controls.Add(dtpHireDate, 5, 3);
            tlpInput.Dock = DockStyle.Fill;
            tlpInput.Location = new Point(0, 0);
            tlpInput.Name = "tlpInput";
            tlpInput.Padding = new Padding(10);
            tlpInput.RowCount = 4;
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpInput.Size = new Size(1250, 163);

            lbCode.Text = "Code";
            lbCode.TextAlign = ContentAlignment.MiddleLeft;
            tbCode.Dock = DockStyle.Fill;
            label4.Text = "Phone";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            tbPhoneNumber.Dock = DockStyle.Fill;
            label9.Text = "Department";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            cmbDepartment.Dock = DockStyle.Fill;
            cmbDepartment.TabIndex = 10;

            lbName.Text = "First Name";
            lbName.TextAlign = ContentAlignment.MiddleLeft;
            tbFirstName.Dock = DockStyle.Fill;
            tbFirstName.TabIndex = 2;
            label5.Text = "Address";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            tbAddress.Dock = DockStyle.Fill;
            tbAddress.TabIndex = 7;
            label7.Text = "Position";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            cmbPosition.Dock = DockStyle.Fill;
            cmbPosition.TabIndex = 12;

            label1.Text = "Last Name";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            tbLastName.Dock = DockStyle.Fill;
            tbLastName.TabIndex = 3;
            label6.Text = "Email";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            tbEmail.Dock = DockStyle.Fill;
            tbEmail.TabIndex = 8;
            label8.Text = "Salary";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            tbSalary.Dock = DockStyle.Fill;
            tbSalary.TabIndex = 13;

            label2.Text = "Gender";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            cmbGender.Dock = DockStyle.Fill;
            cmbGender.TabIndex = 4;
            label3.Text = "DOB";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            dtpDob.Dock = DockStyle.Fill;
            dtpDob.TabIndex = 9;
            label10.Text = "Hire Date";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            dtpHireDate.Dock = DockStyle.Fill;
            dtpHireDate.TabIndex = 14;

            // tlpActions
            tlpActions.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            tlpActions.ColumnCount = 3;
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpActions.Controls.Add(pnlLeftActions, 0, 0);
            tlpActions.Controls.Add(pnlCenterActions, 1, 0);
            tlpActions.Controls.Add(pnlRightActions, 2, 0);
            tlpActions.Location = new Point(25, 204);
            tlpActions.Name = "tlpActions";
            tlpActions.RowCount = 1;
            tlpActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpActions.Size = new Size(1250, 50);
            tlpActions.TabIndex = 15;

            // pnlLeftActions
            pnlLeftActions.Controls.Add(tbSearch);
            pnlLeftActions.Controls.Add(btnRefresh);
            pnlLeftActions.Dock = DockStyle.Fill;
            pnlLeftActions.Location = new Point(0, 0);
            pnlLeftActions.Name = "pnlLeftActions";

            tbSearch.Margin = new Padding(0, 5, 5, 0);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(402, 38);
            tbSearch.PlaceholderText = "Search staff...";
            tbSearch.TabIndex = 16;

            btnRefresh.Margin = new Padding(5, 3, 5, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.Text = "Refresh";
            btnRefresh.TabIndex = 17;

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
            btnDelete.TabIndex = 18;

            btnUpdate.Margin = new Padding(5, 3, 5, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.Text = "Update";
            btnUpdate.TabIndex = 19;

            btnNew.Margin = new Padding(5, 3, 5, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.Text = "New";
            btnNew.TabIndex = 20;

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
            btnSubmit.TabIndex = 21;

            btnCancel.Margin = new Padding(5, 3, 5, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.Text = "Cancel";
            btnCancel.TabIndex = 22;

            // dgvStaff
            dgvStaff.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaff.BackgroundColor = Color.White;
            dgvStaff.BorderStyle = BorderStyle.None;
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.Location = new Point(25, 260);
            dgvStaff.MultiSelect = false;
            dgvStaff.Name = "dgvStaff";
            dgvStaff.ReadOnly = true;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.Size = new Size(1250, 415);
            dgvStaff.TabIndex = 0;

            // StaffsControl
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(dgvStaff);
            Controls.Add(tlpActions);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "StaffsControl";
            Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
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
        private DataGridView dgvStaff;
        private Button btnRefresh;
        private Label label1;
        private TextBox tbLastName;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbPhoneNumber;
        private Label label5;
        private TextBox tbAddress;
        private Label label6;
        private TextBox tbEmail;
        private Label label7;
        private Label label8;
        private TextBox tbSalary;
        private Label label9;
        private DateTimePicker dtpDob;
        private ComboBox cmbGender;
        private ComboBox cmbPosition;
        private ComboBox cmbDepartment;
        private TableLayoutPanel tlpInput;
        private Label label10;
        private DateTimePicker dtpHireDate;
        private Panel pnlHeader;
        private TableLayoutPanel tlpActions;
        private FlowLayoutPanel pnlLeftActions;
        private FlowLayoutPanel pnlCenterActions;
        private FlowLayoutPanel pnlRightActions;
    }
}
