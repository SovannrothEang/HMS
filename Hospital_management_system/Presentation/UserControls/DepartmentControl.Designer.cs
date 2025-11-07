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
            btnRefresh = new Button();
            deprtDgv = new DataGridView();
            tbCode = new TextBox();
            lbCode = new Label();
            lbName = new Label();
            tbName = new TextBox();
            lbDescription = new Label();
            tbDescription = new TextBox();
            btnCancel = new Button();
            btnSubmit = new Button();
            btnNew = new Button();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colUpdatedAt = new DataGridViewTextBoxColumn();
            textBox1 = new TextBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)deprtDgv).BeginInit();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(544, 190);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // deprtDgv
            // 
            deprtDgv.AllowUserToAddRows = false;
            deprtDgv.AllowUserToDeleteRows = false;
            deprtDgv.AllowUserToResizeColumns = false;
            deprtDgv.AllowUserToResizeRows = false;
            deprtDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            deprtDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            deprtDgv.Location = new Point(132, 248);
            deprtDgv.MultiSelect = false;
            deprtDgv.Name = "deprtDgv";
            deprtDgv.ReadOnly = true;
            deprtDgv.RowHeadersVisible = false;
            deprtDgv.Size = new Size(921, 431);
            deprtDgv.TabIndex = 1;
            // 
            // tbCode
            // 
            tbCode.Location = new Point(185, 22);
            tbCode.Multiline = true;
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(228, 29);
            tbCode.TabIndex = 2;
            // 
            // lbCode
            // 
            lbCode.AutoSize = true;
            lbCode.Location = new Point(132, 25);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(47, 18);
            lbCode.TabIndex = 3;
            lbCode.Text = "Code";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(129, 80);
            lbName.Name = "lbName";
            lbName.Size = new Size(50, 18);
            lbName.TabIndex = 5;
            lbName.Text = "Name";
            // 
            // tbName
            // 
            tbName.Location = new Point(185, 77);
            tbName.Multiline = true;
            tbName.Name = "tbName";
            tbName.Size = new Size(228, 29);
            tbName.TabIndex = 4;
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = true;
            lbDescription.Location = new Point(545, 25);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(88, 18);
            lbDescription.TabIndex = 7;
            lbDescription.Text = "Description";
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(639, 22);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(414, 84);
            tbDescription.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(409, 127);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(544, 127);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(99, 38);
            btnSubmit.TabIndex = 10;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(776, 190);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.TabIndex = 11;
            btnNew.Text = "Add New";
            btnNew.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            textBox1.Location = new Point(132, 190);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(402, 36);
            textBox1.TabIndex = 12;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(659, 190);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(892, 190);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // DepartmentControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Controls.Add(deprtDgv);
            Controls.Add(btnRefresh);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1200, 700);
            MinimumSize = new Size(1200, 700);
            Name = "DepartmentControl";
            Size = new Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)deprtDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRefresh;
        private DataGridView deprtDgv;
        private TextBox tbCode;
        private Label lbCode;
        private Label lbName;
        private TextBox tbName;
        private Label lbDescription;
        private TextBox tbDescription;
        private Button btnCancel;
        private Button btnSubmit;
        private Button btnNew;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colUpdatedAt;
        private TextBox textBox1;
        private Button btnDelete;
        private Button btnUpdate;
    }
}
