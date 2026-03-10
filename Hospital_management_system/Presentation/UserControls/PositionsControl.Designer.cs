using System.Drawing;
using System.Windows.Forms;

namespace Hospital_management_system.Presentation.UserControls
{
    partial class PositionsControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                if (_searchTimer != null)
                {
                    _searchTimer.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvPosition = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this.lbCode = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tlpActions = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeftActions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCenterActions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRightActions = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(1250, 110);
            this.pnlHeader.TabIndex = 16;

            // tlpInput
            this.tlpInput.ColumnCount = 6;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpInput.Controls.Add(this.lbCode, 0, 0);
            this.tlpInput.Controls.Add(this.tbCode, 1, 0);
            this.tlpInput.Controls.Add(this.lbName, 2, 0);
            this.tlpInput.Controls.Add(this.tbName, 3, 0);
            this.tlpInput.Controls.Add(this.lbDepartment, 4, 0);
            this.tlpInput.Controls.Add(this.cmbDepartment, 5, 0);
            this.tlpInput.Controls.Add(this.lbDescription, 0, 1);
            this.tlpInput.Controls.Add(this.tbDescription, 1, 1);
            this.tlpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInput.Location = new System.Drawing.Point(0, 0);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.Padding = new System.Windows.Forms.Padding(10);
            this.tlpInput.RowCount = 2;
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInput.Size = new System.Drawing.Size(1250, 110);
            
            this.tlpInput.SetColumnSpan(this.tbDescription, 5);

            this.lbCode.Text = "Code";
            this.lbCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCode.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tbCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCode.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.tbCode.TabIndex = 1;

            this.lbName.Text = "Name";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.tbName.TabIndex = 2;

            this.lbDepartment.Text = "Department";
            this.lbDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDepartment.Dock = System.Windows.Forms.DockStyle.Fill;

            this.cmbDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cmbDepartment.TabIndex = 3;

            this.lbDescription.Text = "Description";
            this.lbDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDescription.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(1104, 38);
            this.tbDescription.TabIndex = 4;

            // tlpActions
            this.tlpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpActions.ColumnCount = 3;
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpActions.Controls.Add(this.pnlLeftActions, 0, 0);
            this.tlpActions.Controls.Add(this.pnlCenterActions, 1, 0);
            this.tlpActions.Controls.Add(this.pnlRightActions, 2, 0);
            this.tlpActions.Location = new System.Drawing.Point(25, 150);
            this.tlpActions.Name = "tlpActions";
            this.tlpActions.RowCount = 1;
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.Size = new System.Drawing.Size(1250, 50);
            this.tlpActions.TabIndex = 5;

            // pnlLeftActions
            this.pnlLeftActions.Controls.Add(this.tbSearch);
            this.pnlLeftActions.Controls.Add(this.btnRefresh);
            this.pnlLeftActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftActions.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftActions.Name = "pnlLeftActions";

            this.tbSearch.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(402, 38);
            this.tbSearch.PlaceholderText = "Search positions...";
            this.tbSearch.TabIndex = 6;

            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5, 3, 5, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(99, 38);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TabIndex = 7;

            // pnlCenterActions
            this.pnlCenterActions.Controls.Add(this.btnDelete);
            this.pnlCenterActions.Controls.Add(this.btnUpdate);
            this.pnlCenterActions.Controls.Add(this.btnNew);
            this.pnlCenterActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenterActions.Location = new System.Drawing.Point(500, 0);
            this.pnlCenterActions.Name = "pnlCenterActions";
            this.pnlCenterActions.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;

            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 3, 5, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 38);
            this.btnDelete.Text = "Delete";
            this.btnDelete.TabIndex = 8;

            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5, 3, 5, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 38);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TabIndex = 9;

            this.btnNew.Margin = new System.Windows.Forms.Padding(5, 3, 5, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(99, 38);
            this.btnNew.Text = "New";
            this.btnNew.TabIndex = 10;

            // pnlRightActions
            this.pnlRightActions.Controls.Add(this.btnSubmit);
            this.pnlRightActions.Controls.Add(this.btnCancel);
            this.pnlRightActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlRightActions.Location = new System.Drawing.Point(812, 0);
            this.pnlRightActions.Name = "pnlRightActions";

            this.btnSubmit.Margin = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 38);
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.TabIndex = 11;

            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 38);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TabIndex = 12;

            // dgvPosition
            this.dgvPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPosition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPosition.BackgroundColor = System.Drawing.Color.White;
            this.dgvPosition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosition.Location = new System.Drawing.Point(25, 215);
            this.dgvPosition.MultiSelect = false;
            this.dgvPosition.Name = "dgvPosition";
            this.dgvPosition.ReadOnly = true;
            this.dgvPosition.RowHeadersVisible = false;
            this.dgvPosition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPosition.Size = new System.Drawing.Size(1250, 460);
            this.dgvPosition.TabIndex = 0;

            // PositionsControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.dgvPosition);
            this.Controls.Add(this.tlpActions);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.Margin = new Padding(4);
            this.Name = "PositionsControl";
            this.Size = new Size(1300, 700);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).EndInit();
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

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvPosition;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TableLayoutPanel tlpActions;
        private System.Windows.Forms.FlowLayoutPanel pnlLeftActions;
        private System.Windows.Forms.FlowLayoutPanel pnlCenterActions;
        private System.Windows.Forms.FlowLayoutPanel pnlRightActions;
    }
}
