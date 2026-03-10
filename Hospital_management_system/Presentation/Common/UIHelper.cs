using System.Drawing;
using System.Windows.Forms;

namespace Hospital_management_system.Presentation.Common
{
    public static class UIHelper
    {
        public static void ApplyModernGridStyle(this DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 246, 250);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(108, 122, 137);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 246, 250);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 45;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 40;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
        }

        public static void ApplyModernButtonStyle(this Button btn, Color primaryColor, Color textColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = primaryColor;
            btn.ForeColor = textColor;
            btn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        public static void ApplyModernTextBoxStyle(this TextBox tb)
        {
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.Font = new Font("Segoe UI", 11F);
        }

        public static void ApplyModernInputStyles(this Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    tb.Font = new Font("Segoe UI", 11F);
                }
                else if (c is ComboBox cb)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;
                    cb.FlatStyle = FlatStyle.Standard;
                    cb.Font = new Font("Segoe UI", 11F);
                }
                else if (c is DateTimePicker dtp)
                {
                    dtp.Font = new Font("Segoe UI", 11F);
                }
                else if (c is Label lbl)
                {
                    // Only apply to standard labels, don't override title styles
                    if (lbl.Font.Size < 18)
                    {
                        lbl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
                        lbl.ForeColor = Color.FromArgb(52, 73, 94);
                    }
                }

                if (c.HasChildren)
                {
                    c.ApplyModernInputStyles();
                }
            }
        }
    }
}
