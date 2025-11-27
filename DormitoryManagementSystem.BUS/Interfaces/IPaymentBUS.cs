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



        //Mới add thêm
        Task<IEnumerable<PaymentListDTO>> GetPendingBillsByStudentAsync(string studentId);
        Task<IEnumerable<PaymentListDTO>> GetPaymentHistoryByStudentAsync(string studentId);

        Task<IEnumerable<PaymentReadDTO>> GetMyPaymentsByStatusAsync(string studentId, string status);



    }
}