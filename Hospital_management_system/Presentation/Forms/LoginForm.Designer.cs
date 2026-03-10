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
            pnlLeft = new Panel();
            lblTitleLeft = new Label();
            pictureBox1 = new PictureBox();
            pnlRight = new Panel();
            btnExit = new Button();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            tbUsername = new TextBox();
            label3 = new Label();
            tbPassword = new TextBox();
            cbShowPassword = new CheckBox();
            btnLogin = new Button();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlRight.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(30, 41, 59);
            pnlLeft.Controls.Add(lblTitleLeft);
            pnlLeft.Controls.Add(pictureBox1);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(350, 450);
            pnlLeft.TabIndex = 0;
            // 
            // lblTitleLeft
            // 
            lblTitleLeft.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitleLeft.ForeColor = Color.White;
            lblTitleLeft.Location = new Point(0, 270);
            lblTitleLeft.Name = "lblTitleLeft";
            lblTitleLeft.Size = new Size(350, 80);
            lblTitleLeft.TabIndex = 1;
            lblTitleLeft.Text = "Hospital Management\nSystem";
            lblTitleLeft.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(100, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(btnExit);
            pnlRight.Controls.Add(label1);
            pnlRight.Controls.Add(tableLayoutPanel1);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(350, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(450, 450);
            pnlRight.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(108, 122, 137);
            btnExit.Location = new Point(410, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(35, 35);
            btnExit.TabIndex = 2;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(40, 40);
            label1.Name = "label1";
            label1.Size = new Size(297, 54);
            label1.TabIndex = 0;
            label1.Text = "Welcome Back";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(tbUsername, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(tbPassword, 0, 3);
            tableLayoutPanel1.Controls.Add(cbShowPassword, 0, 4);
            tableLayoutPanel1.Controls.Add(btnLogin, 0, 5);
            tableLayoutPanel1.Location = new Point(45, 110);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(360, 280);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(108, 122, 137);
            label2.Location = new Point(0, 10);
            label2.Margin = new Padding(0, 10, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 0;
            label2.Text = "Username";
            // 
            // tbUsername
            // 
            tbUsername.BorderStyle = BorderStyle.FixedSingle;
            tbUsername.Font = new Font("Segoe UI", 14F);
            tbUsername.Location = new Point(0, 35);
            tbUsername.Margin = new Padding(0);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(360, 39);
            tbUsername.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(108, 122, 137);
            label3.Location = new Point(0, 95);
            label3.Margin = new Padding(0, 10, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.Font = new Font("Segoe UI", 14F);
            tbPassword.Location = new Point(0, 120);
            tbPassword.Margin = new Padding(0);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '•';
            tbPassword.Size = new Size(360, 39);
            tbPassword.TabIndex = 3;
            // 
            // cbShowPassword
            // 
            cbShowPassword.AutoSize = true;
            cbShowPassword.Font = new Font("Segoe UI", 10F);
            cbShowPassword.ForeColor = Color.FromArgb(108, 122, 137);
            cbShowPassword.Location = new Point(0, 175);
            cbShowPassword.Margin = new Padding(0, 5, 0, 0);
            cbShowPassword.Name = "cbShowPassword";
            cbShowPassword.Size = new Size(148, 27);
            cbShowPassword.TabIndex = 4;
            cbShowPassword.Text = "Show Password";
            cbShowPassword.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(52, 152, 219);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(0, 225);
            btnLogin.Margin = new Padding(0, 15, 0, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(360, 45);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - HMS";
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
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
