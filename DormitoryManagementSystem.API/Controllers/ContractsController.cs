using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Contracts;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractBUS _contractBUS;

        public ContractController(IContractBUS contractBUS)
        {
            _contractBUS = contractBUS;
        }

     
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> GetAllContracts()
        {
            try
            {
                var contracts = await _contractBUS.GetAllContractsAsync();
                return Ok(contracts); // Trả về danh sách JSON (200 OK)
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }

        // API: Lấy chi tiết 1 hợp đồng (Khi bấm vào dòng trong bảng)
        // GET: api/contract/{id}
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetContractByStudentID()
        {
            //var studentId = User.FindFirst("StudentID")?.Value;
            var studentId = "STU001";
            if (string.IsNullOrEmpty(studentId))
                return Unauthorized(new { message = "Không tìm thấy thông tin sinh viên." });

            var contract = await _contractBUS.GetContractsByStudentIDAsync(studentId);
            if (contract == null) return NotFound(new { message = "Không tìm thấy hợp đồng." });
            return Ok(contract);
        }

        [HttpGet("student/{studentID}")] // URL sẽ là: api/contract/student/STU001
        //[Authorize(Roles = "Admin")] // <--- QUAN TRỌNG: Chỉ sếp mới được soi
        public async Task<IActionResult> GetContractsByStudentId(string studentID)
        {
            // Admin được quyền truyền ID bất kỳ vào để xem
            var contracts = await _contractBUS.GetContractsByStudentIDAsync(studentID);

            if (contracts == null || !contracts.Any())
                return NotFound(new { message = "Sinh viên này chưa có hợp đồng nào." });

            return Ok(contracts);
        }
    }
}