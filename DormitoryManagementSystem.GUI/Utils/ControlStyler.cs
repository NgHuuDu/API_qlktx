using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DormitoryManagementSystem.GUI.Utils
{
    public static class ControlStyler
    {
        /// <summary>
        /// Apply modern styling to a button
        /// </summary>
        public static void StyleButton(Button btn, Color? backColor = null, Color? foreColor = null, bool isPrimary = false)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor ?? (isPrimary ? Theme.Primary : Theme.Surface);
            btn.ForeColor = foreColor ?? (isPrimary ? Color.White : Theme.TextPrimary);
            btn.Font = Theme.FontButton;
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;

            // Add hover effect
            btn.MouseEnter += (s, e) =>
            {
                if (isPrimary)
                    btn.BackColor = Theme.PrimaryDark;
                else
                    btn.BackColor = Theme.Background;
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = backColor ?? (isPrimary ? Theme.Primary : Theme.Surface);
            };
        }

        /// <summary>
        /// Apply modern styling to a textbox
        /// </summary>
        public static void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Theme.Surface;
            txt.ForeColor = Theme.TextPrimary;
            txt.Font = Theme.FontBody;
            txt.Height = 35;
            txt.Padding = new Padding(10, 8, 10, 8);

            txt.Enter += (s, e) =>
            {
                txt.BackColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
            };

            txt.Leave += (s, e) =>
            {
                txt.BackColor = Theme.Surface;
            };
        }

        /// <summary>
        /// Apply modern styling to a combobox
        /// </summary>
        public static void StyleComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.BackColor = Theme.Surface;
            cmb.ForeColor = Theme.TextPrimary;
            cmb.Font = Theme.FontBody;
            cmb.Height = 35;
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Apply modern styling to a DataGridView
        /// </summary>
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Theme.Background;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DefaultCellStyle.BackColor = Theme.Surface;
            dgv.DefaultCellStyle.ForeColor = Theme.TextPrimary;
            dgv.DefaultCellStyle.Font = Theme.FontBody;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.SelectionBackColor = Theme.PrimaryLight;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Theme.SidebarBackground;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = Theme.FontHeading;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 10, 10, 10);
            dgv.RowTemplate.Height = 45;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Theme.Background;
        }

        /// <summary>
        /// Apply modern styling to a panel
        /// </summary>
        public static void StylePanel(Panel pnl, Color? backColor = null)
        {
            pnl.BackColor = backColor ?? Theme.Background;
        }

        /// <summary>
        /// Apply modern styling to sidebar button
        /// </summary>
        public static void StyleSidebarButton(Button btn, bool isActive = false)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1; // Thêm viền
            btn.FlatAppearance.BorderColor = isActive ? Theme.SidebarActive : Color.FromArgb(122, 138, 255); 
            btn.BackColor = isActive ? Theme.SidebarActive : Theme.SidebarBackground;
            btn.ForeColor = Theme.SidebarText;
            btn.Font = Theme.FontButton;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(25, 0, 0, 0);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;

            // Xóa tất cả event handlers cũ
            btn.MouseEnter -= Button_MouseEnter;
            btn.MouseLeave -= Button_MouseLeave;

            if (!isActive)
            {
                // Thêm hover effect cho button không active
                btn.MouseEnter += Button_MouseEnter;
                btn.MouseLeave += Button_MouseLeave;
            }
        }

        private static void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Theme.SidebarHover; // Nhạt hơn khi hover
                btn.FlatAppearance.BorderColor = Theme.SidebarHover; // Đổi màu viền khi hover
            }
        }

        private static void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Theme.SidebarBackground; // Về màu gốc
                btn.FlatAppearance.BorderColor = Color.FromArgb(122, 138, 255); // Về màu viền gốc
            }
        }
    }
}

