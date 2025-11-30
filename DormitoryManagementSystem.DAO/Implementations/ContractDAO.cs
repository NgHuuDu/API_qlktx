using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class ContractDAO : IContractDAO
    {
        private readonly PostgreDbContext _context;

        public ContractDAO(PostgreDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Contract>> GetAllContractsAsync()
        {
            return await _context.Contracts.AsNoTracking()
                                           .Where(contract => contract.Status != "Terminated")
                                           .ToListAsync();
        }

        public async Task<IEnumerable<Contract>> GetAllContractsIncludingInactivesAsync()
        {
            return await _context.Contracts.AsNoTracking().ToListAsync();
        }

        public async Task<Contract?> GetContractByIDAsync(string id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task AddContractAsync(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContractAsync(Contract contract)
        {
            _context.Contracts.Update(contract);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContractAsync(string id)
        {
            Contract? c = await _context.Contracts.FindAsync(id);

            if (c == null) return;

            c.Status = "Terminated";

            _context.Contracts.Update(c);
            await _context.SaveChangesAsync();
        }




        public async Task<IEnumerable<Contract>> GetContractsByStudentIDAsync(string studentID)
        {
            return await _context.Contracts.AsNoTracking()
                                           .Where(contract => contract.Studentid == studentID)
                                           .ToListAsync();
        }

        public async Task<Contract?> GetActiveContractByStudentIDAsync(string studentID)
        {
            return await _context.Contracts.AsNoTracking()
                                           .Where(contract => contract.Studentid == studentID)
                                           .Where(contract => contract.Status == "Active")
                                           .FirstOrDefaultAsync();
        }






        //Mới thêm - Lấy chi tiết hợp đồng bao gồm thông tin Sinh viên, Phòng và Tòa nhà
        // Cho thằng SINH VIÊN xem hợp đồng của nó
        public async Task<Contract?> GetContractDetailAsync(string studentId)
        {

            return await _context.Contracts
                .AsNoTracking()
                .Include(c => c.Student)              
                .Include(c => c.Room)                  
                    .ThenInclude(r => r.Building)      
                .Where(c => c.Studentid == studentId)  
                .Where(c => c.Status == "Active")     
                .FirstOrDefaultAsync();
        }
    }
}
