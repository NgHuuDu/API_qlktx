using DormitoryManagementSystem.DTO.Payments;
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.DAO.Interfaces
{
    public interface IPaymentDAO
    {
        public Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        public Task<Payment?> GetPaymentByIDAsync(string id);
        public Task<IEnumerable<Payment>> GetPaymentsByContractIDAsync(string contractID);
        public Task<IEnumerable<Payment>> GetPaymentsByStatusAsync(string status);
        public Task AddPaymentAsync(Payment payment);
        public Task UpdatePaymentAsync(Payment payment);
        public Task RemovePaymentAsync(string id);





        //Cho Sinh viên: Lấy danh sách thanh toán (Lọc theo trạng thái: All, Paid, Pending)
        Task<IEnumerable<Payment>> GetPaymentsByStudentAndStatusAsync(string studentId, string? status);

        // Cho admin lọc và lấy danh sách
        Task<IEnumerable<Payment>> GetPaymentsForAdminAsync(
              int? month,
              string? status,
              string? building,
              string? searchKeyword);

        // Cho admin thống kê
        Task<PaymentStatsDTO> GetPaymentStatisticsAsync();

    }
}
