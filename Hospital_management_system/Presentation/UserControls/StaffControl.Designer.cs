namespace Hospital_management_system.Presentation.UserControls
{
    partial class StaffControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUpdate = new Button();
            tbSearch = new TextBox();
            colUpdatedAt = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colCode = new DataGridViewTextBoxColumn();
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label10 = new Label();
            dtpHireDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(643, 204);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.TabIndex = 28;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(25, 204);
            tbSearch.Multiline = true;
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(402, 38);
            tbSearch.TabIndex = 26;
            // 
            // colUpdatedAt
            // 
            colUpdatedAt.HeaderText = "Updated At";
            colUpdatedAt.Name = "colUpdatedAt";
            // 
            // colCreatedAt
            // 
            colCreatedAt.HeaderText = "Created At";
            colCreatedAt.Name = "colCreatedAt";
            // 
            // colDescription
            // 
            colDescription.HeaderText = "Description";
            colDescription.Name = "colDescription";
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.Name = "colName";
            // 
            // colCode
            // 
            colCode.HeaderText = "Code";
            colCode.Name = "colCode";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(538, 204);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(748, 204);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.TabIndex = 25;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(1139, 204);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(99, 38);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1034, 204);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(3, 47);
            lbName.Margin = new Padding(3, 7, 3, 0);
            lbName.Name = "lbName";
            lbName.Size = new Size(85, 18);
            lbName.TabIndex = 20;
            lbName.Text = "First Name";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(123, 43);
            tbFirstName.Multiline = true;
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(247, 26);
            tbFirstName.TabIndex = 2;
            // 
            // lbCode
            // 
            lbCode.AutoSize = true;
            lbCode.Location = new Point(3, 7);
            lbCode.Margin = new Padding(3, 7, 3, 0);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(47, 18);
            lbCode.TabIndex = 18;
            lbCode.Text = "Code";
            // 
            // tbCode
            // 
            tbCode.Location = new Point(123, 3);
            tbCode.Multiline = true;
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(247, 26);
            tbCode.TabIndex = 1;
            // 
            // dgvStaff
            // 
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.AllowUserToResizeColumns = false;
            dgvStaff.AllowUserToResizeRows = false;
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaff.BackgroundColor = Color.LightGray;
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.Location = new Point(25, 261);
            dgvStaff.MultiSelect = false;
            dgvStaff.Name = "dgvStaff";
            dgvStaff.ReadOnly = true;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.Size = new Size(1250, 414);
            dgvStaff.TabIndex = 16;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(433, 204);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.TabIndex = 15;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 87);
            label1.Margin = new Padding(3, 7, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 18);
            label1.TabIndex = 30;
            label1.Text = "Last Name";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(123, 83);
            tbLastName.Multiline = true;
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(247, 26);
            tbLastName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 127);
            label2.Margin = new Padding(3, 7, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 18);
            label2.TabIndex = 32;
            label2.Text = "Gender";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(419, 127);
            label3.Margin = new Padding(3, 7, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(93, 18);
            label3.TabIndex = 34;
            label3.Text = "Date of birth";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(419, 7);
            label4.Margin = new Padding(3, 7, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(112, 18);
            label4.TabIndex = 36;
            label4.Text = "Phone Number";
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.Location = new Point(539, 3);
            tbPhoneNumber.Multiline = true;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(257, 26);
            tbPhoneNumber.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(419, 47);
            label5.Margin = new Padding(3, 7, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(67, 18);
            label5.TabIndex = 38;
            label5.Text = "Address";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(539, 43);
            tbAddress.Multiline = true;
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(257, 26);
            tbAddress.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(419, 87);
            label6.Margin = new Padding(3, 7, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(48, 18);
            label6.TabIndex = 40;
            label6.Text = "Email";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(539, 83);
            tbEmail.Multiline = true;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(257, 26);
            tbEmail.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(835, 47);
            label7.Margin = new Padding(3, 7, 3, 0);
            label7.Name = "label7";
            label7.Size = new Size(65, 18);
            label7.TabIndex = 42;
            label7.Text = "Position";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(835, 87);
            label8.Margin = new Padding(3, 7, 3, 0);
            label8.Name = "label8";
            label8.Size = new Size(52, 18);
            label8.TabIndex = 44;
            label8.Text = "Salary";
            // 
            // tbSalary
            // 
            tbSalary.Location = new Point(955, 83);
            tbSalary.Multiline = true;
            tbSalary.Name = "tbSalary";
            tbSalary.Size = new Size(258, 26);
            tbSalary.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(835, 7);
            label9.Margin = new Padding(3, 7, 3, 0);
            label9.Name = "label9";
            label9.Size = new Size(90, 18);
            label9.TabIndex = 46;
            label9.Text = "Department";
            // 
            // dtpDob
            // 
            dtpDob.Location = new Point(539, 123);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(257, 26);
            dtpDob.TabIndex = 5;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(123, 123);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(193, 26);
            cmbGender.TabIndex = 4;
            // 
            // cmbPosition
            // 
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(955, 43);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(258, 26);
            cmbPosition.TabIndex = 9;
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(955, 3);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(258, 26);
            cmbDepartment.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.LightGray;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(label10, 4, 3);
            tableLayoutPanel1.Controls.Add(lbCode, 0, 0);
            tableLayoutPanel1.Controls.Add(tbSalary, 5, 2);
            tableLayoutPanel1.Controls.Add(cmbPosition, 5, 1);
            tableLayoutPanel1.Controls.Add(cmbDepartment, 5, 0);
            tableLayoutPanel1.Controls.Add(tbCode, 1, 0);
            tableLayoutPanel1.Controls.Add(lbName, 0, 1);
            tableLayoutPanel1.Controls.Add(label8, 4, 2);
            tableLayoutPanel1.Controls.Add(label9, 4, 0);
            tableLayoutPanel1.Controls.Add(dtpDob, 3, 3);
            tableLayoutPanel1.Controls.Add(label7, 4, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(tbLastName, 1, 2);
            tableLayoutPanel1.Controls.Add(tbFirstName, 1, 1);
            tableLayoutPanel1.Controls.Add(label6, 2, 2);
            tableLayoutPanel1.Controls.Add(tbAddress, 3, 1);
            tableLayoutPanel1.Controls.Add(label4, 2, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 3);
            tableLayoutPanel1.Controls.Add(tbPhoneNumber, 3, 0);
            tableLayoutPanel1.Controls.Add(label5, 2, 1);
            tableLayoutPanel1.Controls.Add(tbEmail, 3, 2);
            tableLayoutPanel1.Controls.Add(cmbGender, 1, 3);
            tableLayoutPanel1.Controls.Add(dtpHireDate, 5, 3);
            tableLayoutPanel1.Location = new Point(25, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(1250, 163);
            tableLayoutPanel1.TabIndex = 47;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(835, 127);
            label10.Margin = new Padding(3, 7, 3, 0);
            label10.Name = "label10";
            label10.Size = new Size(75, 18);
            label10.TabIndex = 48;
            label10.Text = "Hire Date";
            // 
            // dtpHireDate
            // 
            dtpHireDate.Location = new Point(955, 123);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(257, 26);
            dtpHireDate.TabIndex = 47;
            // 
            // StaffControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnUpdate);
            Controls.Add(tbSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnNew);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            Controls.Add(dgvStaff);
            Controls.Add(btnRefresh);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1300, 700);
            MinimumSize = new Size(1300, 700);
            Name = "StaffControl";
            Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private TextBox tbSearch;
        private DataGridViewTextBoxColumn colUpdatedAt;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCode;
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
        private TableLayoutPanel tableLayoutPanel1;
        private Label label10;
        private DateTimePicker dtpHireDate;
    }
}
