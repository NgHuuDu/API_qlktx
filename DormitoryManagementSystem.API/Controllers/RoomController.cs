using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Rooms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomBUS _roomBUS;

        public RoomController(IRoomBUS roomBUS)
        {
            _roomBUS = roomBUS;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? building,
            [FromQuery] string? status,
            [FromQuery] string? search)
        {
            var rooms = (await _roomBUS.GetAllRoomsAsync()).ToList();

            if (!string.IsNullOrWhiteSpace(building))
            {
                rooms = rooms
                    .Where(r => r.BuildingID.Contains(building, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                rooms = rooms.Where(r => r.Status.Contains(status, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                rooms = rooms
                    .Where(r =>
                        r.RoomNumber.ToString().Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        r.BuildingID.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var room = await _roomBUS.GetRoomByIDAsync(id);
            if (room == null) return NotFound();
            return Ok(room);
        }
    }
}

