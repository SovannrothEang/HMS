namespace Hospital_management_system
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            panel1 = new Panel();
            lbUsername = new Label();
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            btnPatient = new Button();
            btnStaff = new Button();
            btnDepartment = new Button();
            btnDoctor = new Button();
            btnDashboard = new Button();
            mainPanel = new Panel();
            btnUser = new Button();
            panelSidebar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(30, 41, 59);
            panelSidebar.Controls.Add(btnUser);
            panelSidebar.Controls.Add(panel1);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(pictureBox1);
            panelSidebar.Controls.Add(btnPatient);
            panelSidebar.Controls.Add(btnStaff);
            panelSidebar.Controls.Add(btnDepartment);
            panelSidebar.Controls.Add(btnDoctor);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(220, 700);
            panelSidebar.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(15, 23, 42);
            panel1.Controls.Add(lbUsername);
            panel1.Location = new Point(0, 590);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 60);
            panel1.TabIndex = 0;
            // 
            // lbUsername
            // 
            lbUsername.BackColor = Color.Transparent;
            lbUsername.Dock = DockStyle.Fill;
            lbUsername.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lbUsername.ForeColor = Color.White;
            lbUsername.Location = new Point(0, 0);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(220, 60);
            lbUsername.TabIndex = 1;
            lbUsername.Text = "username";
            lbUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(220, 38, 38);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 650);
            btnLogout.Margin = new Padding(0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 50);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(45, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnPatient
            // 
            btnPatient.BackColor = Color.FromArgb(30, 41, 59);
            btnPatient.Cursor = Cursors.Hand;
            btnPatient.FlatAppearance.BorderSize = 0;
            btnPatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnPatient.ForeColor = Color.FromArgb(203, 213, 225);
            btnPatient.Location = new Point(0, 380);
            btnPatient.Margin = new Padding(0);
            btnPatient.Name = "btnPatient";
            btnPatient.Padding = new Padding(25, 0, 0, 0);
            btnPatient.Size = new Size(220, 50);
            btnPatient.TabIndex = 4;
            btnPatient.Text = "Patients";
            btnPatient.TextAlign = ContentAlignment.MiddleLeft;
            btnPatient.UseVisualStyleBackColor = false;
            // 
            // btnStaff
            // 
            btnStaff.BackColor = Color.FromArgb(30, 41, 59);
            btnStaff.Cursor = Cursors.Hand;
            btnStaff.FlatAppearance.BorderSize = 0;
            btnStaff.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnStaff.ForeColor = Color.FromArgb(203, 213, 225);
            btnStaff.Location = new Point(0, 330);
            btnStaff.Margin = new Padding(0);
            btnStaff.Name = "btnStaff";
            btnStaff.Padding = new Padding(25, 0, 0, 0);
            btnStaff.Size = new Size(220, 50);
            btnStaff.TabIndex = 3;
            btnStaff.Text = "Staff";
            btnStaff.TextAlign = ContentAlignment.MiddleLeft;
            btnStaff.UseVisualStyleBackColor = false;
            // 
            // btnDepartment
            // 
            btnDepartment.BackColor = Color.FromArgb(30, 41, 59);
            btnDepartment.Cursor = Cursors.Hand;
            btnDepartment.FlatAppearance.BorderSize = 0;
            btnDepartment.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
            btnDepartment.FlatStyle = FlatStyle.Flat;
            btnDepartment.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnDepartment.ForeColor = Color.FromArgb(203, 213, 225);
            btnDepartment.Location = new Point(0, 230);
            btnDepartment.Margin = new Padding(0);
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Padding = new Padding(25, 0, 0, 0);
            btnDepartment.Size = new Size(220, 50);
            btnDepartment.TabIndex = 1;
            btnDepartment.Text = "Departments";
            btnDepartment.TextAlign = ContentAlignment.MiddleLeft;
            btnDepartment.UseVisualStyleBackColor = false;
            // 
            // btnDoctor
            // 
            btnDoctor.BackColor = Color.FromArgb(30, 41, 59);
            btnDoctor.Cursor = Cursors.Hand;
            btnDoctor.FlatAppearance.BorderSize = 0;
            btnDoctor.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
            btnDoctor.FlatStyle = FlatStyle.Flat;
            btnDoctor.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnDoctor.ForeColor = Color.FromArgb(203, 213, 225);
            btnDoctor.Location = new Point(0, 280);
            btnDoctor.Margin = new Padding(0);
            btnDoctor.Name = "btnDoctor";
            btnDoctor.Padding = new Padding(25, 0, 0, 0);
            btnDoctor.Size = new Size(220, 50);
            btnDoctor.TabIndex = 2;
            btnDoctor.Text = "Doctors";
            btnDoctor.TextAlign = ContentAlignment.MiddleLeft;
            btnDoctor.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(30, 41, 59);
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.FromArgb(203, 213, 225);
            btnDashboard.Location = new Point(0, 180);
            btnDashboard.Margin = new Padding(0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(25, 0, 0, 0);
            btnDashboard.Size = new Size(220, 50);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(220, 0);
            mainPanel.BackColor = Color.FromArgb(245, 246, 250);
            mainPanel.Margin = new Padding(0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1300, 700);
            mainPanel.TabIndex = 1;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.FromArgb(30, 41, 59);
            btnUser.Cursor = Cursors.Hand;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnUser.ForeColor = Color.FromArgb(203, 213, 225);
            btnUser.Location = new Point(0, 430);
            btnUser.Margin = new Padding(0);
            btnUser.Name = "btnUser";
            btnUser.Padding = new Padding(25, 0, 0, 0);
            btnUser.Size = new Size(220, 50);
            btnUser.TabIndex = 7;
            btnUser.Text = "Users";
            btnUser.TextAlign = ContentAlignment.MiddleLeft;
            btnUser.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1520, 700);
            Controls.Add(mainPanel);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hospital Management System";
            panelSidebar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel mainPanel;
        private Button btnDashboard;
        private Button btnDoctor;
        private Button btnDepartment;
        private Button btnStaff;
        private Button btnPatient;
        private PictureBox pictureBox1;
        private Button btnLogout;
        private Panel panel1;
        private Label lbUsername;
        private Button btnUser;
    }
}