using System.Collections.Generic;
using System.Runtime.InteropServices;
using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DormitoryManagementSystem.DAO.Implementations
{
    public class RoomDAO : IRoomDAO
    {
        private readonly PostgreDbContext _context;

        public RoomDAO(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.AsNoTracking()
                                       .Where(room => room.Status != "Inactive")
                                       .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllRoomsIncludingInactivesAsync()
        {
            return await _context.Rooms.AsNoTracking().ToListAsync();
        }

        public async Task<Room?> GetRoomByIDAsync(string id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<IEnumerable<Room>> GetRoomsByBuildingIDAsync(string buildingID)
        {
            return await _context.Rooms
                                 .AsNoTracking()
                                 .Where(r => r.Status != "Inactive")
                                 .Where(r => r.Buildingid == buildingID)
                                 .ToListAsync();
        }

        public async Task AddRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(string id)
        {
            Room? room = await _context.Rooms.FindAsync(id);
            if (room == null) return;

            room.Status = "Inactive";

            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }



        // Mới thêm - Lọc phòng Student
        public async Task<IEnumerable<Room>> GetRoomsByFilterAsync(
              string? buildingId,
              int? roomNumber,
              int? capacity,
              decimal? minPrice,
              decimal? maxPrice,
              bool? allowCooking,     
              bool? airConditioner)  
        {

            var query = _context.Rooms
                .AsNoTracking()
                .Include(r => r.Building)
                .Where(r => r.Status == "Active")
                .Where(r => r.Currentoccupancy < r.Capacity)
                .AsQueryable();

            // Lọc theo Tòa nhà
            if (!string.IsNullOrEmpty(buildingId) && buildingId != "All")
            {
                query = query.Where(r => r.Buildingid == buildingId);
            }

            // Lọc theo Số phòng 
            if (roomNumber.HasValue)
            {
                query = query.Where(r => r.Roomnumber == roomNumber.Value);
            }

            //Lọc theo Sức chứa
            if (capacity.HasValue && capacity > 0)
            {
                query = query.Where(r => r.Capacity == capacity.Value);
            }

            //  Lọc theo Giá (Khoảng giá)
            if (minPrice.HasValue)
            {
                query = query.Where(r => r.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(r => r.Price <= maxPrice.Value);
            }
            //  Lọc theo Cho phép nấu ăn
            if (allowCooking.HasValue)
            {
                query = query.Where(r => r.Allowcooking == allowCooking.Value);
            }

            //  Lọc theo Máy lạnh
            if (airConditioner.HasValue)
            {
                query = query.Where(r => r.Airconditioner == airConditioner.Value);
            }

            return await query
                .OrderBy(r => r.Buildingid)
                .ThenBy(r => r.Roomnumber)
                .ToListAsync();
        }

        // Mới thêm - Lấy tất cả phòng kèm tên tòa nhà
        public async Task<IEnumerable<Room>> GetAllRoomsWithBuildingAsync()
        {

            return await _context.Rooms
                .AsNoTracking()
                .Include(r => r.Building) 
                .Where(r => r.Status == "Active") 
                .OrderBy(r => r.Buildingid)
                .ThenBy(r => r.Roomnumber)
                .ToListAsync();
        }

        // Mới thêm - Lấy chi tiết phòng bao gồm thông tin tòa nhà
        public async Task<Room?> GetRoomDetailByIDAsync(string id)
        {

            return await _context.Rooms
                .AsNoTracking() 
                .Include(r => r.Building)
                .FirstOrDefaultAsync(r => r.Roomid == id);
        }


        // Mới thêm - Lấy danh sách sức chứa phòng khác nhau
        public async Task<IEnumerable<int>> GetDistinctCapacitiesAsync()
        {

            return await _context.Rooms
                .AsNoTracking()
                .Select(r => r.Capacity)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();
        }

    }
}