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
            dgvPatient = new DataGridView();
            dgvStaff = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvPatient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 25);
            label1.Name = "label1";
            label1.Size = new Size(202, 37);
            label1.TabIndex = 0;
            label1.Text = "Total Staffs:";
            // 
            // lbStaff
            // 
            lbStaff.AutoSize = true;
            lbStaff.Font = new Font("Arial", 21.75F);
            lbStaff.Location = new Point(233, 28);
            lbStaff.Name = "lbStaff";
            lbStaff.Size = new Size(133, 33);
            lbStaff.TabIndex = 1;
            lbStaff.Text = "loading...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(448, 25);
            label3.Name = "label3";
            label3.Size = new Size(233, 37);
            label3.TabIndex = 2;
            label3.Text = "Total Doctors:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(888, 25);
            label5.Name = "label5";
            label5.Size = new Size(237, 37);
            label5.TabIndex = 4;
            label5.Text = "Total Patients:";
            // 
            // lbPatient
            // 
            lbPatient.AutoSize = true;
            lbPatient.Font = new Font("Arial", 21.75F);
            lbPatient.Location = new Point(1131, 28);
            lbPatient.Name = "lbPatient";
            lbPatient.Size = new Size(133, 33);
            lbPatient.TabIndex = 6;
            lbPatient.Text = "loading...";
            // 
            // lbDoctor
            // 
            lbDoctor.AutoSize = true;
            lbDoctor.Font = new Font("Arial", 21.75F);
            lbDoctor.Location = new Point(687, 28);
            lbDoctor.Name = "lbDoctor";
            lbDoctor.Size = new Size(133, 33);
            lbDoctor.TabIndex = 7;
            lbDoctor.Text = "loading...";
            // 
            // dgvPatient
            // 
            dgvPatient.AllowUserToAddRows = false;
            dgvPatient.AllowUserToDeleteRows = false;
            dgvPatient.AllowUserToResizeColumns = false;
            dgvPatient.AllowUserToResizeRows = false;
            dgvPatient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatient.Location = new Point(3, 294);
            dgvPatient.MultiSelect = false;
            dgvPatient.Name = "dgvPatient";
            dgvPatient.ReadOnly = true;
            dgvPatient.RowHeadersVisible = false;
            dgvPatient.Size = new Size(1244, 286);
            dgvPatient.TabIndex = 62;
            // 
            // dgvStaff
            // 
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.AllowUserToResizeColumns = false;
            dgvStaff.AllowUserToResizeRows = false;
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.Location = new Point(3, 3);
            dgvStaff.MultiSelect = false;
            dgvStaff.Name = "dgvStaff";
            dgvStaff.ReadOnly = true;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.Size = new Size(1244, 247);
            dgvStaff.TabIndex = 63;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dgvStaff, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvPatient, 0, 1);
            tableLayoutPanel1.Location = new Point(25, 98);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1250, 583);
            tableLayoutPanel1.TabIndex = 64;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
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
            ((System.ComponentModel.ISupportInitialize)dgvPatient).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
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
        private DataGridView dgvPatient;
        private DataGridView dgvStaff;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
