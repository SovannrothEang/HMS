namespace Hospital_management_system.Presentation.UserControls
{
    partial class DepartmentControl
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
            btnDelete = new Button();
            textBox1 = new TextBox();
            colUpdatedAt = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colCode = new DataGridViewTextBoxColumn();
            btnNew = new Button();
            btnSubmit = new Button();
            btnCancel = new Button();
            tbDescription = new TextBox();
            lbDescription = new Label();
            tbName = new TextBox();
            lbName = new Label();
            lbCode = new Label();
            tbCode = new TextBox();
            dgvDept = new DataGridView();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDept).BeginInit();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(777, 180);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(544, 180);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 180);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(402, 36);
            textBox1.TabIndex = 12;
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
            // btnNew
            // 
            btnNew.Location = new Point(661, 180);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.TabIndex = 11;
            btnNew.Text = "Add New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(199, 117);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(99, 38);
            btnSubmit.TabIndex = 10;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(17, 117);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(429, 12);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(414, 84);
            tbDescription.TabIndex = 6;
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = true;
            lbDescription.Location = new Point(335, 15);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(88, 18);
            lbDescription.TabIndex = 7;
            lbDescription.Text = "Description";
            // 
            // tbName
            // 
            tbName.Location = new Point(70, 67);
            tbName.Multiline = true;
            tbName.Name = "tbName";
            tbName.Size = new Size(228, 29);
            tbName.TabIndex = 4;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(14, 70);
            lbName.Name = "lbName";
            lbName.Size = new Size(50, 18);
            lbName.TabIndex = 5;
            lbName.Text = "Name";
            // 
            // lbCode
            // 
            lbCode.AutoSize = true;
            lbCode.Location = new Point(14, 15);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(47, 18);
            lbCode.TabIndex = 3;
            lbCode.Text = "Code";
            // 
            // tbCode
            // 
            tbCode.Location = new Point(70, 12);
            tbCode.Multiline = true;
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(228, 29);
            tbCode.TabIndex = 2;
            // 
            // dgvDept
            // 
            dgvDept.AllowUserToAddRows = false;
            dgvDept.AllowUserToDeleteRows = false;
            dgvDept.AllowUserToResizeColumns = false;
            dgvDept.AllowUserToResizeRows = false;
            dgvDept.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDept.Location = new Point(17, 238);
            dgvDept.MultiSelect = false;
            dgvDept.Name = "dgvDept";
            dgvDept.ReadOnly = true;
            dgvDept.RowHeadersVisible = false;
            dgvDept.Size = new Size(1164, 431);
            dgvDept.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(429, 180);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // DepartmentControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(textBox1);
            Controls.Add(btnNew);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            Controls.Add(lbDescription);
            Controls.Add(tbDescription);
            Controls.Add(lbName);
            Controls.Add(tbName);
            Controls.Add(lbCode);
            Controls.Add(tbCode);
            Controls.Add(dgvDept);
            Controls.Add(btnRefresh);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1200, 700);
            MinimumSize = new Size(1200, 700);
            Name = "DepartmentControl";
            Size = new Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)dgvDept).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private Button btnDelete;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn colUpdatedAt;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCode;
        private Button btnNew;
        private Button btnSubmit;
        private Button btnCancel;
        private TextBox tbDescription;
        private Label lbDescription;
        private TextBox tbName;
        private Label lbName;
        private Label lbCode;
        private TextBox tbCode;
        private DataGridView dgvDept;
        private Button btnRefresh;
    }
}
