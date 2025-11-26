using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class ViolationDAO : IViolationDAO
    {
        private readonly PostgreDbContext _context;

        public ViolationDAO(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Violation>> GetAllViolationsAsync()
        {
            return await _context.Violations.AsNoTracking().ToListAsync();
        }

        public async Task<Violation?> GetViolationByIdAsync(string id)
        {
            return await _context.Violations.FindAsync(id);
        }

        public async Task<IEnumerable<Violation>> GetViolationsByStudentIDAsync(string studentID)
        {
            return await _context.Violations.AsNoTracking()
                                            .Where(v => v.Studentid == studentID)
                                            .OrderByDescending(v => v.Violationdate)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<Violation>> GetViolationsByStatusAsync(string status)
        {
            return await _context.Violations.AsNoTracking()
                                            .Where(v => v.Status == status)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<Violation>> GetViolationsByRoomIDAsync(string roomID)
        {
            return await _context.Violations.AsNoTracking()
                                            .Where(v => v.Roomid == roomID)
                                            .ToListAsync();
        }

        public async Task AddNewViolationAsync(Violation violation)
        {
            await _context.Violations.AddAsync(violation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateViolationAsync(Violation violation)
        {
            _context.Violations.Update(violation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteViolationAsync(string id)
        {
            Violation? v = await _context.Violations.FindAsync(id);
            if (v == null) return;

            _context.Violations.Remove(v);
            await _context.SaveChangesAsync();
        }



        // Mới
        // Hiện thông tin đây đủ của Violation, bao gồm cả tên phòng
        public async Task<IEnumerable<Violation>> GetMyViolations(string studentId)
        {

            return await _context.Violations
                .AsNoTracking()
                .Include(v => v.Room)
                .Where(v => v.Studentid == studentId)
                .OrderByDescending(v => v.Violationdate) 
                .ToListAsync();
        }
    }
}