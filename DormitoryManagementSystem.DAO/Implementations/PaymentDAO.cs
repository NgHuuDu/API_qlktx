
using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Payments;
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




        // Sinh viên: Xem danh sách hóa đơn (Tất cả / Đã trả / Nợ) theo trạng thái á
        public async Task<IEnumerable<Payment>> GetPaymentsByStudentAndStatusAsync(string studentId, string? status)
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

            return await query
                .OrderByDescending(p => p.Billmonth)
                .ThenByDescending(p => p.Paymentdate)
                .ToListAsync();
        }

        // Admin: Lấy danh sách thanh toán với các bộ lọc
        public async Task<IEnumerable<Payment>> GetPaymentsForAdminAsync(
            int? month,
            string? status,
            string? building,
            string? searchKeyword) // Tìm theo Tên hoặc MSSV
        {

            var query = _context.Payments
                .AsNoTracking()
                .Include(p => p.Contract)
                    .ThenInclude(c => c.Student) 
                .Include(p => p.Contract)
                    .ThenInclude(c => c.Room)  
                .AsQueryable();

            // Lọc theo Tháng
            if (month.HasValue && month > 0)
                query = query.Where(p => p.Billmonth == month.Value);

         
            // Lọc theo Trạng thái
            if (!string.IsNullOrEmpty(status) && status != "All")
                query = query.Where(p => p.Paymentstatus == status);

            if (!string.IsNullOrEmpty(building) && building != "All")
            {
                // Đi từ Payment -> Contract -> Room -> Buildingid
                query = query.Where(p => p.Contract.Room.Buildingid == building);
            }

            // Tìm kiếm (MSSV hoặc Tên)
            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                string key = searchKeyword.ToLower().Trim();
                query = query.Where(p => p.Contract.Student.Fullname.ToLower().Contains(key)
                                      || p.Contract.Studentid.ToLower().Contains(key));
            }

            // Sắp xếp: Mới nhất lên đầu
            return await query.OrderByDescending(p => p.Billmonth).ToListAsync();
        }


        // Admin: Thống kê số liệu thanh toán
        // Cái này nên chuyển về DTO chứ không phải entity Payment
        
       
    }
}
