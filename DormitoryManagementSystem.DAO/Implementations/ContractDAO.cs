using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Contracts;
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




        // ADMIN Thêm lọc theo mã và tên SV
        public async Task<IEnumerable<Contract>> GetContractsByFilterAsync(string SearchTerm)
        {
            var query = _context.Contracts
                                .AsNoTracking()
                                .Include(c => c.Student) 
                                .Include(c => c.Room) 
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {

                query = query.Where(c =>
                    c.Contractid.ToLower().Contains(SearchTerm) || // Tìm theo Mã hợp đồng
                    c.Student.Fullname.ToLower().Contains(SearchTerm) || // Tìm theo Tên SV
                    c.Student.Studentid.ToLower().Contains(SearchTerm)   // Tìm theo Mã SV
                );
            }


            return await query
                        .OrderByDescending(c => c.Createddate)
                        .ToListAsync();
        }

        // Lọc theo tòa nhà, trạng thái ngày bất đầu và kết thúc
        

        public async Task<IEnumerable<Contract>> GetContractsByMultiConditionAsync(ContractFilterDTO filter)
        {
            var query = _context.Contracts
                                .AsNoTracking()
                                .Include(c => c.Student) 
                                .Include(c => c.Room)    //  Để lọc theo Tòa nhà
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.BuildingID) && filter.BuildingID != "All")
            {
                query = query.Where(c => c.Room.Buildingid == filter.BuildingID);
            }

            if (!string.IsNullOrWhiteSpace(filter.Status) && filter.Status != "All")
            {
                query = query.Where(c => c.Status == filter.Status);
            }

            if (filter.FromDate.HasValue)
            {
                var fromDate = filter.FromDate.Value;
                query = query.Where(c => c.Starttime >= fromDate);
            }

            if (filter.ToDate.HasValue)
            {
                var toDate = filter.ToDate.Value;
                query = query.Where(c => c.Endtime <= toDate);
            }
            return await query
                        .OrderByDescending(c => c.Createddate)
                        .ToListAsync();
        }

    }
}
