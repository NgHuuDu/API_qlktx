using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Payments;
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class PaymentBUS : IPaymentBUS
    {
        private readonly IPaymentDAO _paymentDAO;
        private readonly IContractDAO _contractDAO;
        private readonly IMapper _mapper;

        public PaymentBUS(IPaymentDAO paymentDAO, IContractDAO contractDAO, IMapper mapper)
        {
            _paymentDAO = paymentDAO;
            _contractDAO = contractDAO;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentReadDTO>> GetAllPaymentsAsync()
        {
            IEnumerable<Payment> payments = await _paymentDAO.GetAllPaymentsAsync();
            return _mapper.Map<IEnumerable<PaymentReadDTO>>(payments);
        }

        public async Task<PaymentReadDTO?> GetPaymentByIDAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Payment ID cannot be empty");

            Payment? payment = await _paymentDAO.GetPaymentByIDAsync(id);
            if (payment == null) return null;

            return _mapper.Map<PaymentReadDTO>(payment);
        }

        public async Task<IEnumerable<PaymentReadDTO>> GetPaymentsByContractIDAsync(string contractId)
        {
            if (string.IsNullOrWhiteSpace(contractId))
                throw new ArgumentException("Contract ID cannot be empty");

            Contract? contract = await _contractDAO.GetContractByIDAsync(contractId);
            if (contract == null)
                throw new KeyNotFoundException($"Contract with ID {contractId} not found.");

            IEnumerable<Payment> payments = await _paymentDAO.GetPaymentsByContractIDAsync(contractId);
            return _mapper.Map<IEnumerable<PaymentReadDTO>>(payments);
        }

        public async Task<IEnumerable<PaymentReadDTO>> GetPaymentsByStatusAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status cannot be empty");

            IEnumerable<Payment> payments = await _paymentDAO.GetPaymentsByStatusAsync(status);
            return _mapper.Map<IEnumerable<PaymentReadDTO>>(payments);
        }

        public async Task<string> AddPaymentAsync(PaymentCreateDTO dto)
        {
            Payment? existingPayment = await _paymentDAO.GetPaymentByIDAsync(dto.PaymentID);
            if (existingPayment != null)
                throw new InvalidOperationException($"Payment with ID {dto.PaymentID} already exists.");

            Contract? contract = await _contractDAO.GetContractByIDAsync(dto.ContractID);
            if (contract == null)
                throw new KeyNotFoundException($"Contract with ID {dto.ContractID} not found.");

            if (dto.PaidAmount > dto.PaymentAmount)
                throw new InvalidOperationException("Paid amount cannot exceed the required payment amount.");

            // Auto-update Status based on Paid Amount if logic dictates
            // If user sends "Unpaid" but PaidAmount == PaymentAmount, we might want to correct it.
            // However, we will respect the DTO's Status unless it's clearly invalid logic.
            if (dto.PaidAmount >= dto.PaymentAmount && dto.PaymentStatus == "Unpaid")
                dto.PaymentStatus = "Paid";

            Payment paymentEntity = _mapper.Map<Payment>(dto);

            if (paymentEntity.Paymentdate == null)
            {
                paymentEntity.Paymentdate = DateTime.Now;
            }

            await _paymentDAO.AddPaymentAsync(paymentEntity);

            return paymentEntity.Paymentid;
        }

        public async Task UpdatePaymentAsync(string id, PaymentUpdateDTO dto)
        {
            Payment? paymentEntity = await _paymentDAO.GetPaymentByIDAsync(id);
            if (paymentEntity == null)
                throw new KeyNotFoundException($"Payment with ID {id} not found.");

            if (dto.PaidAmount > paymentEntity.Paymentamount)
                throw new InvalidOperationException($"Paid amount ({dto.PaidAmount}) cannot exceed the original bill amount ({paymentEntity.Paymentamount}).");

            _mapper.Map(dto, paymentEntity);

            paymentEntity.Paymentid = id;

            // Auto-correct Status logic (Optional convenience)
            if (paymentEntity.Paidamount >= paymentEntity.Paymentamount && paymentEntity.Paymentstatus != "Paid")
            {
                paymentEntity.Paymentstatus = "Paid";
            }
            else if (paymentEntity.Paidamount < paymentEntity.Paymentamount && paymentEntity.Paymentstatus == "Paid")
            {
                // If someone updates it to 'Paid' but amount is insufficient, warn or revert?
                // Here we trust the DTO status but it's good to be aware.
                // Let's allow it for now in case of manual override.
            }

            await _paymentDAO.UpdatePaymentAsync(paymentEntity);
        }

        public async Task DeletePaymentAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Payment ID cannot be empty");

            Payment? payment = await _paymentDAO.GetPaymentByIDAsync(id);
            if (payment == null)
                throw new KeyNotFoundException($"Payment with ID {id} not found.");

            await _paymentDAO.RemovePaymentAsync(id);
        }


        public async Task<IEnumerable<PaymentReadDTO>> GetPendingBillsByStudentAsync(string studentId)
        {
            // Tìm hợp đồng Active của SV
            var contract = await _contractDAO.GetActiveContractByStudentIDAsync(studentId);
            if (contract == null) return new List<PaymentReadDTO>(); // Chưa có hợp đồng -> Không có hóa đơn

            // Lấy tất cả payments
            var allPayments = await _paymentDAO.GetPaymentsByContractIDAsync(contract.Contractid);

            // Lọc: Lấy những cái CHƯA TRẢ (Unpaid, Late)
            var pendingBills = allPayments
                .Where(p => p.Paymentstatus == "Unpaid" || p.Paymentstatus == "Late")
                .OrderBy(p => p.Billmonth); // Sắp xếp theo tháng

            return _mapper.Map<IEnumerable<PaymentReadDTO>>(pendingBills);
        }

        public async Task<IEnumerable<PaymentReadDTO>> GetPaymentHistoryByStudentAsync(string studentId)
        {
            // Tìm hợp đồng Active
            // (Hoặc bạn có thể sửa DAO để lấy tất cả hợp đồng nếu muốn xem lịch sử cũ hơn)
            var contract = await _contractDAO.GetActiveContractByStudentIDAsync(studentId);
            if (contract == null) return new List<PaymentReadDTO>();

            //  Lấy tất cả payments
            var allPayments = await _paymentDAO.GetPaymentsByContractIDAsync(contract.Contractid);

            // Lọc: Lấy những cái ĐÃ TRẢ (Paid)
            var history = allPayments
                .Where(p => p.Paymentstatus == "Paid")
                .OrderByDescending(p => p.Paymentdate); // Mới nhất lên đầu

            return _mapper.Map<IEnumerable<PaymentReadDTO>>(history);
        }
    }
}