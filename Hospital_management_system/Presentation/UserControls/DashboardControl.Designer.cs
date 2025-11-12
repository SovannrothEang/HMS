using Hospital_management_system.Presentation.State;

namespace Hospital_management_system.Presentation.UserControls
{
    partial class DashboardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lbStaff = new Label();
            label3 = new Label();
            label5 = new Label();
            lbPatient = new Label();
            lbDoctor = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 36F, FontStyle.Bold);
            label1.Location = new Point(25, 128);
            label1.Name = "label1";
            label1.Size = new Size(299, 56);
            label1.TabIndex = 0;
            label1.Text = "Total Staffs:";
            // 
            // lbStaff
            // 
            lbStaff.AutoSize = true;
            lbStaff.Font = new Font("Arial", 27.75F);
            lbStaff.Location = new Point(140, 246);
            lbStaff.Name = "lbStaff";
            lbStaff.Size = new Size(166, 42);
            lbStaff.TabIndex = 1;
            lbStaff.Text = "loading...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 36F, FontStyle.Bold);
            label3.Location = new Point(431, 128);
            label3.Name = "label3";
            label3.Size = new Size(347, 56);
            label3.TabIndex = 2;
            label3.Text = "Total Doctors:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 36F, FontStyle.Bold);
            label5.Location = new Point(913, 128);
            label5.Name = "label5";
            label5.Size = new Size(352, 56);
            label5.TabIndex = 4;
            label5.Text = "Total Patients:";
            // 
            // lbPatient
            // 
            lbPatient.AutoSize = true;
            lbPatient.Font = new Font("Arial", 27.75F);
            lbPatient.Location = new Point(1081, 246);
            lbPatient.Name = "lbPatient";
            lbPatient.Size = new Size(166, 42);
            lbPatient.TabIndex = 6;
            lbPatient.Text = "loading...";
            // 
            // lbDoctor
            // 
            lbDoctor.AutoSize = true;
            lbDoctor.Font = new Font("Arial", 27.75F);
            lbDoctor.Location = new Point(594, 246);
            lbDoctor.Name = "lbDoctor";
            lbDoctor.Size = new Size(166, 42);
            lbDoctor.TabIndex = 7;
            lbDoctor.Text = "loading...";
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbDoctor);
            Controls.Add(lbPatient);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(lbStaff);
            Controls.Add(label1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "DashboardControl";
            Size = new Size(1300, 700);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbStaff;
        private Label label3;
        private Label label5;
        private Label lbPatient;
        private Label lbDoctor;
    }
}
