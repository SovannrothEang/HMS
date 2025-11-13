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
            panelSidebar.BackColor = Color.Silver;
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
            panelSidebar.Margin = new Padding(4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(194, 700);
            panelSidebar.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lbUsername);
            panel1.Location = new Point(12, 578);
            panel1.Name = "panel1";
            panel1.Size = new Size(174, 53);
            panel1.TabIndex = 0;
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.BackColor = Color.Transparent;
            lbUsername.Font = new Font("Arial", 22F);
            lbUsername.Location = new Point(14, 9);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(147, 35);
            lbUsername.TabIndex = 1;
            lbUsername.Text = "username";
            lbUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Red;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(12, 638);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(174, 49);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(174, 174);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnPatient
            // 
            btnPatient.BackColor = Color.White;
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnPatient.Location = new Point(12, 421);
            btnPatient.Margin = new Padding(4);
            btnPatient.Name = "btnPatient";
            btnPatient.Padding = new Padding(15, 0, 0, 0);
            btnPatient.Size = new Size(174, 49);
            btnPatient.TabIndex = 4;
            btnPatient.Text = "Patient";
            btnPatient.TextAlign = ContentAlignment.MiddleLeft;
            btnPatient.UseVisualStyleBackColor = false;
            // 
            // btnStaff
            // 
            btnStaff.BackColor = Color.White;
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnStaff.Location = new Point(12, 364);
            btnStaff.Margin = new Padding(4);
            btnStaff.Name = "btnStaff";
            btnStaff.Padding = new Padding(15, 0, 0, 0);
            btnStaff.Size = new Size(174, 49);
            btnStaff.TabIndex = 3;
            btnStaff.Text = "Staff";
            btnStaff.TextAlign = ContentAlignment.MiddleLeft;
            btnStaff.UseVisualStyleBackColor = false;
            // 
            // btnDepartment
            // 
            btnDepartment.BackColor = Color.White;
            btnDepartment.FlatStyle = FlatStyle.Flat;
            btnDepartment.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnDepartment.Location = new Point(12, 250);
            btnDepartment.Margin = new Padding(4);
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Padding = new Padding(15, 0, 0, 0);
            btnDepartment.Size = new Size(174, 49);
            btnDepartment.TabIndex = 1;
            btnDepartment.Text = "Department";
            btnDepartment.TextAlign = ContentAlignment.MiddleLeft;
            btnDepartment.UseVisualStyleBackColor = false;
            // 
            // btnDoctor
            // 
            btnDoctor.BackColor = Color.White;
            btnDoctor.FlatStyle = FlatStyle.Flat;
            btnDoctor.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnDoctor.Location = new Point(12, 307);
            btnDoctor.Margin = new Padding(4);
            btnDoctor.Name = "btnDoctor";
            btnDoctor.Padding = new Padding(15, 0, 0, 0);
            btnDoctor.Size = new Size(174, 49);
            btnDoctor.TabIndex = 2;
            btnDoctor.Text = "Doctor";
            btnDoctor.TextAlign = ContentAlignment.MiddleLeft;
            btnDoctor.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.White;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnDashboard.Location = new Point(12, 193);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(15, 0, 0, 0);
            btnDashboard.Size = new Size(174, 49);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(194, 0);
            mainPanel.Margin = new Padding(4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1300, 700);
            mainPanel.TabIndex = 1;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.White;
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnUser.Location = new Point(12, 478);
            btnUser.Margin = new Padding(4);
            btnUser.Name = "btnUser";
            btnUser.Padding = new Padding(15, 0, 0, 0);
            btnUser.Size = new Size(174, 49);
            btnUser.TabIndex = 7;
            btnUser.Text = "User";
            btnUser.TextAlign = ContentAlignment.MiddleLeft;
            btnUser.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1494, 700);
            Controls.Add(mainPanel);
            Controls.Add(panelSidebar);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(1510, 739);
            MinimumSize = new Size(1510, 739);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HMS";
            panelSidebar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
