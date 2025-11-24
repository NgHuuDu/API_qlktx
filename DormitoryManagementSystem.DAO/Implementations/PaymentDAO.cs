
using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dormitory.DAO.Implementations
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
        
    }
}
