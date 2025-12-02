using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class StudentDAO : IStudentDAO
    {
        private readonly PostgreDbContext _context;

        public StudentDAO(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                                 .AsNoTracking()
                                 .Include(s => s.User)
                                 .Where(s => s.User.IsActive == true)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsIncludingInactivesAsync()
        {
            return await _context.Students
                                 .AsNoTracking()
                                 .Include(s => s.User)
                                 .ToListAsync();
        }

        public async Task<Student?> GetStudentByIDAsync(string id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student?> GetStudentByEmailAsync(string email)
        {
            return await _context.Students
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Student?> GetStudentByCCCDAsync(string cccd)
        {
            return await _context.Students
                                .AsNoTracking()
                                .FirstOrDefaultAsync(s => s.Idcard == cccd);
        }

        public async Task<Student?> GetStudentByUserIDAsync(string userId)
        {
            return await _context.Students
                                .AsNoTracking()
                                .FirstOrDefaultAsync(s => s.Userid == userId);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        //public async Task DeleteStudentAsync(string id)
        //{
        //    Student? s = await _context.Students.FindAsync(id);
        //    if (s == null) return;

        //    _context.Students.Remove(s);
        //    await _context.SaveChangesAsync();
        //}
    }
}