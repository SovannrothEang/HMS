using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls
{
    partial class PatientsControl
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
            dgvPatient = new DataGridView();
            btnRefresh = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label7 = new Label();
            tbSickness = new TextBox();
            cmbDoctor = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPatient).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(546, 3);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(260, 26);
            cmbGender.TabIndex = 50;
            // 
            // dtpDob
            // 
            dtpDob.Location = new Point(546, 56);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(260, 26);
            dtpDob.TabIndex = 51;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(849, 113);
            label6.Margin = new Padding(3, 7, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(55, 18);
            label6.TabIndex = 73;
            label6.Text = "Doctor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(849, 7);
            label5.Margin = new Padding(3, 7, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(67, 18);
            label5.TabIndex = 72;
            label5.Text = "Address";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(949, 3);
            tbAddress.Multiline = true;
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(268, 43);
            tbAddress.TabIndex = 53;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(426, 113);
            label4.Margin = new Padding(3, 7, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(112, 18);
            label4.TabIndex = 71;
            label4.Text = "Phone Number";
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.Location = new Point(546, 109);
            tbPhoneNumber.Multiline = true;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(260, 29);
            tbPhoneNumber.TabIndex = 52;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(426, 60);
            label3.Margin = new Padding(3, 7, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(93, 18);
            label3.TabIndex = 70;
            label3.Text = "Date of birth";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(426, 7);
            label2.Margin = new Padding(3, 7, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 18);
            label2.TabIndex = 69;
            label2.Text = "Gender";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 113);
            label1.Margin = new Padding(3, 7, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 18);
            label1.TabIndex = 68;
            label1.Text = "Last Name";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(123, 109);
            tbLastName.Multiline = true;
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(260, 29);
            tbLastName.TabIndex = 49;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(643, 205);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.TabIndex = 67;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(25, 205);
            tbSearch.Multiline = true;
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(402, 38);
            tbSearch.TabIndex = 65;
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
            btnDelete.Location = new Point(538, 205);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.TabIndex = 66;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(748, 205);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.TabIndex = 64;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(1143, 205);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(99, 38);
            btnSubmit.TabIndex = 59;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1038, 205);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.TabIndex = 58;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(3, 60);
            lbName.Margin = new Padding(3, 7, 3, 0);
            lbName.Name = "lbName";
            lbName.Size = new Size(85, 18);
            lbName.TabIndex = 63;
            lbName.Text = "First Name";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(123, 56);
            tbFirstName.Multiline = true;
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(260, 29);
            tbFirstName.TabIndex = 48;
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
            // tbCode
            // 
            tbCode.Location = new Point(123, 3);
            tbCode.Multiline = true;
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(260, 29);
            tbCode.TabIndex = 47;
            // 
            // dgvPatient
            // 
            dgvPatient.AllowUserToAddRows = false;
            dgvPatient.AllowUserToDeleteRows = false;
            dgvPatient.AllowUserToResizeColumns = false;
            dgvPatient.AllowUserToResizeRows = false;
            dgvPatient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatient.BackgroundColor = Color.LightGray;
            dgvPatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatient.Location = new Point(25, 263);
            dgvPatient.MultiSelect = false;
            dgvPatient.Name = "dgvPatient";
            dgvPatient.ReadOnly = true;
            dgvPatient.RowHeadersVisible = false;
            dgvPatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatient.Size = new Size(1250, 416);
            dgvPatient.TabIndex = 61;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(433, 205);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.TabIndex = 60;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.LightGray;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(label7, 4, 1);
            tableLayoutPanel1.Controls.Add(lbCode, 0, 0);
            tableLayoutPanel1.Controls.Add(tbCode, 1, 0);
            tableLayoutPanel1.Controls.Add(dtpDob, 3, 1);
            tableLayoutPanel1.Controls.Add(cmbGender, 3, 0);
            tableLayoutPanel1.Controls.Add(lbName, 0, 1);
            tableLayoutPanel1.Controls.Add(tbFirstName, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(tbAddress, 5, 0);
            tableLayoutPanel1.Controls.Add(label5, 4, 0);
            tableLayoutPanel1.Controls.Add(tbLastName, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 2, 0);
            tableLayoutPanel1.Controls.Add(tbPhoneNumber, 3, 2);
            tableLayoutPanel1.Controls.Add(label4, 2, 2);
            tableLayoutPanel1.Controls.Add(label3, 2, 1);
            tableLayoutPanel1.Controls.Add(label6, 4, 2);
            tableLayoutPanel1.Controls.Add(tbSickness, 5, 1);
            tableLayoutPanel1.Controls.Add(cmbDoctor, 5, 2);
            tableLayoutPanel1.Location = new Point(25, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(1250, 159);
            tableLayoutPanel1.TabIndex = 76;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(849, 60);
            label7.Margin = new Padding(3, 7, 3, 0);
            label7.Name = "label7";
            label7.Size = new Size(72, 18);
            label7.TabIndex = 75;
            label7.Text = "Sickness";
            // 
            // tbSickness
            // 
            tbSickness.Location = new Point(949, 56);
            tbSickness.Multiline = true;
            tbSickness.Name = "tbSickness";
            tbSickness.Size = new Size(268, 29);
            tbSickness.TabIndex = 74;
            // 
            // cmbDoctor
            // 
            cmbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoctor.FormattingEnabled = true;
            cmbDoctor.Location = new Point(949, 109);
            cmbDoctor.Name = "cmbDoctor";
            cmbDoctor.Size = new Size(268, 26);
            cmbDoctor.TabIndex = 76;
            // 
            // PatientControl
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
            Controls.Add(dgvPatient);
            Controls.Add(btnRefresh);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1300, 700);
            MinimumSize = new Size(1300, 700);
            Name = "PatientControl";
            Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)dgvPatient).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridView dgvPatient;
        private Button btnRefresh;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label7;
        private TextBox tbSickness;
        private ComboBox cmbDoctor;
    }
}
