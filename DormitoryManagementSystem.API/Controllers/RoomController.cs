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

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomCreateDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Room data is required" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var roomId = await _roomBUS.AddRoomAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = roomId }, new { id = roomId, message = "Room created successfully" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error creating room: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(string id, [FromBody] RoomUpdateDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Room data is required" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _roomBUS.UpdateRoomAsync(id, dto);
                return Ok(new { message = "Room updated successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error updating room: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(string id)
        {
            try
            {
                await _roomBUS.DeleteRoomAsync(id);
                return Ok(new { message = "Room deleted successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error deleting room: {ex.Message}" });
            }
        }
    }
}

