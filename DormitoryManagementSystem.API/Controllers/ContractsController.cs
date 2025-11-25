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
        



        //Student
        // API: Sinh viên xem hợp đồng CỦA CHÍNH MÌNH
        // URL: GET /api/Contract/my-contracts  
        [HttpGet("my-contracts")]
        // [Authorize(Roles = "Student")] // Nhớ bật lại khi có Token
        public async Task<IActionResult> GetMyContracts()
        {
            try
            {
                var studentId = "STU002"; // Test hardcode

                if (string.IsNullOrEmpty(studentId))
                    return Unauthorized(new { message = "Không tìm thấy thông tin sinh viên." });

                var contracts = await _contractBUS.GetContractFullDetailAsync(studentId);

                if (contracts == null) contracts = null;

                return Ok(contracts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Student
        // API: Sinh viên gửi đơn đăng ký
        // POST: api/contract/register
        [HttpPost("register")]
        //[Authorize(Roles = "Student")] 
        public async Task<IActionResult> RegisterContract([FromBody] ContractRegisterDTO dto)
        {
            try
            {
               // var studentId = User.FindFirst("StudentID")?.Value;
                 var studentId = "STU001"; //test
                if (string.IsNullOrEmpty(studentId))
                    return Unauthorized(new { message = "Không xác định được sinh viên." });

                var contractId = await _contractBUS.RegisterContractAsync(studentId, dto);

                return Ok(new { message = "Gửi đơn đăng ký thành công!", contractId = contractId });
            }
            catch (InvalidOperationException ex) // Lỗi phòng đầy,...
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }



    }
}