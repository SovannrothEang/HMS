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
            lblTitle = new Label();
            tlpCards = new TableLayoutPanel();
            pnlDoctors = new Panel();
            lblTotalDoctors = new Label();
            lblDoctorsText = new Label();
            pnlDoctorsColor = new Panel();
            pnlStaffs = new Panel();
            lblTotalStaffs = new Label();
            lblStaffsText = new Label();
            pnlStaffsColor = new Panel();
            pnlPatients = new Panel();
            lblTotalPatients = new Label();
            lblPatientsText = new Label();
            pnlPatientsColor = new Panel();
            pnlDepartments = new Panel();
            lblTotalDepartments = new Label();
            lblDepartmentsText = new Label();
            pnlDepartmentsColor = new Panel();
            tlpGrids = new TableLayoutPanel();
            pnlRecentPatientsContainer = new Panel();
            lblRecentPatients = new Label();
            dgvRecentPatients = new DataGridView();
            pnlDepartmentsContainer = new Panel();
            lblDepartments = new Label();
            dgvDepartments = new DataGridView();
            tlpCards.SuspendLayout();
            pnlDoctors.SuspendLayout();
            pnlStaffs.SuspendLayout();
            pnlPatients.SuspendLayout();
            pnlDepartments.SuspendLayout();
            tlpGrids.SuspendLayout();
            pnlRecentPatientsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentPatients).BeginInit();
            pnlDepartmentsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(419, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dashboard Overview";
            // 
            // tlpCards
            // 
            tlpCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpCards.ColumnCount = 4;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.Controls.Add(pnlDoctors, 0, 0);
            tlpCards.Controls.Add(pnlStaffs, 1, 0);
            tlpCards.Controls.Add(pnlPatients, 2, 0);
            tlpCards.Controls.Add(pnlDepartments, 3, 0);
            tlpCards.Location = new Point(25, 80);
            tlpCards.Name = "tlpCards";
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            tlpCards.Size = new Size(1250, 130);
            tlpCards.TabIndex = 1;
            // 
            // pnlDoctors
            // 
            pnlDoctors.BackColor = Color.White;
            pnlDoctors.Controls.Add(lblTotalDoctors);
            pnlDoctors.Controls.Add(lblDoctorsText);
            pnlDoctors.Controls.Add(pnlDoctorsColor);
            pnlDoctors.Dock = DockStyle.Fill;
            pnlDoctors.Location = new Point(5, 5);
            pnlDoctors.Margin = new Padding(5);
            pnlDoctors.Name = "pnlDoctors";
            pnlDoctors.Size = new Size(302, 120);
            pnlDoctors.TabIndex = 0;
            // 
            // lblTotalDoctors
            // 
            lblTotalDoctors.AutoSize = true;
            lblTotalDoctors.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTotalDoctors.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalDoctors.Location = new Point(20, 45);
            lblTotalDoctors.Name = "lblTotalDoctors";
            lblTotalDoctors.Size = new Size(61, 72);
            lblTotalDoctors.TabIndex = 0;
            lblTotalDoctors.Text = "0";
            // 
            // lblDoctorsText
            // 
            lblDoctorsText.AutoSize = true;
            lblDoctorsText.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblDoctorsText.ForeColor = Color.FromArgb(108, 122, 137);
            lblDoctorsText.Location = new Point(25, 20);
            lblDoctorsText.Name = "lblDoctorsText";
            lblDoctorsText.Size = new Size(98, 32);
            lblDoctorsText.TabIndex = 1;
            lblDoctorsText.Text = "Doctors";
            // 
            // pnlDoctorsColor
            // 
            pnlDoctorsColor.BackColor = Color.FromArgb(52, 152, 219);
            pnlDoctorsColor.Dock = DockStyle.Left;
            pnlDoctorsColor.Location = new Point(0, 0);
            pnlDoctorsColor.Name = "pnlDoctorsColor";
            pnlDoctorsColor.Size = new Size(8, 120);
            pnlDoctorsColor.TabIndex = 2;
            // 
            // pnlStaffs
            // 
            pnlStaffs.BackColor = Color.White;
            pnlStaffs.Controls.Add(lblTotalStaffs);
            pnlStaffs.Controls.Add(lblStaffsText);
            pnlStaffs.Controls.Add(pnlStaffsColor);
            pnlStaffs.Dock = DockStyle.Fill;
            pnlStaffs.Location = new Point(317, 5);
            pnlStaffs.Margin = new Padding(5);
            pnlStaffs.Name = "pnlStaffs";
            pnlStaffs.Size = new Size(302, 120);
            pnlStaffs.TabIndex = 1;
            // 
            // lblTotalStaffs
            // 
            lblTotalStaffs.AutoSize = true;
            lblTotalStaffs.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTotalStaffs.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalStaffs.Location = new Point(20, 45);
            lblTotalStaffs.Name = "lblTotalStaffs";
            lblTotalStaffs.Size = new Size(61, 72);
            lblTotalStaffs.TabIndex = 0;
            lblTotalStaffs.Text = "0";
            // 
            // lblStaffsText
            // 
            lblStaffsText.AutoSize = true;
            lblStaffsText.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblStaffsText.ForeColor = Color.FromArgb(108, 122, 137);
            lblStaffsText.Location = new Point(25, 20);
            lblStaffsText.Name = "lblStaffsText";
            lblStaffsText.Size = new Size(74, 32);
            lblStaffsText.TabIndex = 1;
            lblStaffsText.Text = "Staffs";
            // 
            // pnlStaffsColor
            // 
            pnlStaffsColor.BackColor = Color.FromArgb(46, 204, 113);
            pnlStaffsColor.Dock = DockStyle.Left;
            pnlStaffsColor.Location = new Point(0, 0);
            pnlStaffsColor.Name = "pnlStaffsColor";
            pnlStaffsColor.Size = new Size(8, 120);
            pnlStaffsColor.TabIndex = 2;
            // 
            // pnlPatients
            // 
            pnlPatients.BackColor = Color.White;
            pnlPatients.Controls.Add(lblTotalPatients);
            pnlPatients.Controls.Add(lblPatientsText);
            pnlPatients.Controls.Add(pnlPatientsColor);
            pnlPatients.Dock = DockStyle.Fill;
            pnlPatients.Location = new Point(629, 5);
            pnlPatients.Margin = new Padding(5);
            pnlPatients.Name = "pnlPatients";
            pnlPatients.Size = new Size(302, 120);
            pnlPatients.TabIndex = 2;
            // 
            // lblTotalPatients
            // 
            lblTotalPatients.AutoSize = true;
            lblTotalPatients.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTotalPatients.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalPatients.Location = new Point(20, 45);
            lblTotalPatients.Name = "lblTotalPatients";
            lblTotalPatients.Size = new Size(61, 72);
            lblTotalPatients.TabIndex = 0;
            lblTotalPatients.Text = "0";
            // 
            // lblPatientsText
            // 
            lblPatientsText.AutoSize = true;
            lblPatientsText.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblPatientsText.ForeColor = Color.FromArgb(108, 122, 137);
            lblPatientsText.Location = new Point(25, 20);
            lblPatientsText.Name = "lblPatientsText";
            lblPatientsText.Size = new Size(101, 32);
            lblPatientsText.TabIndex = 1;
            lblPatientsText.Text = "Patients";
            // 
            // pnlPatientsColor
            // 
            pnlPatientsColor.BackColor = Color.FromArgb(231, 76, 60);
            pnlPatientsColor.Dock = DockStyle.Left;
            pnlPatientsColor.Location = new Point(0, 0);
            pnlPatientsColor.Name = "pnlPatientsColor";
            pnlPatientsColor.Size = new Size(8, 120);
            pnlPatientsColor.TabIndex = 2;
            // 
            // pnlDepartments
            // 
            pnlDepartments.BackColor = Color.White;
            pnlDepartments.Controls.Add(lblTotalDepartments);
            pnlDepartments.Controls.Add(lblDepartmentsText);
            pnlDepartments.Controls.Add(pnlDepartmentsColor);
            pnlDepartments.Dock = DockStyle.Fill;
            pnlDepartments.Location = new Point(941, 5);
            pnlDepartments.Margin = new Padding(5);
            pnlDepartments.Name = "pnlDepartments";
            pnlDepartments.Size = new Size(304, 120);
            pnlDepartments.TabIndex = 3;
            // 
            // lblTotalDepartments
            // 
            lblTotalDepartments.AutoSize = true;
            lblTotalDepartments.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTotalDepartments.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalDepartments.Location = new Point(20, 45);
            lblTotalDepartments.Name = "lblTotalDepartments";
            lblTotalDepartments.Size = new Size(61, 72);
            lblTotalDepartments.TabIndex = 0;
            lblTotalDepartments.Text = "0";
            // 
            // lblDepartmentsText
            // 
            lblDepartmentsText.AutoSize = true;
            lblDepartmentsText.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblDepartmentsText.ForeColor = Color.FromArgb(108, 122, 137);
            lblDepartmentsText.Location = new Point(25, 20);
            lblDepartmentsText.Name = "lblDepartmentsText";
            lblDepartmentsText.Size = new Size(157, 32);
            lblDepartmentsText.TabIndex = 1;
            lblDepartmentsText.Text = "Departments";
            // 
            // pnlDepartmentsColor
            // 
            pnlDepartmentsColor.BackColor = Color.FromArgb(241, 196, 15);
            pnlDepartmentsColor.Dock = DockStyle.Left;
            pnlDepartmentsColor.Location = new Point(0, 0);
            pnlDepartmentsColor.Name = "pnlDepartmentsColor";
            pnlDepartmentsColor.Size = new Size(8, 120);
            pnlDepartmentsColor.TabIndex = 2;
            // 
            // tlpGrids
            // 
            tlpGrids.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlpGrids.ColumnCount = 2;
            tlpGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlpGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpGrids.Controls.Add(pnlRecentPatientsContainer, 0, 0);
            tlpGrids.Controls.Add(pnlDepartmentsContainer, 1, 0);
            tlpGrids.Location = new Point(25, 220);
            tlpGrids.Name = "tlpGrids";
            tlpGrids.RowCount = 1;
            tlpGrids.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpGrids.Size = new Size(1250, 460);
            tlpGrids.TabIndex = 2;
            // 
            // pnlRecentPatientsContainer
            // 
            pnlRecentPatientsContainer.Controls.Add(lblRecentPatients);
            pnlRecentPatientsContainer.Controls.Add(dgvRecentPatients);
            pnlRecentPatientsContainer.Dock = DockStyle.Fill;
            pnlRecentPatientsContainer.Location = new Point(5, 5);
            pnlRecentPatientsContainer.Margin = new Padding(5);
            pnlRecentPatientsContainer.Name = "pnlRecentPatientsContainer";
            pnlRecentPatientsContainer.Size = new Size(802, 450);
            pnlRecentPatientsContainer.TabIndex = 0;
            // 
            // lblRecentPatients
            // 
            lblRecentPatients.AutoSize = true;
            lblRecentPatients.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblRecentPatients.ForeColor = Color.FromArgb(52, 73, 94);
            lblRecentPatients.Location = new Point(5, 5);
            lblRecentPatients.Name = "lblRecentPatients";
            lblRecentPatients.Size = new Size(215, 37);
            lblRecentPatients.TabIndex = 0;
            lblRecentPatients.Text = "Recent Patients";
            // 
            // dgvRecentPatients
            // 
            dgvRecentPatients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRecentPatients.BackgroundColor = Color.White;
            dgvRecentPatients.BorderStyle = BorderStyle.None;
            dgvRecentPatients.ColumnHeadersHeight = 29;
            dgvRecentPatients.Location = new Point(5, 45);
            dgvRecentPatients.Name = "dgvRecentPatients";
            dgvRecentPatients.RowHeadersWidth = 51;
            dgvRecentPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentPatients.Size = new Size(792, 400);
            dgvRecentPatients.TabIndex = 1;
            // 
            // pnlDepartmentsContainer
            // 
            pnlDepartmentsContainer.Controls.Add(lblDepartments);
            pnlDepartmentsContainer.Controls.Add(dgvDepartments);
            pnlDepartmentsContainer.Dock = DockStyle.Fill;
            pnlDepartmentsContainer.Location = new Point(817, 5);
            pnlDepartmentsContainer.Margin = new Padding(5);
            pnlDepartmentsContainer.Name = "pnlDepartmentsContainer";
            pnlDepartmentsContainer.Size = new Size(428, 450);
            pnlDepartmentsContainer.TabIndex = 1;
            // 
            // lblDepartments
            // 
            lblDepartments.AutoSize = true;
            lblDepartments.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDepartments.ForeColor = Color.FromArgb(52, 73, 94);
            lblDepartments.Location = new Point(5, 5);
            lblDepartments.Name = "lblDepartments";
            lblDepartments.Size = new Size(186, 37);
            lblDepartments.TabIndex = 0;
            lblDepartments.Text = "Departments";
            // 
            // dgvDepartments
            // 
            dgvDepartments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDepartments.BackgroundColor = Color.White;
            dgvDepartments.BorderStyle = BorderStyle.None;
            dgvDepartments.ColumnHeadersHeight = 29;
            dgvDepartments.Location = new Point(5, 45);
            dgvDepartments.Name = "dgvDepartments";
            dgvDepartments.RowHeadersWidth = 51;
            dgvDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepartments.Size = new Size(418, 400);
            dgvDepartments.TabIndex = 1;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(tlpGrids);
            Controls.Add(tlpCards);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "DashboardControl";
            Size = new Size(1300, 700);
            tlpCards.ResumeLayout(false);
            pnlDoctors.ResumeLayout(false);
            pnlDoctors.PerformLayout();
            pnlStaffs.ResumeLayout(false);
            pnlStaffs.PerformLayout();
            pnlPatients.ResumeLayout(false);
            pnlPatients.PerformLayout();
            pnlDepartments.ResumeLayout(false);
            pnlDepartments.PerformLayout();
            tlpGrids.ResumeLayout(false);
            pnlRecentPatientsContainer.ResumeLayout(false);
            pnlRecentPatientsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentPatients).EndInit();
            pnlDepartmentsContainer.ResumeLayout(false);
            pnlDepartmentsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TableLayoutPanel tlpCards;
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
        private TableLayoutPanel tlpGrids;
        private Panel pnlRecentPatientsContainer;
        private Label lblRecentPatients;
        private DataGridView dgvRecentPatients;
        private Panel pnlDepartmentsContainer;
        private Label lblDepartments;
        private DataGridView dgvDepartments;
    }
}
