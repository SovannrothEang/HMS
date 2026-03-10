namespace Hospital_management_system.Presentation.UserControls
{
    partial class DepartmentsControl
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
            pnlHeader = new Panel();
            tlpInput = new TableLayoutPanel();
            pnlLeftInput = new Panel();
            lbCode = new Label();
            tbCode = new TextBox();
            lbName = new Label();
            tbName = new TextBox();
            pnlRightInput = new Panel();
            lbDescription = new Label();
            tbDescription = new TextBox();
            tlpActions = new TableLayoutPanel();
            pnlLeftActions = new FlowLayoutPanel();
            pnlCenterActions = new FlowLayoutPanel();
            pnlRightActions = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvDept).BeginInit();
            pnlHeader.SuspendLayout();
            tlpInput.SuspendLayout();
            pnlLeftInput.SuspendLayout();
            pnlRightInput.SuspendLayout();
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
            pnlHeader.Size = new Size(1250, 133);
            pnlHeader.TabIndex = 16;

            // tlpInput
            tlpInput.ColumnCount = 2;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpInput.Controls.Add(pnlLeftInput, 0, 0);
            tlpInput.Controls.Add(pnlRightInput, 1, 0);
            tlpInput.Dock = DockStyle.Fill;
            tlpInput.Location = new Point(0, 0);
            tlpInput.Name = "tlpInput";
            tlpInput.RowCount = 1;
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInput.Size = new Size(1250, 133);

            // pnlLeftInput
            pnlLeftInput.Controls.Add(lbCode);
            pnlLeftInput.Controls.Add(tbCode);
            pnlLeftInput.Controls.Add(lbName);
            pnlLeftInput.Controls.Add(tbName);
            pnlLeftInput.Dock = DockStyle.Fill;
            pnlLeftInput.Location = new Point(3, 3);
            pnlLeftInput.Name = "pnlLeftInput";
            pnlLeftInput.Size = new Size(494, 127);

            lbCode.AutoSize = true;
            lbCode.Location = new Point(20, 20);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(47, 18);
            lbCode.Text = "Code";

            tbCode.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            tbCode.Location = new Point(100, 17);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(370, 26);

            lbName.AutoSize = true;
            lbName.Location = new Point(20, 70);
            lbName.Name = "lbName";
            lbName.Size = new Size(50, 18);
            lbName.Text = "Name";

            tbName.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            tbName.Location = new Point(100, 67);
            tbName.Name = "tbName";
            tbName.Size = new Size(370, 26);

            // pnlRightInput
            pnlRightInput.Controls.Add(lbDescription);
            pnlRightInput.Controls.Add(tbDescription);
            pnlRightInput.Dock = DockStyle.Fill;
            pnlRightInput.Location = new Point(503, 3);
            pnlRightInput.Name = "pnlRightInput";
            pnlRightInput.Size = new Size(744, 127);

            lbDescription.AutoSize = true;
            lbDescription.Location = new Point(20, 20);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(88, 18);
            lbDescription.Text = "Description";

            tbDescription.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            tbDescription.Location = new Point(120, 17);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(600, 90);

            // tlpActions
            tlpActions.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            tlpActions.ColumnCount = 3;
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpActions.Controls.Add(pnlLeftActions, 0, 0);
            tlpActions.Controls.Add(pnlCenterActions, 1, 0);
            tlpActions.Controls.Add(pnlRightActions, 2, 0);
            tlpActions.Location = new Point(25, 170);
            tlpActions.Name = "tlpActions";
            tlpActions.RowCount = 1;
            tlpActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpActions.Size = new Size(1250, 50);

            // pnlLeftActions
            pnlLeftActions.Controls.Add(tbSearch);
            pnlLeftActions.Controls.Add(btnRefresh);
            pnlLeftActions.Dock = DockStyle.Fill;
            pnlLeftActions.Location = new Point(0, 0);
            pnlLeftActions.Name = "pnlLeftActions";

            tbSearch.Margin = new Padding(0, 5, 5, 0);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(402, 38);
            tbSearch.PlaceholderText = "Search departments...";

            btnRefresh.Margin = new Padding(5, 3, 5, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(99, 38);
            btnRefresh.Text = "Refresh";

            // pnlCenterActions
            pnlCenterActions.Controls.Add(btnDelete);
            pnlCenterActions.Controls.Add(btnUpdate);
            pnlCenterActions.Controls.Add(btnNew);
            pnlCenterActions.Dock = DockStyle.Fill;
            pnlCenterActions.Location = new Point(500, 0);
            pnlCenterActions.Name = "pnlCenterActions";
            pnlCenterActions.FlowDirection = FlowDirection.LeftToRight;

            btnDelete.Margin = new Padding(5, 3, 5, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 38);
            btnDelete.Text = "Delete";

            btnUpdate.Margin = new Padding(5, 3, 5, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 38);
            btnUpdate.Text = "Update";

            btnNew.Margin = new Padding(5, 3, 5, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(99, 38);
            btnNew.Text = "New";

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

            btnCancel.Margin = new Padding(5, 3, 5, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 38);
            btnCancel.Text = "Cancel";

            // dgvDept
            dgvDept.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            dgvDept.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDept.BackgroundColor = Color.White;
            dgvDept.BorderStyle = BorderStyle.None;
            dgvDept.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDept.Location = new Point(25, 230);
            dgvDept.MultiSelect = false;
            dgvDept.Name = "dgvDept";
            dgvDept.ReadOnly = true;
            dgvDept.RowHeadersVisible = false;
            dgvDept.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDept.Size = new Size(1250, 445);
            dgvDept.TabIndex = 1;

            // DepartmentsControl
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(dgvDept);
            Controls.Add(tlpActions);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "DepartmentsControl";
            Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)dgvDept).EndInit();
            pnlHeader.ResumeLayout(false);
            tlpInput.ResumeLayout(false);
            pnlLeftInput.ResumeLayout(false);
            pnlLeftInput.PerformLayout();
            pnlRightInput.ResumeLayout(false);
            pnlRightInput.PerformLayout();
            tlpActions.ResumeLayout(false);
            pnlLeftActions.ResumeLayout(false);
            pnlLeftActions.PerformLayout();
            pnlCenterActions.ResumeLayout(false);
            pnlRightActions.ResumeLayout(false);
            ResumeLayout(false);
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
        private Panel pnlHeader;
        private TableLayoutPanel tlpInput;
        private Panel pnlLeftInput;
        private TextBox tbCode;
        private Label lbCode;
        private Label lbName;
        private TextBox tbName;
        private Panel pnlRightInput;
        private TextBox tbDescription;
        private Label lbDescription;
        private TableLayoutPanel tlpActions;
        private FlowLayoutPanel pnlLeftActions;
        private FlowLayoutPanel pnlCenterActions;
        private FlowLayoutPanel pnlRightActions;
    }
}
