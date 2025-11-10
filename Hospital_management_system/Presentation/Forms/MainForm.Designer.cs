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
            btnPatient = new Button();
            btnStaff = new Button();
            btnDepartment = new Button();
            btnExit = new Button();
            btnDoctor = new Button();
            btnDashboard = new Button();
            mainPanel = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = SystemColors.ButtonShadow;
            panelSidebar.Controls.Add(btnPatient);
            panelSidebar.Controls.Add(btnStaff);
            panelSidebar.Controls.Add(btnDepartment);
            panelSidebar.Controls.Add(btnExit);
            panelSidebar.Controls.Add(btnDoctor);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(194, 700);
            panelSidebar.TabIndex = 0;
            // 
            // btnPatient
            // 
            btnPatient.BackColor = Color.White;
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnPatient.Location = new Point(8, 333);
            btnPatient.Margin = new Padding(4);
            btnPatient.Name = "btnPatient";
            btnPatient.Padding = new Padding(10, 0, 0, 0);
            btnPatient.Size = new Size(178, 49);
            btnPatient.TabIndex = 3;
            btnPatient.Text = "Patient";
            btnPatient.TextAlign = ContentAlignment.MiddleLeft;
            btnPatient.UseVisualStyleBackColor = false;
            // 
            // btnStaff
            // 
            btnStaff.BackColor = Color.White;
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnStaff.Location = new Point(8, 390);
            btnStaff.Margin = new Padding(4);
            btnStaff.Name = "btnStaff";
            btnStaff.Padding = new Padding(10, 0, 0, 0);
            btnStaff.Size = new Size(178, 49);
            btnStaff.TabIndex = 4;
            btnStaff.Text = "Staff";
            btnStaff.TextAlign = ContentAlignment.MiddleLeft;
            btnStaff.UseVisualStyleBackColor = false;
            // 
            // btnDepartment
            // 
            btnDepartment.BackColor = Color.White;
            btnDepartment.FlatStyle = FlatStyle.Flat;
            btnDepartment.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnDepartment.Location = new Point(8, 219);
            btnDepartment.Margin = new Padding(4);
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Padding = new Padding(10, 0, 0, 0);
            btnDepartment.Size = new Size(178, 49);
            btnDepartment.TabIndex = 1;
            btnDepartment.Text = "Department";
            btnDepartment.TextAlign = ContentAlignment.MiddleLeft;
            btnDepartment.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(8, 638);
            btnExit.Margin = new Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(178, 49);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnDoctor
            // 
            btnDoctor.BackColor = Color.White;
            btnDoctor.FlatStyle = FlatStyle.Flat;
            btnDoctor.Font = new Font("Arial", 18F, FontStyle.Bold);
            btnDoctor.Location = new Point(8, 276);
            btnDoctor.Margin = new Padding(4);
            btnDoctor.Name = "btnDoctor";
            btnDoctor.Padding = new Padding(10, 0, 0, 0);
            btnDoctor.Size = new Size(178, 49);
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
            btnDashboard.Location = new Point(8, 162);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(10, 0, 0, 0);
            btnDashboard.Size = new Size(178, 49);
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
            mainPanel.Size = new Size(1200, 700);
            mainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1394, 700);
            Controls.Add(mainPanel);
            Controls.Add(panelSidebar);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1394, 700);
            MinimumSize = new Size(1394, 700);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HMS";
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel mainPanel;
        private Button btnDashboard;
        private Button btnDoctor;
        private Button btnExit;
        private Button btnDepartment;
        private Button btnStaff;
        private Button btnPatient;
    }
}
