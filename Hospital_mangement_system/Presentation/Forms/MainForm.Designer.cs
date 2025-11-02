namespace Hospital_mangement_system
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
            btnDoctor = new Button();
            btnDashboard = new Button();
            panelBody = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = SystemColors.ButtonShadow;
            panelSidebar.Controls.Add(btnDoctor);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(194, 692);
            panelSidebar.TabIndex = 0;
            // 
            // btnDoctor
            // 
            btnDoctor.Location = new Point(8, 118);
            btnDoctor.Margin = new Padding(4);
            btnDoctor.Name = "btnDoctor";
            btnDoctor.Size = new Size(178, 49);
            btnDoctor.TabIndex = 1;
            btnDoctor.Text = "Doctor";
            btnDoctor.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.Location = new Point(8, 61);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(178, 49);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            // 
            // panelBody
            // 
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(194, 0);
            panelBody.Margin = new Padding(4);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1142, 692);
            panelBody.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1336, 692);
            Controls.Add(panelBody);
            Controls.Add(panelSidebar);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Form1";
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelBody;
        private Button btnDashboard;
        private Button btnDoctor;
    }
}
