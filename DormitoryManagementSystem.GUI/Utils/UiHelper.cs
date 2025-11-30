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

        public static void ShowWarning(Form parent, string message)
        {
            MessageBox.Show(parent, message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowConfirm(Form parent, string message, string title = "Xác nhận")
        {
            return MessageBox.Show(parent, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}

