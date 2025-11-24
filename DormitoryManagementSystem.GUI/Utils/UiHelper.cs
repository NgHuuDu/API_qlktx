using System;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Utils
{
    public static class UiHelper
    {
        public static void ShowError(Form parent, string message)
        {
            MessageBox.Show(parent, message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(Form parent, string message)
        {
            MessageBox.Show(parent, message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowLoading(Control parent)
        {
            // TODO: Implement loading indicator
        }

        public static void HideLoading(Control parent)
        {
            // TODO: Hide loading indicator
        }
    }
}

