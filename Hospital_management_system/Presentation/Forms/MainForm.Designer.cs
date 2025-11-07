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
            btnExit = new Button();
            btnDoctor = new Button();
            btnDashboard = new Button();
            mainPanel = new Panel();
            btnDepartment = new Button();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = SystemColors.ButtonShadow;
            panelSidebar.Controls.Add(btnDepartment);
            panelSidebar.Controls.Add(btnExit);
            panelSidebar.Controls.Add(btnDoctor);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(194, 739);
            panelSidebar.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(8, 676);
            btnExit.Margin = new Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(178, 49);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnDoctor
            // 
            btnDoctor.BackColor = Color.White;
            btnDoctor.FlatStyle = FlatStyle.Flat;
            btnDoctor.Location = new Point(8, 175);
            btnDoctor.Margin = new Padding(4);
            btnDoctor.Name = "btnDoctor";
            btnDoctor.Size = new Size(178, 49);
            btnDoctor.TabIndex = 1;
            btnDoctor.Text = "Doctor";
            btnDoctor.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.White;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Location = new Point(8, 61);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(178, 49);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(194, 0);
            mainPanel.Margin = new Padding(4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1216, 739);
            mainPanel.TabIndex = 1;
            // 
            // btnDepartment
            // 
            btnDepartment.BackColor = Color.White;
            btnDepartment.FlatStyle = FlatStyle.Flat;
            btnDepartment.Location = new Point(8, 118);
            btnDepartment.Margin = new Padding(4);
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Size = new Size(178, 49);
            btnDepartment.TabIndex = 3;
            btnDepartment.Text = "Department";
            btnDepartment.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1410, 739);
            Controls.Add(mainPanel);
            Controls.Add(panelSidebar);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1410, 739);
            MinimumSize = new Size(1410, 739);
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
    }
}
