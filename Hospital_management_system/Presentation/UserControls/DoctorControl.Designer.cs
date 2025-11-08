namespace Hospital_management_system.Presentation.UserControls
{
    partial class DoctorControl
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
            TableLayoutPanel controlPanel;
            cmbCode = new ComboBox();
            lbCode = new Label();
            lbName = new Label();
            cmbSpecialization = new ComboBox();
            label1 = new Label();
            tbLicenseNumber = new TextBox();
            label2 = new Label();
            tbExperinse = new TextBox();
            label3 = new Label();
            dtpHiredDate = new DateTimePicker();
            label9 = new Label();
            cmbDepartment = new ComboBox();
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
            dgvDoctor = new DataGridView();
            btnRefresh = new Button();
            controlPanel = new TableLayoutPanel();
            controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoctor).BeginInit();
            SuspendLayout();
            // 
            // controlPanel
            // 
            controlPanel.ColumnCount = 6;
            controlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            controlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            controlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            controlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            controlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            controlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            controlPanel.Controls.Add(cmbCode, 1, 0);
            controlPanel.Controls.Add(lbCode, 0, 0);
            controlPanel.Controls.Add(lbName, 0, 1);
            controlPanel.Controls.Add(cmbSpecialization, 1, 1);
            controlPanel.Controls.Add(label1, 2, 0);
            controlPanel.Controls.Add(tbLicenseNumber, 3, 0);
            controlPanel.Controls.Add(label2, 2, 1);
            controlPanel.Controls.Add(tbExperinse, 3, 1);
            controlPanel.Controls.Add(label3, 4, 0);
            controlPanel.Controls.Add(dtpHiredDate, 5, 0);
            controlPanel.Controls.Add(label9, 4, 1);
            controlPanel.Controls.Add(cmbDepartment, 5, 1);
            controlPanel.Location = new Point(20, 25);
            controlPanel.Name = "controlPanel";
            controlPanel.RowCount = 2;
            controlPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            controlPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            controlPanel.Size = new Size(1158, 94);
            controlPanel.TabIndex = 77;
            // 
            // cmbCode
            // 
            cmbCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCode.FormattingEnabled = true;
            cmbCode.Location = new Point(133, 3);
            cmbCode.Name = "cmbCode";
            cmbCode.Size = new Size(259, 26);
            cmbCode.TabIndex = 78;
            // 
            // lbCode
            // 
            lbCode.AutoSize = true;
            lbCode.Location = new Point(3, 7);
            lbCode.Margin = new Padding(3, 7, 3, 0);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(47, 18);
            lbCode.TabIndex = 62;
            lbCode.Text = "Code";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(3, 54);
            lbName.Margin = new Padding(3, 7, 3, 0);
            lbName.Name = "lbName";
            lbName.Size = new Size(106, 18);
            lbName.TabIndex = 63;
            lbName.Text = "Specialization";
            // 
            // cmbSpecialization
            // 
            cmbSpecialization.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpecialization.FormattingEnabled = true;
            cmbSpecialization.Location = new Point(133, 50);
            cmbSpecialization.Name = "cmbSpecialization";
            cmbSpecialization.Size = new Size(259, 26);
            cmbSpecialization.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(398, 7);
            label1.Margin = new Padding(3, 7, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(122, 18);
            label1.TabIndex = 68;
            label1.Text = "License Number";
            // 
            // tbLicenseNumber
            // 
            tbLicenseNumber.Location = new Point(528, 3);
            tbLicenseNumber.Multiline = true;
            tbLicenseNumber.Name = "tbLicenseNumber";
            tbLicenseNumber.Size = new Size(259, 29);
            tbLicenseNumber.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(398, 54);
            label2.Margin = new Padding(3, 7, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 18);
            label2.TabIndex = 69;
            label2.Text = "Experiense";
            // 
            // tbExperinse
            // 
            tbExperinse.Location = new Point(528, 50);
            tbExperinse.Multiline = true;
            tbExperinse.Name = "tbExperinse";
            tbExperinse.Size = new Size(259, 29);
            tbExperinse.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(793, 7);
            label3.Margin = new Padding(3, 7, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(84, 18);
            label3.TabIndex = 70;
            label3.Text = "Hired Date";
            // 
            // dtpHiredDate
            // 
            dtpHiredDate.Location = new Point(893, 3);
            dtpHiredDate.Name = "dtpHiredDate";
            dtpHiredDate.Size = new Size(262, 26);
            dtpHiredDate.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(793, 54);
            label9.Margin = new Padding(3, 7, 3, 0);
            label9.Name = "label9";
            label9.Size = new Size(90, 18);
            label9.TabIndex = 76;
            label9.Text = "Department";
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(893, 50);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(262, 26);
            cmbDepartment.TabIndex = 6;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(773, 125);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.TabIndex = 67;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 125);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(402, 38);
            textBox1.TabIndex = 65;
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
            btnDelete.Location = new Point(563, 125);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.TabIndex = 66;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(668, 125);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.TabIndex = 64;
            btnNew.Text = "Add New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(1079, 125);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(99, 38);
            btnSubmit.TabIndex = 59;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(974, 125);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.TabIndex = 58;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvDoctor
            // 
            dgvDoctor.AllowUserToAddRows = false;
            dgvDoctor.AllowUserToDeleteRows = false;
            dgvDoctor.AllowUserToResizeColumns = false;
            dgvDoctor.AllowUserToResizeRows = false;
            dgvDoctor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoctor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoctor.Location = new Point(20, 169);
            dgvDoctor.MultiSelect = false;
            dgvDoctor.Name = "dgvDoctor";
            dgvDoctor.ReadOnly = true;
            dgvDoctor.RowHeadersVisible = false;
            dgvDoctor.Size = new Size(1158, 510);
            dgvDoctor.TabIndex = 61;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(428, 125);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.TabIndex = 60;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // DoctorControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(controlPanel);
            Controls.Add(btnUpdate);
            Controls.Add(textBox1);
            Controls.Add(btnDelete);
            Controls.Add(btnNew);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            Controls.Add(dgvDoctor);
            Controls.Add(btnRefresh);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "DoctorControl";
            Size = new Size(1200, 700);
            controlPanel.ResumeLayout(false);
            controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoctor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDepartment;
        private ComboBox cmbSpecialization;
        private DateTimePicker dtpHiredDate;
        private Label label9;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbLicenseNumber;
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
        private TextBox tbExperinse;
        private Label lbCode;
        private DataGridView dgvDoctor;
        private Button btnRefresh;
        private TableLayoutPanel controlPanel;
        private ComboBox cmbCode;
    }
}
