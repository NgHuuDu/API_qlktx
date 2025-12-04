using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using DormitoryManagementSystem.DTO.SearchCriteria;
using Microsoft.EntityFrameworkCore;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class StudentDAO : IStudentDAO
    {
        private readonly PostgreDbContext _context;
        public StudentDAO(PostgreDbContext context) => _context = context;

        public async Task<Student?> GetStudentByIDAsync(string id) => await _context.Students.FindAsync(id);
        public async Task<Student?> GetStudentByEmailAsync(string email) => await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Email == email);
        public async Task<Student?> GetStudentByCCCDAsync(string cccd) => await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Idcard == cccd);
        public async Task<Student?> GetStudentByUserIDAsync(string userId) => await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Userid == userId);

        public async Task AddStudentAsync(Student student) { await _context.Students.AddAsync(student); await _context.SaveChangesAsync(); }
        public async Task UpdateStudentAsync(Student student) { _context.Students.Update(student); await _context.SaveChangesAsync(); }

        public async Task<IEnumerable<Student>> SearchStudentsAsync(StudentSearchCriteria criteria)
        {
            var query = _context.Students.AsNoTracking()
                .Include(s => s.User)
                .Include(s => s.Contracts)
                .AsQueryable();

            if (criteria.IsActive.HasValue)
                query = query.Where(s => s.User.IsActive == criteria.IsActive.Value);
            else
                query = query.Where(s => s.User.IsActive == true);

            if (!string.IsNullOrEmpty(criteria.Gender) && criteria.Gender != "All")
                query = query.Where(s => s.Gender == criteria.Gender);

            if (!string.IsNullOrEmpty(criteria.Major))
                query = query.Where(s => s.Major.Contains(criteria.Major));

            if (!string.IsNullOrEmpty(criteria.RoomID))
            {
                query = query.Where(s => s.Contracts.Any(c => c.Roomid == criteria.RoomID && c.Status == "Active"));
            }

       
            if (!string.IsNullOrWhiteSpace(criteria.Keyword))
            {
                string key = criteria.Keyword.ToLower().Trim();
                query = query.Where(s => s.Fullname.ToLower().Contains(key) ||
                                         s.Studentid.ToLower().Contains(key) ||
                                         s.Phonenumber.Contains(key) ||
                                         s.Idcard.Contains(key));
            }

            return await query.OrderBy(s => s.Studentid).ToListAsync();
        }
    }
}