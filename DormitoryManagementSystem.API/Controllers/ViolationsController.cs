using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Rooms;
using DormitoryManagementSystem.DTO.Violations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolationsController : ControllerBase
    {
        private readonly IViolationBUS _violationBUS;
        private readonly IRoomBUS _roomBUS;

        public ViolationsController(IViolationBUS violationBUS, IRoomBUS roomBUS)
        {
            _violationBUS = violationBUS;
            _roomBUS = roomBUS;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViolationResponse>>> GetViolations(
            [FromQuery] string? status,
            [FromQuery] string? search)
        {
            var violations = await _violationBUS.GetAllViolationsAsync();
            var rooms = (await _roomBUS.GetAllRoomsAsync())
                .ToDictionary(r => r.RoomID, StringComparer.OrdinalIgnoreCase);

            IEnumerable<ViolationReadDTO> query = violations;

            if (!string.IsNullOrWhiteSpace(status) && !status.StartsWith("tất cả", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(v => MatchesStatus(v.Status, status));
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(v =>
                    (v.StudentID ?? string.Empty).Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    (v.StudentName ?? string.Empty).Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    GetRoomNumber(v.RoomID, rooms).Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    v.ViolationType.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(query
                .OrderByDescending(v => v.ViolationDate)
                .Select(v => MapViolation(v, rooms)));
        }

        [HttpGet("kpis")]
        public async Task<ActionResult<ViolationKpiResponse>> GetViolationKpis()
        {
            var violations = await _violationBUS.GetAllViolationsAsync();

            var unprocessed = violations.Count(v => !IsProcessed(v.Status));
            var processed = violations.Count(v => IsProcessed(v.Status));
            var serious = violations.Count(v =>
                v.ViolationType.Contains("nghiêm", StringComparison.OrdinalIgnoreCase) ||
                v.PenaltyFee >= 500000);

            return Ok(new ViolationKpiResponse
            {
                UnprocessedCount = unprocessed,
                ProcessedCount = processed,
                SeriousCount = serious
            });
        }

        private static ViolationResponse MapViolation(
            ViolationReadDTO dto,
            IReadOnlyDictionary<string, RoomReadDTO> rooms) => new()
        {
            ViolationId = dto.ViolationID,
            StudentId = dto.StudentID ?? string.Empty,
            StudentName = dto.StudentName ?? dto.StudentID ?? string.Empty,
            RoomNumber = GetRoomNumber(dto.RoomID, rooms),
            ViolationType = dto.ViolationType,
            ReportDate = dto.ViolationDate,
            Status = dto.Status
        };

        private static string GetRoomNumber(string roomId, IReadOnlyDictionary<string, RoomReadDTO> rooms)
        {
            return rooms.TryGetValue(roomId, out var room)
                ? room.RoomNumber.ToString()
                : roomId;
        }

        private static bool MatchesStatus(string status, string filter)
        {
            if (filter.Equals("chưa xử lý", StringComparison.OrdinalIgnoreCase))
                return !IsProcessed(status);

            if (filter.Equals("đã xử lý", StringComparison.OrdinalIgnoreCase))
                return IsProcessed(status);

            return status.Equals(filter, StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsProcessed(string status) =>
            status.Equals("Closed", StringComparison.OrdinalIgnoreCase) ||
            status.Equals("Resolved", StringComparison.OrdinalIgnoreCase) ||
            status.Equals("Processed", StringComparison.OrdinalIgnoreCase);
    }
}

