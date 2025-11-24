using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.UserControls;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class mainMenu : Form
    {
        private UserControl? currentActiveControl = null;

        private Button? activeButton = null;

        public mainMenu()
        {
            InitializeComponent();
            
            // Sidebar buttons
            StyleSidebarButton(btnDashboard, true);
            StyleSidebarButton(btnRoom);
            StyleSidebarButton(btnContract);
            StyleSidebarButton(btnPayment);
            StyleSidebarButton(btnViolation);
            StyleSidebarButton(btnStatistics);
            StyleSidebarButton(btnLogout);
            activeButton = btnDashboard;
        }

        private void StyleSidebarButton(Button btn, bool isActive = false)
        {
            ControlStyler.StyleSidebarButton(btn, isActive);
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            if (GlobalState.CurrentUser == null)
            {
                // Nếu chưa đăng nhập, đá về Login
                HandleLogout();
                return;
            }

            // Load Dashboard làm mặc định
            LoadUserControl(new ucDashboard());
        }

        /// <summary>
        /// Hàm trung tâm để load UserControl vào Panel nội dung.
        /// </summary>
        private void LoadUserControl(UserControl uc)
        {
            // Giả sử panel nội dung của bạn tên là pnlContent
            if (pnlContent == null) return;

            if (currentActiveControl?.GetType() == uc.GetType())
            {
                uc.Dispose();
                return;
            }

            currentActiveControl?.Dispose();
            pnlContent.Controls.Clear();

            currentActiveControl = uc;
            
            // Set kích thước đúng trước khi dock để đảm bảo layout giống Designer
            uc.Size = new Size(
                pnlContent.ClientSize.Width - pnlContent.Padding.Left - pnlContent.Padding.Right,
                pnlContent.ClientSize.Height - pnlContent.Padding.Top - pnlContent.Padding.Bottom
            );
            
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        // --- Gán các sự kiện Click cho nút Menu ---

        // (Đây là tên nút ví dụ, bạn hãy đổi tên cho đúng
        // với các nút trong mainMenu.Designer.cs của bạn)

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDashboard);
            LoadUserControl(new ucDashboard());
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnRoom);
            LoadUserControl(new ucRoomManagement());
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnContract);
            LoadUserControl(new ucContractManagement());
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnPayment);
            LoadUserControl(new ucPaymentManagement());
        }

        private void btnViolation_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnViolation);
            LoadUserControl(new ucViolationManagement());
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnStatistics);
            LoadUserControl(new ucStatistics());
        }

        private void SetActiveButton(Button btn)
        {
            if (activeButton != null)
            {
                ControlStyler.StyleSidebarButton(activeButton, false);
            }
            activeButton = btn;
            ControlStyler.StyleSidebarButton(btn, true);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // (Thêm SiticoneMessageDialog hỏi xác nhận)
            HandleLogout();
        }

        private void HandleLogout()
        {
            ApiService.Logout();
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
            // Dispose mainMenu form để giải phóng tài nguyên
            this.Dispose();
        }

        private void mainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Đảm bảo app tắt hẳn
        }


    }
}
