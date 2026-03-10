namespace Hospital_management_system
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnPosition = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbUsername = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            
            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.panelSidebar.Controls.Add(this.btnUser);
            this.panelSidebar.Controls.Add(this.btnPosition);
            this.panelSidebar.Controls.Add(this.btnPatient);
            this.panelSidebar.Controls.Add(this.btnStaff);
            this.panelSidebar.Controls.Add(this.btnDoctor);
            this.panelSidebar.Controls.Add(this.btnDepartment);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.panel1);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.pictureBox1);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 700);
            this.panelSidebar.TabIndex = 0;

            // pictureBox1
            this.pictureBox1.Image = global::Hospital_management_system.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(45, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;

            // btnDashboard
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnDashboard.Location = new System.Drawing.Point(0, 180);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(220, 50);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;

            // btnDepartment
            this.btnDepartment.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepartment.FlatAppearance.BorderSize = 0;
            this.btnDepartment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnDepartment.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnDepartment.Location = new System.Drawing.Point(0, 230);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnDepartment.Size = new System.Drawing.Size(220, 50);
            this.btnDepartment.TabIndex = 1;
            this.btnDepartment.Text = "Departments";
            this.btnDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartment.UseVisualStyleBackColor = false;

            // btnDoctor
            this.btnDoctor.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoctor.FlatAppearance.BorderSize = 0;
            this.btnDoctor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctor.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnDoctor.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnDoctor.Location = new System.Drawing.Point(0, 280);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnDoctor.Size = new System.Drawing.Size(220, 50);
            this.btnDoctor.TabIndex = 2;
            this.btnDoctor.Text = "Doctors";
            this.btnDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoctor.UseVisualStyleBackColor = false;

            // btnStaff
            this.btnStaff.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnStaff.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnStaff.Location = new System.Drawing.Point(0, 330);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnStaff.Size = new System.Drawing.Size(220, 50);
            this.btnStaff.TabIndex = 3;
            this.btnStaff.Text = "Staff";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.UseVisualStyleBackColor = false;

            // btnPatient
            this.btnPatient.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPatient.FlatAppearance.BorderSize = 0;
            this.btnPatient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatient.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnPatient.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnPatient.Location = new System.Drawing.Point(0, 380);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnPatient.Size = new System.Drawing.Size(220, 50);
            this.btnPatient.TabIndex = 4;
            this.btnPatient.Text = "Patients";
            this.btnPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatient.UseVisualStyleBackColor = false;

            // btnPosition
            this.btnPosition.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnPosition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosition.FlatAppearance.BorderSize = 0;
            this.btnPosition.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosition.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnPosition.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnPosition.Location = new System.Drawing.Point(0, 430);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnPosition.Size = new System.Drawing.Size(220, 50);
            this.btnPosition.TabIndex = 8;
            this.btnPosition.Text = "Positions";
            this.btnPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPosition.UseVisualStyleBackColor = false;

            // btnUser
            this.btnUser.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnUser.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnUser.Location = new System.Drawing.Point(0, 480);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnUser.Size = new System.Drawing.Size(220, 50);
            this.btnUser.TabIndex = 7;
            this.btnUser.Text = "Users";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.UseVisualStyleBackColor = false;

            // panel1
            this.panel1.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.panel1.Controls.Add(this.lbUsername);
            this.panel1.Location = new System.Drawing.Point(0, 590);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 60);
            this.panel1.TabIndex = 0;

            // lbUsername
            this.lbUsername.BackColor = System.Drawing.Color.Transparent;
            this.lbUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lbUsername.ForeColor = System.Drawing.Color.White;
            this.lbUsername.Location = new System.Drawing.Point(0, 0);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(220, 60);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "username";
            this.lbUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 650);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 50);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;

            // mainPanel
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(220, 0);
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1300, 700);
            this.mainPanel.TabIndex = 1;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 700);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management System";
            this.panelSidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnPosition;
    }
}
