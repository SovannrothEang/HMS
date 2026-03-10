using System.Drawing;
using System.Windows.Forms;
using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                GlobalState.DataUpdated -= OnDataUpdated;
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.pnlDoctors = new Panel();
            this.lblTotalDoctors = new Label();
            this.lblDoctorsText = new Label();
            this.pnlDoctorsColor = new Panel();
            this.pnlStaffs = new Panel();
            this.lblTotalStaffs = new Label();
            this.lblStaffsText = new Label();
            this.pnlStaffsColor = new Panel();
            this.pnlPatients = new Panel();
            this.lblTotalPatients = new Label();
            this.lblPatientsText = new Label();
            this.pnlPatientsColor = new Panel();
            this.pnlDepartments = new Panel();
            this.lblTotalDepartments = new Label();
            this.lblDepartmentsText = new Label();
            this.pnlDepartmentsColor = new Panel();
            this.lblRecentPatients = new Label();
            this.dgvRecentPatients = new DataGridView();
            this.lblDepartments = new Label();
            this.dgvDepartments = new DataGridView();
            
            this.pnlDoctors.SuspendLayout();
            this.pnlStaffs.SuspendLayout();
            this.pnlPatients.SuspendLayout();
            this.pnlDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTitle.Location = new Point(45, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(335, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard Overview";
            
            // CreateCards
            SetupCard(this.pnlDoctors, this.pnlDoctorsColor, this.lblTotalDoctors, this.lblDoctorsText, "Doctors", Color.FromArgb(52, 152, 219), 45);
            SetupCard(this.pnlStaffs, this.pnlStaffsColor, this.lblTotalStaffs, this.lblStaffsText, "Staffs", Color.FromArgb(46, 204, 113), 355);
            SetupCard(this.pnlPatients, this.pnlPatientsColor, this.lblTotalPatients, this.lblPatientsText, "Patients", Color.FromArgb(231, 76, 60), 665);
            SetupCard(this.pnlDepartments, this.pnlDepartmentsColor, this.lblTotalDepartments, this.lblDepartmentsText, "Departments", Color.FromArgb(241, 196, 15), 975);
            
            // lblRecentPatients
            this.lblRecentPatients.AutoSize = true;
            this.lblRecentPatients.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblRecentPatients.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblRecentPatients.Location = new Point(45, 230);
            this.lblRecentPatients.Name = "lblRecentPatients";
            this.lblRecentPatients.Size = new Size(183, 30);
            this.lblRecentPatients.TabIndex = 9;
            this.lblRecentPatients.Text = "Recent Patients";
            
            // dgvRecentPatients
            this.dgvRecentPatients.AllowUserToAddRows = false;
            this.dgvRecentPatients.AllowUserToDeleteRows = false;
            this.dgvRecentPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentPatients.BackgroundColor = Color.White;
            this.dgvRecentPatients.BorderStyle = BorderStyle.None;
            this.dgvRecentPatients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentPatients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvRecentPatients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 246, 250);
            this.dgvRecentPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvRecentPatients.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(108, 122, 137);
            this.dgvRecentPatients.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 246, 250);
            this.dgvRecentPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentPatients.ColumnHeadersHeight = 40;
            this.dgvRecentPatients.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            this.dgvRecentPatients.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            this.dgvRecentPatients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(236, 240, 241);
            this.dgvRecentPatients.DefaultCellStyle.SelectionForeColor = Color.FromArgb(44, 62, 80);
            this.dgvRecentPatients.EnableHeadersVisualStyles = false;
            this.dgvRecentPatients.Location = new Point(45, 270);
            this.dgvRecentPatients.Name = "dgvRecentPatients";
            this.dgvRecentPatients.ReadOnly = true;
            this.dgvRecentPatients.RowHeadersVisible = false;
            this.dgvRecentPatients.RowTemplate.Height = 45;
            this.dgvRecentPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentPatients.Size = new Size(780, 380);
            this.dgvRecentPatients.TabIndex = 10;
            
            // lblDepartments
            this.lblDepartments.AutoSize = true;
            this.lblDepartments.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblDepartments.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblDepartments.Location = new Point(875, 230);
            this.lblDepartments.Name = "lblDepartments";
            this.lblDepartments.Size = new Size(150, 30);
            this.lblDepartments.TabIndex = 11;
            this.lblDepartments.Text = "Departments";
            
            // dgvDepartments
            this.dgvDepartments.AllowUserToAddRows = false;
            this.dgvDepartments.AllowUserToDeleteRows = false;
            this.dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartments.BackgroundColor = Color.White;
            this.dgvDepartments.BorderStyle = BorderStyle.None;
            this.dgvDepartments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDepartments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvDepartments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 246, 250);
            this.dgvDepartments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvDepartments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(108, 122, 137);
            this.dgvDepartments.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 246, 250);
            this.dgvDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDepartments.ColumnHeadersHeight = 40;
            this.dgvDepartments.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            this.dgvDepartments.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            this.dgvDepartments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(236, 240, 241);
            this.dgvDepartments.DefaultCellStyle.SelectionForeColor = Color.FromArgb(44, 62, 80);
            this.dgvDepartments.EnableHeadersVisualStyles = false;
            this.dgvDepartments.Location = new Point(875, 270);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.ReadOnly = true;
            this.dgvDepartments.RowHeadersVisible = false;
            this.dgvDepartments.RowTemplate.Height = 45;
            this.dgvDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartments.Size = new Size(380, 380);
            this.dgvDepartments.TabIndex = 12;

            // DashboardControl
            this.AutoScaleDimensions = new SizeF(9F, 18F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.dgvDepartments);
            this.Controls.Add(this.lblDepartments);
            this.Controls.Add(this.dgvRecentPatients);
            this.Controls.Add(this.lblRecentPatients);
            this.Controls.Add(this.pnlDepartments);
            this.Controls.Add(this.pnlPatients);
            this.Controls.Add(this.pnlStaffs);
            this.Controls.Add(this.pnlDoctors);
            this.Controls.Add(this.lblTitle);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Margin = new Padding(4);
            this.Name = "DashboardControl";
            this.Size = new Size(1300, 700);
            
            this.pnlDoctors.ResumeLayout(false);
            this.pnlDoctors.PerformLayout();
            this.pnlStaffs.ResumeLayout(false);
            this.pnlStaffs.PerformLayout();
            this.pnlPatients.ResumeLayout(false);
            this.pnlPatients.PerformLayout();
            this.pnlDepartments.ResumeLayout(false);
            this.pnlDepartments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupCard(Panel card, Panel colorStrip, Label valueLabel, Label titleLabel, string title, Color themeColor, int x)
        {
            card.BackColor = Color.White;
            card.Location = new Point(x, 80);
            card.Name = "pnl" + title;
            card.Size = new Size(280, 120);
            card.TabIndex = 1;

            colorStrip.BackColor = themeColor;
            colorStrip.Dock = DockStyle.Left;
            colorStrip.Location = new Point(0, 0);
            colorStrip.Name = "pnlColor" + title;
            colorStrip.Size = new Size(8, 120);
            colorStrip.TabIndex = 0;

            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(108, 122, 137);
            titleLabel.Location = new Point(25, 20);
            titleLabel.Name = "lbl" + title + "Text";
            titleLabel.Size = new Size(100, 25);
            titleLabel.TabIndex = 1;
            titleLabel.Text = title;

            valueLabel.AutoSize = true;
            valueLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            valueLabel.ForeColor = Color.FromArgb(44, 62, 80);
            valueLabel.Location = new Point(20, 45);
            valueLabel.Name = "lblTotal" + title;
            valueLabel.Size = new Size(50, 59);
            valueLabel.TabIndex = 2;
            valueLabel.Text = "0";

            card.Controls.Add(valueLabel);
            card.Controls.Add(titleLabel);
            card.Controls.Add(colorStrip);
        }

        #endregion

        private Label lblTitle;
        
        private Panel pnlDoctors;
        private Label lblTotalDoctors;
        private Label lblDoctorsText;
        private Panel pnlDoctorsColor;
        
        private Panel pnlStaffs;
        private Label lblTotalStaffs;
        private Label lblStaffsText;
        private Panel pnlStaffsColor;
        
        private Panel pnlPatients;
        private Label lblTotalPatients;
        private Label lblPatientsText;
        private Panel pnlPatientsColor;
        
        private Panel pnlDepartments;
        private Label lblTotalDepartments;
        private Label lblDepartmentsText;
        private Panel pnlDepartmentsColor;
        
        private Label lblRecentPatients;
        private DataGridView dgvRecentPatients;
        private Label lblDepartments;
        private DataGridView dgvDepartments;
    }
}
