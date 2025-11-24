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
        public async Task<ActionResult<IEnumerable<ViolationReadDTO>>> GetViolations(
            [FromQuery] string? status,
            [FromQuery] string? search)
        {
            var violations = (await _violationBUS.GetAllViolationsAsync()).ToList();

            if (!string.IsNullOrWhiteSpace(status) && !status.StartsWith("tất cả", StringComparison.OrdinalIgnoreCase))
            {
                violations = violations
                    .Where(v => MatchesStatus(v.Status, status))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                violations = violations
                    .Where(v =>
                        (v.StudentID ?? string.Empty).Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        (v.StudentName ?? string.Empty).Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        v.RoomID.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        v.ViolationType.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(violations
                .OrderByDescending(v => v.ViolationDate));
        }

        [HttpPost]
        public async Task<IActionResult> CreateViolation([FromBody] ViolationCreateDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Violation data is required" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var violationId = await _violationBUS.AddViolationAsync(dto);
                return CreatedAtAction(nameof(GetViolations), new { id = violationId }, new { id = violationId, message = "Violation created successfully" });
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
                return StatusCode(500, new { message = $"Error creating violation: {ex.Message}" });
            }
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

