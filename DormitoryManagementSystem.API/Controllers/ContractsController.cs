using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Contracts;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractBUS _contractBUS;
        public ContractController(IContractBUS contractBUS) => _contractBUS = contractBUS;

        [HttpGet("student/my-contracts")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMyContracts()
        {
            var studentId = User.FindFirst("StudentID")?.Value;
            if (string.IsNullOrEmpty(studentId)) throw new UnauthorizedAccessException("Không xác định được sinh viên.");

            var contracts = await _contractBUS.GetContractFullDetailAsync(studentId);
            return Ok(contracts); // Nếu null trả về null hoặc xử lý ở FE
        }

        [HttpPost("student/contracts")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> RegisterContract([FromBody] ContractRegisterDTO dto)
        {
            var studentId = User.FindFirst("StudentID")?.Value;
            if (string.IsNullOrEmpty(studentId)) throw new UnauthorizedAccessException("Không xác định được sinh viên.");

            var contractId = await _contractBUS.RegisterContractAsync(studentId, dto);
            return Ok(new { message = "Gửi đơn đăng ký thành công!", contractId });
        }

        [HttpGet("admin/contracts")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetContracts([FromQuery] string? searchTerm)
        {
            var result = await _contractBUS.GetContractsAsync(searchTerm);
            return Ok(result);
        }

        [HttpGet("admin/contracts/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetContractById(string id)
        {
            var contract = await _contractBUS.GetContractByIDAsync(id);
            if (contract == null) throw new KeyNotFoundException("Không tìm thấy hợp đồng.");
            return Ok(contract);
        }

        [HttpPut("admin/contracts/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateContract(string id, [FromBody] ContractUpdateDTO dto)
        {
            await _contractBUS.UpdateContractAsync(id, dto);
            return Ok(new { message = "Cập nhật hợp đồng thành công!" });
        }

        [HttpDelete("admin/contracts/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteContract(string id)
        {
            await _contractBUS.DeleteContractAsync(id);
            return Ok(new { message = "Xóa hợp đồng thành công!" });
        }

        [HttpGet("admin/contracts/filter")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetContractsByMultiCondition([FromQuery] ContractFilterDTO filter)
        {
            var result = await _contractBUS.GetContractsByMultiConditionAsync(filter);
            return Ok(result);
        }
    }
}