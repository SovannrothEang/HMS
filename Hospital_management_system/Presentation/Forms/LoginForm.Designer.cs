namespace Hospital_management_system.Presentation.Forms
{
    partial class LoginForm
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
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbUsername = new TextBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            tbPassword = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnLogin = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(527, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 37);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUsername.Location = new Point(3, 55);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(359, 32);
            tbUsername.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(25, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 300);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F);
            label2.Location = new Point(4, 8);
            label2.Margin = new Padding(4, 8, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(105, 24);
            label2.TabIndex = 3;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 15.75F);
            label3.Location = new Point(4, 112);
            label3.Margin = new Padding(4, 8, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(103, 24);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.Location = new Point(3, 159);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(359, 32);
            tbPassword.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(tbPassword, 0, 3);
            tableLayoutPanel1.Controls.Add(tbUsername, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(btnLogin, 0, 4);
            tableLayoutPanel1.Location = new Point(398, 65);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(374, 260);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(3, 211);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(116, 46);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 350);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbUsername;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private TextBox tbPassword;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnLogin;
    }
}