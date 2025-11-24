using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;

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
    }
}