using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Contracts;
using DormitoryManagementSystem.DTO.Rooms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractBUS _contractBUS;
        private readonly IRoomBUS _roomBUS;

        public ContractsController(IContractBUS contractBUS, IRoomBUS roomBUS)
        {
            _contractBUS = contractBUS;
            _roomBUS = roomBUS;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractResponse>>> GetContracts(
            [FromQuery] string? status,
            [FromQuery] string? search)
        {
            var contracts = (await _contractBUS.GetAllContractsAsync()).ToList();

            if (!string.IsNullOrWhiteSpace(status) && !status.StartsWith("tất cả", StringComparison.OrdinalIgnoreCase))
            {
                contracts = contracts
                    .Where(c => MatchesStatus(c.Status, status))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                contracts = contracts
                    .Where(c =>
                        c.StudentID.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        c.StudentName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        c.RoomNumber.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(contracts
                .OrderByDescending(c => c.CreatedDate)
                .Select(MapContract));
        }

        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<PendingContractResponse>>> GetPendingContracts([FromQuery] string? search)
        {
            var contracts = (await _contractBUS.GetAllContractsAsync())
                .Where(c => IsPendingStatus(c.Status))
                .ToList();
            var rooms = (await _roomBUS.GetAllRoomsAsync())
                .ToDictionary(r => r.RoomID, StringComparer.OrdinalIgnoreCase);

            if (!string.IsNullOrWhiteSpace(search))
            {
                contracts = contracts
                    .Where(c =>
                        c.StudentID.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        c.StudentName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        c.RoomNumber.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(contracts
                .OrderBy(c => c.CreatedDate)
                .Select(c => MapPendingContract(c, rooms)));
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveContract(string id)
        {
            var success = await UpdateContractStatus(id, "Active");
            return success ? Ok() : NotFound();
        }

        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectContract(string id)
        {
            var success = await UpdateContractStatus(id, "Terminated");
            return success ? Ok() : NotFound();
        }

        private async Task<bool> UpdateContractStatus(string contractId, string newStatus)
        {
            if (string.IsNullOrWhiteSpace(contractId))
                return false;

            var contract = await _contractBUS.GetContractByIDAsync(contractId);
            if (contract == null)
                return false;

            var updateDto = new ContractUpdateDTO
            {
                RoomID = contract.RoomID,
                StartTime = contract.StartTime,
                EndTime = contract.EndTime,
                Status = newStatus
            };

            await _contractBUS.UpdateContractAsync(contractId, updateDto);
            return true;
        }

        private static ContractResponse MapContract(ContractReadDTO dto) => new()
        {
            ContractId = dto.ContractID,
            StudentId = dto.StudentID,
            StudentName = dto.StudentName,
            RoomNumber = dto.RoomNumber,
            StartDate = dto.StartTime.ToDateTime(TimeOnly.MinValue),
            EndDate = dto.EndTime.ToDateTime(TimeOnly.MinValue),
            Status = dto.Status
        };

        private static PendingContractResponse MapPendingContract(
            ContractReadDTO dto,
            IReadOnlyDictionary<string, RoomReadDTO> rooms)
        {
            rooms.TryGetValue(dto.RoomID, out var room);

            return new PendingContractResponse
            {
                ContractId = dto.ContractID,
                StudentCode = dto.StudentID,
                StudentName = dto.StudentName,
                RoomNumber = dto.RoomNumber,
                StartDate = dto.StartTime.ToDateTime(TimeOnly.MinValue),
                EndDate = dto.EndTime.ToDateTime(TimeOnly.MinValue),
                MonthlyFee = room?.Price ?? 0,
                SubmittedAt = dto.CreatedDate
            };
        }

        private static bool MatchesStatus(string status, string filter)
        {
            if (filter.Equals("còn hạn", StringComparison.OrdinalIgnoreCase))
                return status.Equals("Active", StringComparison.OrdinalIgnoreCase);

            if (filter.Equals("hết hạn", StringComparison.OrdinalIgnoreCase))
                return status.Equals("Expired", StringComparison.OrdinalIgnoreCase) ||
                       status.Equals("Terminated", StringComparison.OrdinalIgnoreCase);

            if (filter.Equals("chờ duyệt", StringComparison.OrdinalIgnoreCase))
                return IsPendingStatus(status);

            return status.Equals(filter, StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsPendingStatus(string status) =>
            status.Equals("Pending", StringComparison.OrdinalIgnoreCase) ||
            status.Equals("AwaitingApproval", StringComparison.OrdinalIgnoreCase);
    }
}

