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
                if (_searchTimer != null) _searchTimer.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lbCode = new System.Windows.Forms.Label();
            this.cmbCode = new System.Windows.Forms.ComboBox();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.lbLastName = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.lbGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbPosition = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lbDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lbDob = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.lbUsername = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tlpActions = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeftActions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCenterActions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRightActions = new System.Windows.Forms.FlowLayoutPanel();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.tlpInput.SuspendLayout();
            this.tlpActions.SuspendLayout();
            this.pnlLeftActions.SuspendLayout();
            this.pnlCenterActions.SuspendLayout();
            this.pnlRightActions.SuspendLayout();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.tlpInput);
            this.pnlHeader.Location = new System.Drawing.Point(25, 25);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1250, 163);
            this.pnlHeader.TabIndex = 56;

            // tlpInput
            this.tlpInput.ColumnCount = 6;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            
            this.tlpInput.Controls.Add(this.lbCode, 0, 0);
            this.tlpInput.Controls.Add(this.cmbCode, 1, 0);
            this.tlpInput.Controls.Add(this.lbPhone, 2, 0);
            this.tlpInput.Controls.Add(this.tbPhoneNumber, 3, 0);
            this.tlpInput.Controls.Add(this.lbDepartment, 4, 0);
            this.tlpInput.Controls.Add(this.cmbDepartment, 5, 0);
            
            this.tlpInput.Controls.Add(this.lbFirstName, 0, 1);
            this.tlpInput.Controls.Add(this.tbFirstName, 1, 1);
            this.tlpInput.Controls.Add(this.lbGender, 2, 1);
            this.tlpInput.Controls.Add(this.cmbGender, 3, 1);
            this.tlpInput.Controls.Add(this.lbPosition, 4, 1);
            this.tlpInput.Controls.Add(this.cmbPosition, 5, 1);
            
            this.tlpInput.Controls.Add(this.lbLastName, 0, 2);
            this.tlpInput.Controls.Add(this.tbLastName, 1, 2);
            this.tlpInput.Controls.Add(this.lbEmail, 2, 2);
            this.tlpInput.Controls.Add(this.tbEmail, 3, 2);
            this.tlpInput.Controls.Add(this.lbDob, 4, 2);
            this.tlpInput.Controls.Add(this.dtpDob, 5, 2);
            
            this.tlpInput.Controls.Add(this.lbUsername, 0, 3);
            this.tlpInput.Controls.Add(this.tbUsername, 1, 3);
            this.tlpInput.Controls.Add(this.lbPassword, 2, 3);
            this.tlpInput.Controls.Add(this.tbPassword, 3, 3);
            
            this.tlpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInput.Location = new System.Drawing.Point(0, 0);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.Padding = new System.Windows.Forms.Padding(10);
            this.tlpInput.RowCount = 4;
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInput.Size = new System.Drawing.Size(1250, 163);
            this.tlpInput.TabIndex = 0;

            // Labels sizing and alignment
            foreach (Control c in this.tlpInput.Controls) {
                if (c is Label) {
                    c.Dock = DockStyle.Fill;
                    ((Label)c).TextAlign = ContentAlignment.MiddleLeft;
                } else {
                    c.Dock = DockStyle.Fill;
                    c.Margin = new Padding(3, 8, 3, 3);
                }
            }

            this.lbCode.Text = "Code";
            this.lbFirstName.Text = "First Name";
            this.lbLastName.Text = "Last Name";
            this.lbGender.Text = "Gender";
            this.lbPhone.Text = "Phone";
            this.lbEmail.Text = "Email";
            this.lbPosition.Text = "Position";
            this.lbDepartment.Text = "Department";
            this.lbDob.Text = "DOB";
            this.lbUsername.Text = "Username";
            this.lbPassword.Text = "Password";
            this.tbPassword.PasswordChar = '*';

            // tlpActions
            this.tlpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpActions.ColumnCount = 3;
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpActions.Controls.Add(this.pnlLeftActions, 0, 0);
            this.tlpActions.Controls.Add(this.pnlCenterActions, 1, 0);
            this.tlpActions.Controls.Add(this.pnlRightActions, 2, 0);
            this.tlpActions.Location = new System.Drawing.Point(25, 204);
            this.tlpActions.Name = "tlpActions";
            this.tlpActions.RowCount = 1;
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.Size = new System.Drawing.Size(1250, 50);
            this.tlpActions.TabIndex = 52;

            // Action Buttons Setup
            this.pnlLeftActions.Controls.Add(this.tbSearch);
            this.pnlLeftActions.Controls.Add(this.btnRefresh);
            this.pnlLeftActions.Dock = DockStyle.Fill;
            this.tbSearch.Size = new Size(402, 38);
            this.tbSearch.PlaceholderText = "Search users...";
            this.btnRefresh.Size = new Size(99, 38);
            this.btnRefresh.Text = "Refresh";

            this.pnlCenterActions.Controls.Add(this.btnDelete);
            this.pnlCenterActions.Controls.Add(this.btnUpdate);
            this.pnlCenterActions.Controls.Add(this.btnNew);
            this.pnlCenterActions.Dock = DockStyle.Fill;
            this.btnDelete.Size = new Size(99, 38);
            this.btnDelete.Text = "Delete";
            this.btnUpdate.Size = new Size(99, 38);
            this.btnUpdate.Text = "Update";
            this.btnNew.Size = new Size(99, 38);
            this.btnNew.Text = "New";

            this.pnlRightActions.Controls.Add(this.btnSubmit);
            this.pnlRightActions.Controls.Add(this.btnCancel);
            this.pnlRightActions.Dock = DockStyle.Fill;
            this.pnlRightActions.FlowDirection = FlowDirection.RightToLeft;
            this.btnSubmit.Size = new Size(100, 38);
            this.btnSubmit.Text = "Submit";
            this.btnCancel.Size = new Size(99, 38);
            this.btnCancel.Text = "Cancel";

            // dgvUser
            this.dgvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(25, 260);
            this.dgvUser.MultiSelect = false;
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(1250, 415);
            this.dgvUser.TabIndex = 51;

            // UsersControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.tlpActions);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UsersControl";
            this.Size = new System.Drawing.Size(1300, 700);
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.tlpInput.ResumeLayout(false);
            this.tlpInput.PerformLayout();
            this.tlpActions.ResumeLayout(false);
            this.pnlLeftActions.ResumeLayout(false);
            this.pnlLeftActions.PerformLayout();
            this.pnlCenterActions.ResumeLayout(false);
            this.pnlRightActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.ComboBox cmbCode;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lbDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lbDob;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbPassword;

        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TableLayoutPanel tlpActions;
        private System.Windows.Forms.FlowLayoutPanel pnlLeftActions;
        private System.Windows.Forms.FlowLayoutPanel pnlCenterActions;
        private System.Windows.Forms.FlowLayoutPanel pnlRightActions;
    }
}
