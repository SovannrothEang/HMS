namespace Hospital_management_system.Presentation.UserControls
{
    partial class DepartmentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRefresh = new Button();
            deprtDgv = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)deprtDgv).BeginInit();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(22, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(93, 38);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // deprtDgv
            // 
            deprtDgv.AllowUserToAddRows = false;
            deprtDgv.AllowUserToDeleteRows = false;
            deprtDgv.AllowUserToResizeColumns = false;
            deprtDgv.AllowUserToResizeRows = false;
            deprtDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            deprtDgv.Columns.AddRange(new DataGridViewColumn[] { ID, Column1, Column2 });
            deprtDgv.Location = new Point(22, 59);
            deprtDgv.Name = "deprtDgv";
            deprtDgv.RowHeadersVisible = false;
            deprtDgv.Size = new Size(731, 507);
            deprtDgv.TabIndex = 1;
            // 
            // ID
            // 
            ID.HeaderText = "Code";
            ID.Name = "ID";
            // 
            // Column1
            // 
            Column1.HeaderText = "Name";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Description";
            Column2.Name = "Column2";
            // 
            // DepartmentControl
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(deprtDgv);
            Controls.Add(btnRefresh);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            MaximumSize = new Size(1200, 700);
            MinimumSize = new Size(1200, 700);
            Name = "DepartmentControl";
            Size = new Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)deprtDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRefresh;
        private DataGridView deprtDgv;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}
