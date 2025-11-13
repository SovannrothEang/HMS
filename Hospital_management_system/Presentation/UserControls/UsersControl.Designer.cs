namespace Hospital_management_system.Presentation.UserControls
{
    partial class UsersControl
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
            tableLayoutPanel1 = new TableLayoutPanel();
            cmbCode = new ComboBox();
            label8 = new Label();
            tbUsername = new TextBox();
            label5 = new Label();
            tbFirstName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            tbPassword = new TextBox();
            btnDelete = new Button();
            btnNew = new Button();
            btnSubmit = new Button();
            btnCancel = new Button();
            dgvUser = new DataGridView();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colUpdatedAt = new DataGridViewTextBoxColumn();
            btnUpdate = new Button();
            tbSearch = new TextBox();
            btnRefresh = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUser).BeginInit();
            SuspendLayout();
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
            dtpDob.Location = new Point(955, 83);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(257, 26);
            dtpDob.TabIndex = 5;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(419, 47);
            label2.Margin = new Padding(3, 7, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 18);
            label2.TabIndex = 32;
            label2.Text = "Gender";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(123, 83);
            tbLastName.Multiline = true;
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(247, 26);
            tbLastName.TabIndex = 3;
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
            // tbPhoneNumber
            // 
            tbPhoneNumber.Location = new Point(539, 3);
            tbPhoneNumber.Multiline = true;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(257, 26);
            tbPhoneNumber.TabIndex = 6;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(539, 83);
            tbEmail.Multiline = true;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(257, 26);
            tbEmail.TabIndex = 8;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(539, 43);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(193, 26);
            cmbGender.TabIndex = 4;
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
            tableLayoutPanel1.Controls.Add(cmbCode, 1, 0);
            tableLayoutPanel1.Controls.Add(label8, 2, 3);
            tableLayoutPanel1.Controls.Add(tbUsername, 1, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 3);
            tableLayoutPanel1.Controls.Add(lbCode, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbPosition, 5, 1);
            tableLayoutPanel1.Controls.Add(cmbDepartment, 5, 0);
            tableLayoutPanel1.Controls.Add(lbName, 0, 1);
            tableLayoutPanel1.Controls.Add(label9, 4, 0);
            tableLayoutPanel1.Controls.Add(label7, 4, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(tbLastName, 1, 2);
            tableLayoutPanel1.Controls.Add(tbFirstName, 1, 1);
            tableLayoutPanel1.Controls.Add(label6, 2, 2);
            tableLayoutPanel1.Controls.Add(label4, 2, 0);
            tableLayoutPanel1.Controls.Add(tbPhoneNumber, 3, 0);
            tableLayoutPanel1.Controls.Add(tbEmail, 3, 2);
            tableLayoutPanel1.Controls.Add(label3, 4, 2);
            tableLayoutPanel1.Controls.Add(dtpDob, 5, 2);
            tableLayoutPanel1.Controls.Add(label2, 2, 1);
            tableLayoutPanel1.Controls.Add(cmbGender, 3, 1);
            tableLayoutPanel1.Controls.Add(tbPassword, 3, 3);
            tableLayoutPanel1.Location = new Point(25, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(1250, 163);
            tableLayoutPanel1.TabIndex = 56;
            // 
            // cmbCode
            // 
            cmbCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCode.FormattingEnabled = true;
            cmbCode.Location = new Point(123, 3);
            cmbCode.Name = "cmbCode";
            cmbCode.Size = new Size(193, 26);
            cmbCode.TabIndex = 51;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(419, 127);
            label8.Margin = new Padding(3, 7, 3, 0);
            label8.Name = "label8";
            label8.Size = new Size(78, 18);
            label8.TabIndex = 50;
            label8.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(123, 123);
            tbUsername.Multiline = true;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(247, 26);
            tbUsername.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 127);
            label5.Margin = new Padding(3, 7, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(80, 18);
            label5.TabIndex = 47;
            label5.Text = "Username";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(123, 43);
            tbFirstName.Multiline = true;
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(247, 26);
            tbFirstName.TabIndex = 2;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(835, 87);
            label3.Margin = new Padding(3, 7, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(93, 18);
            label3.TabIndex = 34;
            label3.Text = "Date of birth";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(539, 123);
            tbPassword.Multiline = true;
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(247, 26);
            tbPassword.TabIndex = 49;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(538, 204);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.TabIndex = 54;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(748, 204);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.TabIndex = 52;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(1139, 204);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(99, 38);
            btnSubmit.TabIndex = 49;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1034, 204);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.TabIndex = 48;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvUser
            // 
            dgvUser.AllowUserToAddRows = false;
            dgvUser.AllowUserToDeleteRows = false;
            dgvUser.AllowUserToResizeColumns = false;
            dgvUser.AllowUserToResizeRows = false;
            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUser.BackgroundColor = Color.LightGray;
            dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUser.Location = new Point(25, 261);
            dgvUser.MultiSelect = false;
            dgvUser.Name = "dgvUser";
            dgvUser.ReadOnly = true;
            dgvUser.RowHeadersVisible = false;
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUser.Size = new Size(1250, 414);
            dgvUser.TabIndex = 51;
            // 
            // colCode
            // 
            colCode.HeaderText = "Code";
            colCode.Name = "colCode";
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.Name = "colName";
            // 
            // colDescription
            // 
            colDescription.HeaderText = "Description";
            colDescription.Name = "colDescription";
            // 
            // colCreatedAt
            // 
            colCreatedAt.HeaderText = "Created At";
            colCreatedAt.Name = "colCreatedAt";
            // 
            // colUpdatedAt
            // 
            colUpdatedAt.HeaderText = "Updated At";
            colUpdatedAt.Name = "colUpdatedAt";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(643, 204);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.TabIndex = 55;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(25, 204);
            tbSearch.Multiline = true;
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(402, 38);
            tbSearch.TabIndex = 53;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(433, 204);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.TabIndex = 50;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // UsersControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnDelete);
            Controls.Add(btnNew);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            Controls.Add(dgvUser);
            Controls.Add(btnUpdate);
            Controls.Add(tbSearch);
            Controls.Add(btnRefresh);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "UsersControl";
            Size = new Size(1300, 700);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbFirstName;
        private Label label4;
        private Label label3;
        private Button btnDelete;
        private Button btnNew;
        private Button btnSubmit;
        private Button btnCancel;
        private DataGridView dgvUser;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colUpdatedAt;
        private Button btnUpdate;
        private TextBox tbSearch;
        private Button btnRefresh;
        private TextBox tbUsername;
        private Label label5;
        private Label label8;
        private TextBox tbPassword;
        private ComboBox cmbCode;
    }
}
