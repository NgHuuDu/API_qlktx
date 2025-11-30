using System;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI.Forms
{
    public partial class frmFilterPayment : Form
    {
        public string? PaymentID { get; private set; }
        public string? ContractID { get; private set; }
        public int? Month { get; private set; }
        public DateTime? PaymentDate { get; private set; }
        public string? PaymentMethod { get; private set; }
        public string? PaymentStatus { get; private set; }
        public bool IsApplied { get; private set; }

        public frmFilterPayment(
            string? currentPaymentID = null,
            string? currentContractID = null,
            int? currentMonth = null,
            DateTime? currentPaymentDate = null,
            string? currentPaymentMethod = null,
            string? currentPaymentStatus = null)
        {
            InitializeComponent();
            
            // Thiết lập giá trị mặc định
            txtPaymentID.Text = currentPaymentID ?? string.Empty;
            txtContractID.Text = currentContractID ?? string.Empty;
            
            if (currentMonth.HasValue && currentMonth.Value >= 1 && currentMonth.Value <= 12)
            {
                numMonth.Value = currentMonth.Value;
            }
            else
            {
                numMonth.Value = 1;
            }
            
            if (currentPaymentDate.HasValue)
            {
                dtpPaymentDate.Value = currentPaymentDate.Value;
                dtpPaymentDate.Checked = true;
            }
            else
            {
                dtpPaymentDate.Value = DateTime.Now;
                dtpPaymentDate.Checked = false;
            }
            
            // Thiết lập phương thức thanh toán
            if (!string.IsNullOrEmpty(currentPaymentMethod))
            {
                for (int i = 0; i < cmbPaymentMethod.Items.Count; i++)
                {
                    if (cmbPaymentMethod.Items[i].ToString() == currentPaymentMethod)
                    {
                        cmbPaymentMethod.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                if (cmbPaymentMethod.Items.Count > 0)
                    cmbPaymentMethod.SelectedIndex = 0;
            }
            
            // Thiết lập trạng thái thanh toán
            if (!string.IsNullOrEmpty(currentPaymentStatus))
            {
                for (int i = 0; i < cmbPaymentStatus.Items.Count; i++)
                {
                    if (cmbPaymentStatus.Items[i].ToString() == currentPaymentStatus)
                    {
                        cmbPaymentStatus.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                if (cmbPaymentStatus.Items.Count > 0)
                    cmbPaymentStatus.SelectedIndex = 0;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPaymentID.Text = string.Empty;
            txtContractID.Text = string.Empty;
            numMonth.Value = 1;
            dtpPaymentDate.Value = DateTime.Now;
            dtpPaymentDate.Checked = false;
            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;
            if (cmbPaymentStatus.Items.Count > 0)
                cmbPaymentStatus.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các controls
            PaymentID = string.IsNullOrWhiteSpace(txtPaymentID.Text) ? null : txtPaymentID.Text.Trim();
            ContractID = string.IsNullOrWhiteSpace(txtContractID.Text) ? null : txtContractID.Text.Trim();
            
            Month = numMonth.Value >= 1 && numMonth.Value <= 12 ? (int?)numMonth.Value : null;
            
            PaymentDate = dtpPaymentDate.Checked ? dtpPaymentDate.Value.Date : (DateTime?)null;
            
            // Trích xuất phương thức thanh toán
            if (cmbPaymentMethod.SelectedIndex > 0 && cmbPaymentMethod.SelectedItem != null)
            {
                string selected = cmbPaymentMethod.SelectedItem.ToString();
                PaymentMethod = selected == "Tất cả" ? null : selected;
            }
            else
            {
                PaymentMethod = null;
            }
            
            // Trích xuất trạng thái thanh toán
            if (cmbPaymentStatus.SelectedIndex > 0 && cmbPaymentStatus.SelectedItem != null)
            {
                string selected = cmbPaymentStatus.SelectedItem.ToString();
                PaymentStatus = selected == "Tất cả" ? null : selected;
            }
            else
            {
                PaymentStatus = null;
            }
            
            IsApplied = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
