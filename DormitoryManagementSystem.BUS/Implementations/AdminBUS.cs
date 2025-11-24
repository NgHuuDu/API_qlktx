using AutoMapper;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Admins;
using DormitoryManagementSystem.Entity;

namespace DormitoryManagementSystem.BUS.Implementations
{
    public class AdminBUS : IAdminBUS
    {
        private readonly IAdminDAO _adminDAO;
        private readonly IUserDAO _userDAO;
        private readonly IMapper _mapper;

        public AdminBUS(IAdminDAO adminDAO, IUserDAO userDAO, IMapper mapper)
        {
            this._adminDAO = adminDAO;
            this._userDAO = userDAO;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<AdminReadDTO>> GetAllAdminsAsync()
        {
            IEnumerable<Admin> admins = await this._adminDAO.GetAllAdminsAsync();
            return this._mapper.Map<IEnumerable<AdminReadDTO>>(admins);
        }

        public async Task<IEnumerable<AdminReadDTO>> GetAllAdminsIncludingInactivesAsync()
        {
            IEnumerable<Admin> admins = await this._adminDAO.GetAllAdminsIncludingInactivesAsync();
            return this._mapper.Map<IEnumerable<AdminReadDTO>>(admins);
        }

        public async Task<AdminReadDTO?> GetAdminByIDAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Admin id can not be empty.");

            Admin? ad = await this._adminDAO.GetAdminByIDAsync(id);
            if (ad == null) return null;

            return this._mapper.Map<AdminReadDTO>(ad);
        }

        public async Task<AdminReadDTO?> GetAdminByUserIDAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("user id can not be empty.");

            Admin? ad = await this._adminDAO.GetAdminByUserIDAsync(userId);
            if (ad == null) return null;

            return this._mapper.Map<AdminReadDTO>(ad);
        }

        public async Task<string> AddAdminAsync(AdminCreateDTO dto)
        {
            Admin? existing = await this._adminDAO.GetAdminByIDAsync(dto.AdminID);
            if (existing != null)
                throw new InvalidOperationException($"Admin with ID {dto.AdminID} already exists.");

            Admin? existingCCCD = await this._adminDAO.GetAdminByCCCDAsync(dto.IDcard);
            if (existingCCCD != null)
                throw new InvalidOperationException($"Admin with CCCD {dto.IDcard} already exists.");

            User? user = await this._userDAO.GetUserByIDAsync(dto.UserID);
            if (user == null) 
                throw new KeyNotFoundException($"User with ID {dto.UserID} does not exist. Please create the User account first.");

            if (user.Role != "Admin")
                throw new InvalidOperationException($"User {dto.UserID} has role '{user.Role}'. Cannot assign Admin profile.");

            Admin? existingProfile = await this._adminDAO.GetAdminByUserIDAsync(dto.UserID);
            if (existingProfile != null)
                throw new InvalidOperationException($"User {dto.UserID} is already linked to Admin Profile {existingProfile.Adminid}.");

            Admin ad = this._mapper.Map<Admin>(dto);
            await this._adminDAO.AddAdminAsync(ad);

            return ad.Adminid;
        }

        public async Task UpdateAdminAsync(string id, AdminUpdateDTO dto)
        {
            Admin? currentAdmin = await _adminDAO.GetAdminByIDAsync(id);
            if (currentAdmin == null)
                throw new KeyNotFoundException($"Admin with ID {id} not found.");

            if (currentAdmin.Idcard != dto.IDcard)
            {
                Admin? existingCCCD = await this._adminDAO.GetAdminByCCCDAsync(dto.IDcard);
                if (existingCCCD != null)
                    throw new InvalidOperationException($"Admin with CCCD {dto.IDcard} already exists.");
            }

            _mapper.Map(dto, currentAdmin);
            currentAdmin.Adminid = id;

            await _adminDAO.UpdateAdminAsync(currentAdmin);
        }

        public async Task DeleteAdminAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Admin ID cannot be empty.");

            Admin? existing = await _adminDAO.GetAdminByIDAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Admin with ID {id} not found.");

            // SOFT DELETE USER
            // Gọi UserDAO để set IsActive = false cho UserID tương ứng
            await _userDAO.DeleteUserAsync(existing.Userid);
        }
    }
}
