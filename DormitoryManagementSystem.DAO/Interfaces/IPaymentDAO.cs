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


        // Mới lấy danh sách chưa thanh toán của sinh viên đó
        Task<IEnumerable<Payment>> GetUnpaidPaymentsByContractIDAsync(string contractId);
        Task<IEnumerable<Payment>> GetPaymentsByStudentAndStatusAsync(string studentId, string status);

    }
}
