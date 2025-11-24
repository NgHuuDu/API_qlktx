using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.GUI.Services;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormClosing += Login_FormClosing;
        }

        // Thêm sự kiện Click cho nút Đăng nhập
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Giả sử tên control là txtUsername và txtPassword
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                UiHelper.ShowError(this, "Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            var loginRequest = new LoginRequest
            {
                Username = username,
                Password = password
            };

            UiHelper.ShowLoading(this);

            try
            {
                var response = await ApiService.LoginAsync(loginRequest);

                if (response != null && response.IsSuccess)
                {
                    // Đăng nhập thành công, mở Form mainMenu
                    mainMenu mainForm = new mainMenu();
                    mainForm.Show();
                    this.Hide(); // Ẩn form đăng nhập
                    // Lưu reference để có thể dispose sau
                    this.Tag = mainForm;
                }
                else
                {
                    UiHelper.ShowError(this, response?.Message ?? "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError(this, $"Không thể kết nối đến máy chủ. {ex.Message}");
            }
            finally
            {
                UiHelper.HideLoading(this);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSSO_Click(object sender, EventArgs e)
        {
            UiHelper.ShowSuccess(this, "Chức năng đăng nhập SSO (chưa hoàn thiện)");
        }
    }
}
