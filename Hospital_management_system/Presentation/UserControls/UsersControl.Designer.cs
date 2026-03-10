namespace Hospital_management_system.Presentation.UserControls
{
    partial class UsersControl
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
            lbCode = new Label();
            cmbPosition = new ComboBox();
            cmbDepartment = new ComboBox();
            lbName = new Label();
            label9 = new Label();
            dtpDob = new DateTimePicker();
            label7 = new Label();
            label1 = new Label();
            label2 = new Label();
            tbLastName = new TextBox();
            label6 = new Label();
            tbPhoneNumber = new TextBox();
            tbEmail = new TextBox();
            cmbGender = new ComboBox();
            tlpInput = new TableLayoutPanel();
            cmbCode = new ComboBox();
            label4 = new Label();
            tbFirstName = new TextBox();
            label3 = new Label();
            label5 = new Label();
            tbUsername = new TextBox();
            label8 = new Label();
            tbPassword = new TextBox();
            btnDelete = new Button();
            btnNew = new Button();
            btnSubmit = new Button();
            btnCancel = new Button();
            dgvUser = new DataGridView();
            btnUpdate = new Button();
            tbSearch = new TextBox();
            btnRefresh = new Button();
            pnlHeader = new Panel();
            tlpActions = new TableLayoutPanel();
            pnlLeftActions = new FlowLayoutPanel();
            pnlCenterActions = new FlowLayoutPanel();
            pnlRightActions = new FlowLayoutPanel();
            tlpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUser).BeginInit();
            pnlHeader.SuspendLayout();
            tlpActions.SuspendLayout();
            pnlLeftActions.SuspendLayout();
            pnlCenterActions.SuspendLayout();
            pnlRightActions.SuspendLayout();
            SuspendLayout();
            // 
            // lbCode
            // 
            lbCode.Location = new Point(13, 10);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(100, 23);
            lbCode.TabIndex = 0;
            lbCode.Text = "Code";
            lbCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbPosition
            // 
            cmbPosition.Dock = DockStyle.Fill;
            cmbPosition.Location = new Point(953, 48);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(284, 31);
            cmbPosition.TabIndex = 11;
            // 
            // cmbDepartment
            // 
            cmbDepartment.Dock = DockStyle.Fill;
            cmbDepartment.Location = new Point(953, 13);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(284, 31);
            cmbDepartment.TabIndex = 5;
            // 
            // lbName
            // 
            lbName.Location = new Point(13, 45);
            lbName.Name = "lbName";
            lbName.Size = new Size(100, 23);
            lbName.TabIndex = 6;
            lbName.Text = "First Name";
            lbName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Location = new Point(833, 10);
            label9.Name = "label9";
            label9.Size = new Size(100, 23);
            label9.TabIndex = 4;
            label9.Text = "Department";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpDob
            // 
            dtpDob.Dock = DockStyle.Fill;
            dtpDob.Location = new Point(953, 83);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(284, 30);
            dtpDob.TabIndex = 17;
            // 
            // label7
            // 
            label7.Location = new Point(833, 45);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 10;
            label7.Text = "Position";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Location = new Point(13, 80);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 12;
            label1.Text = "Last Name";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(423, 45);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 8;
            label2.Text = "Gender";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbLastName
            // 
            tbLastName.Dock = DockStyle.Fill;
            tbLastName.Location = new Point(133, 83);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(284, 30);
            tbLastName.TabIndex = 13;
            // 
            // label6
            // 
            label6.Location = new Point(423, 80);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 14;
            label6.Text = "Email";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.Dock = DockStyle.Fill;
            tbPhoneNumber.Location = new Point(543, 13);
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(284, 30);
            tbPhoneNumber.TabIndex = 3;
            // 
            // tbEmail
            // 
            tbEmail.Dock = DockStyle.Fill;
            tbEmail.Location = new Point(543, 83);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(284, 30);
            tbEmail.TabIndex = 15;
            // 
            // cmbGender
            // 
            cmbGender.Dock = DockStyle.Fill;
            cmbGender.Location = new Point(543, 48);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(284, 31);
            cmbGender.TabIndex = 9;
            // 
            // tlpInput
            // 
            tlpInput.ColumnCount = 6;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpInput.Controls.Add(lbCode, 0, 0);
            tlpInput.Controls.Add(cmbCode, 1, 0);
            tlpInput.Controls.Add(label4, 2, 0);
            tlpInput.Controls.Add(tbPhoneNumber, 3, 0);
            tlpInput.Controls.Add(label9, 4, 0);
            tlpInput.Controls.Add(cmbDepartment, 5, 0);
            tlpInput.Controls.Add(lbName, 0, 1);
            tlpInput.Controls.Add(tbFirstName, 1, 1);
            tlpInput.Controls.Add(label2, 2, 1);
            tlpInput.Controls.Add(cmbGender, 3, 1);
            tlpInput.Controls.Add(label7, 4, 1);
            tlpInput.Controls.Add(cmbPosition, 5, 1);
            tlpInput.Controls.Add(label1, 0, 2);
            tlpInput.Controls.Add(tbLastName, 1, 2);
            tlpInput.Controls.Add(label6, 2, 2);
            tlpInput.Controls.Add(tbEmail, 3, 2);
            tlpInput.Controls.Add(label3, 4, 2);
            tlpInput.Controls.Add(dtpDob, 5, 2);
            tlpInput.Controls.Add(label5, 0, 3);
            tlpInput.Controls.Add(tbUsername, 1, 3);
            tlpInput.Controls.Add(label8, 2, 3);
            tlpInput.Controls.Add(tbPassword, 3, 3);
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
            tlpInput.TabIndex = 0;
            // 
            // cmbCode
            // 
            cmbCode.Dock = DockStyle.Fill;
            cmbCode.Location = new Point(133, 13);
            cmbCode.Name = "cmbCode";
            cmbCode.Size = new Size(284, 31);
            cmbCode.TabIndex = 1;
            // 
            // label4
            // 
            label4.Location = new Point(423, 10);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 2;
            label4.Text = "Phone";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbFirstName
            // 
            tbFirstName.Dock = DockStyle.Fill;
            tbFirstName.Location = new Point(133, 48);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(284, 30);
            tbFirstName.TabIndex = 7;
            // 
            // label3
            // 
            label3.Location = new Point(833, 80);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 16;
            label3.Text = "DOB";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(13, 115);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 18;
            label5.Text = "Username";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbUsername
            // 
            tbUsername.Dock = DockStyle.Fill;
            tbUsername.Location = new Point(133, 118);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(284, 30);
            tbUsername.TabIndex = 19;
            // 
            // label8
            // 
            label8.Location = new Point(423, 115);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 20;
            label8.Text = "Password";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbPassword
            // 
            tbPassword.Dock = DockStyle.Fill;
            tbPassword.Location = new Point(543, 118);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(284, 30);
            tbPassword.TabIndex = 21;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(5, 3);
            btnDelete.Margin = new Padding(5, 3, 5, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            // 
            // btnNew
            // 
            btnNew.Location = new Point(5, 44);
            btnNew.Margin = new Padding(5, 3, 5, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.TabIndex = 2;
            btnNew.Text = "New";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(332, 3);
            btnSubmit.Margin = new Padding(5, 3, 0, 0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(100, 38);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Submit";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(223, 3);
            btnCancel.Margin = new Padding(5, 3, 5, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            // 
            // dgvUser
            // 
            dgvUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUser.BackgroundColor = Color.White;
            dgvUser.BorderStyle = BorderStyle.None;
            dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUser.Location = new Point(25, 260);
            dgvUser.MultiSelect = false;
            dgvUser.Name = "dgvUser";
            dgvUser.ReadOnly = true;
            dgvUser.RowHeadersVisible = false;
            dgvUser.RowHeadersWidth = 51;
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUser.Size = new Size(1250, 415);
            dgvUser.TabIndex = 51;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(114, 3);
            btnUpdate.Margin = new Padding(5, 3, 5, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(0, 5);
            tbSearch.Margin = new Padding(0, 5, 5, 0);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Search users...";
            tbSearch.Size = new Size(402, 30);
            tbSearch.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(5, 38);
            btnRefresh.Margin = new Padding(5, 3, 5, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            // 
            // pnlHeader
            // 
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(tlpInput);
            pnlHeader.Location = new Point(25, 25);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1250, 163);
            pnlHeader.TabIndex = 56;
            // 
            // tlpActions
            // 
            tlpActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            tlpActions.TabIndex = 52;
            // 
            // pnlLeftActions
            // 
            pnlLeftActions.Controls.Add(tbSearch);
            pnlLeftActions.Controls.Add(btnRefresh);
            pnlLeftActions.Dock = DockStyle.Fill;
            pnlLeftActions.Location = new Point(3, 3);
            pnlLeftActions.Name = "pnlLeftActions";
            pnlLeftActions.Size = new Size(494, 44);
            pnlLeftActions.TabIndex = 0;
            // 
            // pnlCenterActions
            // 
            pnlCenterActions.Controls.Add(btnDelete);
            pnlCenterActions.Controls.Add(btnUpdate);
            pnlCenterActions.Controls.Add(btnNew);
            pnlCenterActions.Dock = DockStyle.Fill;
            pnlCenterActions.Location = new Point(503, 3);
            pnlCenterActions.Name = "pnlCenterActions";
            pnlCenterActions.Size = new Size(306, 44);
            pnlCenterActions.TabIndex = 1;
            // 
            // pnlRightActions
            // 
            pnlRightActions.Controls.Add(btnSubmit);
            pnlRightActions.Controls.Add(btnCancel);
            pnlRightActions.Dock = DockStyle.Fill;
            pnlRightActions.FlowDirection = FlowDirection.RightToLeft;
            pnlRightActions.Location = new Point(815, 3);
            pnlRightActions.Name = "pnlRightActions";
            pnlRightActions.Size = new Size(432, 44);
            pnlRightActions.TabIndex = 2;
            // 
            // UsersControl
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(dgvUser);
            Controls.Add(tlpActions);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "UsersControl";
            Size = new Size(1300, 700);
            tlpInput.ResumeLayout(false);
            tlpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUser).EndInit();
            pnlHeader.ResumeLayout(false);
            tlpActions.ResumeLayout(false);
            pnlLeftActions.ResumeLayout(false);
            pnlLeftActions.PerformLayout();
            pnlCenterActions.ResumeLayout(false);
            pnlRightActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lbCode;
        private ComboBox cmbPosition;
        private ComboBox cmbDepartment;
        private Label lbName;
        private Label label9;
        private DateTimePicker dtpDob;
        private Label label7;
        private Label label1;
        private Label label2;
        private TextBox tbLastName;
        private Label label6;
        private TextBox tbPhoneNumber;
        private TextBox tbEmail;
        private ComboBox cmbGender;
        private TableLayoutPanel tlpInput;
        private TextBox tbFirstName;
        private Label label4;
        private Label label3;
        private Button btnDelete;
        private Button btnNew;
        private Button btnSubmit;
        private Button btnCancel;
        private DataGridView dgvUser;
        private Button btnUpdate;
        private TextBox tbSearch;
        private Button btnRefresh;
        private TextBox tbUsername;
        private Label label5;
        private Label label8;
        private TextBox tbPassword;
        private ComboBox cmbCode;
        private Panel pnlHeader;
        private TableLayoutPanel tlpActions;
        private FlowLayoutPanel pnlLeftActions;
        private FlowLayoutPanel pnlCenterActions;
        private FlowLayoutPanel pnlRightActions;
    }
}
