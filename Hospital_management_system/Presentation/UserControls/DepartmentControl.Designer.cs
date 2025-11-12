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
            tbSearch = new TextBox();
            colUpdatedAt = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colCode = new DataGridViewTextBoxColumn();
            btnNew = new Button();
            btnSubmit = new Button();
            btnCancel = new Button();
            dgvDept = new DataGridView();
            btnRefresh = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tbCode = new TextBox();
            lbCode = new Label();
            lbName = new Label();
            tbName = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tbDescription = new TextBox();
            lbDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDept).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(632, 173);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(527, 173);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(25, 173);
            tbSearch.Multiline = true;
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(391, 38);
            tbSearch.TabIndex = 12;
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
            btnNew.Location = new Point(737, 173);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.TabIndex = 11;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(1143, 173);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(99, 38);
            btnSubmit.TabIndex = 10;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1038, 173);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvDept
            // 
            dgvDept.AllowUserToAddRows = false;
            dgvDept.AllowUserToDeleteRows = false;
            dgvDept.AllowUserToResizeColumns = false;
            dgvDept.AllowUserToResizeRows = false;
            dgvDept.BackgroundColor = Color.LightGray;
            dgvDept.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDept.Location = new Point(25, 229);
            dgvDept.MultiSelect = false;
            dgvDept.Name = "dgvDept";
            dgvDept.ReadOnly = true;
            dgvDept.RowHeadersVisible = false;
            dgvDept.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDept.Size = new Size(1250, 440);
            dgvDept.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(422, 173);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.LightGray;
            flowLayoutPanel1.Controls.Add(tableLayoutPanel1);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel2);
            flowLayoutPanel1.Location = new Point(25, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1250, 133);
            flowLayoutPanel1.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.547945F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.45206F));
            tableLayoutPanel1.Controls.Add(tbCode, 1, 0);
            tableLayoutPanel1.Controls.Add(lbCode, 0, 0);
            tableLayoutPanel1.Controls.Add(lbName, 0, 1);
            tableLayoutPanel1.Controls.Add(tbName, 1, 1);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(493, 105);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tbCode
            // 
            tbCode.Location = new Point(104, 3);
            tbCode.Multiline = true;
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(235, 29);
            tbCode.TabIndex = 6;
            // 
            // lbCode
            // 
            lbCode.AutoSize = true;
            lbCode.Location = new Point(3, 7);
            lbCode.Margin = new Padding(3, 7, 3, 0);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(47, 18);
            lbCode.TabIndex = 7;
            lbCode.Text = "Code";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(3, 59);
            lbName.Margin = new Padding(3, 7, 3, 0);
            lbName.Name = "lbName";
            lbName.Size = new Size(50, 18);
            lbName.TabIndex = 9;
            lbName.Text = "Name";
            // 
            // tbName
            // 
            tbName.Location = new Point(104, 55);
            tbName.Multiline = true;
            tbName.Name = "tbName";
            tbName.Size = new Size(235, 29);
            tbName.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tbDescription, 1, 0);
            tableLayoutPanel2.Controls.Add(lbDescription, 0, 0);
            tableLayoutPanel2.Location = new Point(502, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(575, 105);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(103, 3);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(469, 81);
            tbDescription.TabIndex = 6;
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = true;
            lbDescription.Location = new Point(3, 7);
            lbDescription.Margin = new Padding(3, 7, 3, 0);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(88, 18);
            lbDescription.TabIndex = 7;
            lbDescription.Text = "Description";
            // 
            // DepartmentControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(tbSearch);
            Controls.Add(btnNew);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            Controls.Add(dgvDept);
            Controls.Add(btnRefresh);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximumSize = new Size(1300, 700);
            MinimumSize = new Size(1300, 700);
            Name = "DepartmentControl";
            Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)dgvDept).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private Button btnDelete;
        private TextBox tbSearch;
        private DataGridViewTextBoxColumn colUpdatedAt;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCode;
        private Button btnNew;
        private Button btnSubmit;
        private Button btnCancel;
        private DataGridView dgvDept;
        private Button btnRefresh;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbCode;
        private Label lbCode;
        private Label lbName;
        private TextBox tbName;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox tbDescription;
        private Label lbDescription;
    }
}
