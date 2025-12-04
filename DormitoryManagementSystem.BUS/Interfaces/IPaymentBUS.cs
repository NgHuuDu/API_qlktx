using DormitoryManagementSystem.DTO.Payments;

namespace DormitoryManagementSystem.BUS.Interfaces
{
    public interface IPaymentBUS
    {
        Task<IEnumerable<PaymentReadDTO>> GetAllPaymentsAsync();
        Task<PaymentReadDTO?> GetPaymentByIDAsync(string id);

        Task<IEnumerable<PaymentReadDTO>> GetPaymentsByContractIDAsync(string contractId);
        Task<IEnumerable<PaymentReadDTO>> GetPaymentsByStatusAsync(string status);

        Task<string> AddPaymentAsync(PaymentCreateDTO dto);
        Task UpdatePaymentAsync(string id, PaymentUpdateDTO dto);
        Task DeletePaymentAsync(string id);

        Task ConfirmPaymentAsync(string id, PaymentConfirmDTO dto);
        Task<int> GenerateMonthlyBillsAsync(int month, int year);

        Task<IEnumerable<PaymentListDTO>> GetPaymentsByStudentAndStatusAsync(string studentId, string? status);
        Task<IEnumerable<PaymentAdminDTO>> GetPaymentsForAdminAsync(int? month, string? status, string? building, string? search);
    }
}