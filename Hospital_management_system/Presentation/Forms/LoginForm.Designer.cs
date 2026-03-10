using System.Windows.Forms;
using System.Drawing;

namespace Hospital_management_system.Presentation.Forms
{
    partial class LoginForm
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
            this.pnlLeft = new Panel();
            this.lblTitleLeft = new Label();
            this.pictureBox1 = new PictureBox();
            this.pnlRight = new Panel();
            this.label1 = new Label();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label2 = new Label();
            this.tbUsername = new TextBox();
            this.label3 = new Label();
            this.tbPassword = new TextBox();
            this.cbShowPassword = new CheckBox();
            this.btnLogin = new Button();
            this.btnExit = new Button();
            
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = Color.FromArgb(30, 41, 59);
            this.pnlLeft.Controls.Add(this.lblTitleLeft);
            this.pnlLeft.Controls.Add(this.pictureBox1);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Location = new Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new Size(350, 450);
            this.pnlLeft.TabIndex = 0;
            
            // 
            // lblTitleLeft
            // 
            this.lblTitleLeft.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitleLeft.ForeColor = Color.White;
            this.lblTitleLeft.Location = new Point(0, 270);
            this.lblTitleLeft.Name = "lblTitleLeft";
            this.lblTitleLeft.Size = new Size(350, 80);
            this.lblTitleLeft.TabIndex = 1;
            this.lblTitleLeft.Text = "Hospital Management\nSystem";
            this.lblTitleLeft.TextAlign = ContentAlignment.MiddleCenter;
            
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = Properties.Resources.logo;
            this.pictureBox1.Location = new Point(100, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(150, 150);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = Color.White;
            this.pnlRight.Controls.Add(this.btnExit);
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Controls.Add(this.tableLayoutPanel1);
            this.pnlRight.Dock = DockStyle.Fill;
            this.pnlRight.Location = new Point(350, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new Size(450, 450);
            this.pnlRight.TabIndex = 1;
            
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.btnExit.ForeColor = Color.FromArgb(108, 122, 137);
            this.btnExit.Location = new Point(410, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(35, 35);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "X";
            this.btnExit.Cursor = Cursors.Hand;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.label1.ForeColor = Color.FromArgb(44, 62, 80);
            this.label1.Location = new Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new Size(238, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Back";
            
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbUsername, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbPassword, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbShowPassword, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnLogin, 0, 5);
            this.tableLayoutPanel1.Location = new Point(45, 110);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new Size(360, 280);
            this.tableLayoutPanel1.TabIndex = 1;
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.label2.ForeColor = Color.FromArgb(108, 122, 137);
            this.label2.Location = new Point(0, 10);
            this.label2.Margin = new Padding(0, 10, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(83, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username";
            
            // 
            // tbUsername
            // 
            this.tbUsername.BorderStyle = BorderStyle.FixedSingle;
            this.tbUsername.Font = new Font("Segoe UI", 14F);
            this.tbUsername.Location = new Point(0, 35);
            this.tbUsername.Margin = new Padding(0);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new Size(360, 32);
            this.tbUsername.TabIndex = 1;
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.label3.ForeColor = Color.FromArgb(108, 122, 137);
            this.label3.Location = new Point(0, 95);
            this.label3.Margin = new Padding(0, 10, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(79, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = BorderStyle.FixedSingle;
            this.tbPassword.Font = new Font("Segoe UI", 14F);
            this.tbPassword.Location = new Point(0, 120);
            this.tbPassword.Margin = new Padding(0);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '\u2022';

            this.tbPassword.TabIndex = 3;
            
            // 
            // cbShowPassword
            // 
            this.cbShowPassword.AutoSize = true;
            this.cbShowPassword.Font = new Font("Segoe UI", 10F);
            this.cbShowPassword.ForeColor = Color.FromArgb(108, 122, 137);
            this.cbShowPassword.Location = new Point(0, 175);
            this.cbShowPassword.Margin = new Padding(0, 5, 0, 0);
            this.cbShowPassword.Name = "cbShowPassword";
            this.cbShowPassword.Size = new Size(124, 23);
            this.cbShowPassword.TabIndex = 4;
            this.cbShowPassword.Text = "Show Password";
            this.cbShowPassword.UseVisualStyleBackColor = true;
            
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = Color.FromArgb(52, 152, 219);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(0, 225);
            this.btnLogin.Margin = new Padding(0, 15, 0, 0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(360, 45);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 21F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login - HMS";
            
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private PictureBox pictureBox1;
        private Label lblTitleLeft;
        
        private Panel pnlRight;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private TextBox tbUsername;
        private Label label3;
        private TextBox tbPassword;
        private CheckBox cbShowPassword;
        private Button btnLogin;
        private Button btnExit;
    }
}
