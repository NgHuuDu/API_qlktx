using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentBUS _paymentBUS;

    public PaymentController(IPaymentBUS paymentBUS)
    {
        _paymentBUS = paymentBUS;
    }


    //Student
    //API: Lấy danh sách CẦN THANH TOÁN (cho bảng trên)
    // GET: api/payment/student/pending
    [HttpGet("student/pending")]
    //[Authorize(Roles = "Student")]// tắt cái này đi mới test được 
    public async Task<IActionResult> GetMyPendingBills()
    {
        try
        {
            //var studentId = User.FindFirst("StudentID")?.Value; // Lấy từ Token
            var studentId = "STU001"; // Dùng này để test

            if (string.IsNullOrEmpty(studentId)) return Unauthorized();

            var bills = await _paymentBUS.GetPendingBillsByStudentAsync(studentId);
            return Ok(bills);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    //Student
    //  API: Lấy LỊCH SỬ THANH TOÁN (Cho bảng bên dưới)
    // GET: api/payment/student/history
    [HttpGet("student/history")]
    //[Authorize(Roles = "Student")] // Tắt này mới test được
    public async Task<IActionResult> GetMyPaymentHistory()
    {
        try
        {
            //var studentId = User.FindFirst("StudentID")?.Value; // tắt cái này đi mới test được
            var studentId = "STU001"; 

            if (string.IsNullOrEmpty(studentId)) return Unauthorized();

            var history = await _paymentBUS.GetPaymentHistoryByStudentAsync(studentId);
            return Ok(history);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }


    [HttpGet("student/filter/{status}")]
    // [Authorize(Roles = "Student")]
    public async Task<IActionResult> GetMyPaymentsByStatus(string status)
    {
        try
        {
            // 1. Lấy ID từ Token
            // var studentId = User.FindFirst("StudentID")?.Value;
            var studentId = "STU001"; // Hardcode test

            if (string.IsNullOrEmpty(studentId))
                return Unauthorized(new { message = "Không tìm thấy thông tin sinh viên." });

            // 2. Gọi BUS
            var result = await _paymentBUS.GetMyPaymentsByStatusAsync(studentId, status);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}