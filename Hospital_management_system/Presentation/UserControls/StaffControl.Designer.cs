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
            textBox1 = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(743, 159);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.TabIndex = 28;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 159);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(402, 38);
            textBox1.TabIndex = 26;
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
            btnDelete.Location = new Point(533, 159);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(638, 159);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.TabIndex = 25;
            btnNew.Text = "Add New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(1082, 159);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(99, 38);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(977, 159);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(17, 60);
            lbName.Name = "lbName";
            lbName.Size = new Size(85, 18);
            lbName.TabIndex = 20;
            lbName.Text = "First Name";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(116, 57);
            tbFirstName.Multiline = true;
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(266, 29);
            tbFirstName.TabIndex = 2;
            // 
            // lbCode
            // 
            lbCode.AutoSize = true;
            lbCode.Location = new Point(17, 25);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(47, 18);
            lbCode.TabIndex = 18;
            lbCode.Text = "Code";
            // 
            // tbCode
            // 
            tbCode.Location = new Point(116, 22);
            tbCode.Multiline = true;
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(266, 29);
            tbCode.TabIndex = 1;
            // 
            // dgvStaff
            // 
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.AllowUserToResizeColumns = false;
            dgvStaff.AllowUserToResizeRows = false;
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.Location = new Point(20, 203);
            dgvStaff.MultiSelect = false;
            dgvStaff.Name = "dgvStaff";
            dgvStaff.ReadOnly = true;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.Size = new Size(1164, 476);
            dgvStaff.TabIndex = 16;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(428, 159);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.TabIndex = 15;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 95);
            label1.Name = "label1";
            label1.Size = new Size(84, 18);
            label1.TabIndex = 30;
            label1.Text = "Last Name";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(116, 92);
            tbLastName.Multiline = true;
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(266, 29);
            tbLastName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 130);
            label2.Name = "label2";
            label2.Size = new Size(60, 18);
            label2.TabIndex = 32;
            label2.Text = "Gender";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(431, 130);
            label3.Name = "label3";
            label3.Size = new Size(93, 18);
            label3.TabIndex = 34;
            label3.Text = "Date of birth";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(431, 25);
            label4.Name = "label4";
            label4.Size = new Size(112, 18);
            label4.TabIndex = 36;
            label4.Text = "Phone Number";
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.Location = new Point(549, 22);
            tbPhoneNumber.Multiline = true;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(228, 29);
            tbPhoneNumber.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(431, 60);
            label5.Name = "label5";
            label5.Size = new Size(67, 18);
            label5.TabIndex = 38;
            label5.Text = "Address";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(549, 57);
            tbAddress.Multiline = true;
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(228, 29);
            tbAddress.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(431, 95);
            label6.Name = "label6";
            label6.Size = new Size(48, 18);
            label6.TabIndex = 40;
            label6.Text = "Email";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(549, 92);
            tbEmail.Multiline = true;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(228, 29);
            tbEmail.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(824, 60);
            label7.Name = "label7";
            label7.Size = new Size(65, 18);
            label7.TabIndex = 42;
            label7.Text = "Position";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(824, 95);
            label8.Name = "label8";
            label8.Size = new Size(52, 18);
            label8.TabIndex = 44;
            label8.Text = "Salary";
            // 
            // tbSalary
            // 
            tbSalary.Location = new Point(920, 92);
            tbSalary.Multiline = true;
            tbSalary.Name = "tbSalary";
            tbSalary.Size = new Size(228, 29);
            tbSalary.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(824, 25);
            label9.Name = "label9";
            label9.Size = new Size(90, 18);
            label9.TabIndex = 46;
            label9.Text = "Department";
            // 
            // dtpDob
            // 
            dtpDob.Location = new Point(549, 127);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(266, 26);
            dtpDob.TabIndex = 5;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(116, 127);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(143, 26);
            cmbGender.TabIndex = 4;
            // 
            // cmbPosition
            // 
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(920, 57);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(228, 26);
            cmbPosition.TabIndex = 9;
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(920, 22);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(228, 26);
            cmbDepartment.TabIndex = 11;
            // 
            // StaffControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            Controls.Add(cmbDepartment);
            Controls.Add(cmbPosition);
            Controls.Add(cmbGender);
            Controls.Add(dtpDob);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(tbSalary);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(tbEmail);
            Controls.Add(label5);
            Controls.Add(tbAddress);
            Controls.Add(label4);
            Controls.Add(tbPhoneNumber);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbLastName);
            Controls.Add(btnUpdate);
            Controls.Add(textBox1);
            Controls.Add(btnDelete);
            Controls.Add(btnNew);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            Controls.Add(lbName);
            Controls.Add(tbFirstName);
            Controls.Add(lbCode);
            Controls.Add(tbCode);
            Controls.Add(dgvStaff);
            Controls.Add(btnRefresh);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1200, 700);
            MinimumSize = new Size(1200, 700);
            Name = "StaffControl";
            Size = new Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private TextBox textBox1;
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
    }
}
