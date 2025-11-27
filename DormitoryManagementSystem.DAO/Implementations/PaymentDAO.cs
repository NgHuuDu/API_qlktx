
using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class PaymentDAO : IPaymentDAO
    {
        private readonly PostgreDbContext _context;

        public PaymentDAO(PostgreDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByContractIDAsync(string contractID)
        {
            return await _context.Payments.AsNoTracking()
                                          .Where(payment => payment.Contractid == contractID)
                                          .OrderByDescending(payment => payment.Paymentdate)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByStatusAsync(string status)
        {
            return await _context.Payments.AsNoTracking()
                                          .Where(payment => payment.Paymentstatus == status)
                                          .ToListAsync();
        }

        public async Task<Payment?> GetPaymentByIDAsync(string id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task RemovePaymentAsync(string id)
        {
            Payment? p = await _context.Payments.FindAsync(id);

            if (p == null) return;
            _context.Payments.Remove(p);

            await _context.SaveChangesAsync();
        }



        // Mới lấy danh sách chưa thanh toán của sinh viên đó
        public async Task<IEnumerable<Payment>> GetUnpaidPaymentsByContractIDAsync(string contractId)
        {

            return await _context.Payments
                .AsNoTracking()
                .Where(p => p.Contractid == contractId)
                .Where(p => p.Paymentstatus == "Unpaid" || p.Paymentstatus == "Late")
                .OrderBy(p => p.Billmonth) 
                .ToListAsync();
        }
        // Mới lấy danh sách thanh toán của sinh viên đó theo trạng thái
        public async Task<IEnumerable<Payment>> GetPaymentsByStudentAndStatusAsync(string studentId, string status)
        {

            var query = _context.Payments
                .AsNoTracking()
                .Include(p => p.Contract)
                .Where(p => p.Contract.Studentid == studentId) 
                .AsQueryable();

            if (!string.IsNullOrEmpty(status) && status.ToLower() != "all")
            {
                if (status == "Pending" || status == "Unpaid")
                {
                    query = query.Where(p => p.Paymentstatus == "Unpaid" || p.Paymentstatus == "Late");
                }
                else if (status == "Paid")
                {
                    query = query.Where(p => p.Paymentstatus == "Paid");
                }
                else
                {
                    query = query.Where(p => p.Paymentstatus == status);
                }
            }

            return await query.OrderByDescending(p => p.Billmonth)
                              .ThenByDescending(p => p.Paymentdate)
                              .ToListAsync();
        }

    }
}
