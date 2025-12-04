using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Payments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentBUS _paymentBUS;
    public PaymentController(IPaymentBUS paymentBUS) => _paymentBUS = paymentBUS;

    [HttpGet("student/payments")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> GetMyPayments([FromQuery] string? status)
    {
        var studentId = User.FindFirst("StudentID")?.Value;
        var list = await _paymentBUS.GetPaymentsByStudentAndStatusAsync(studentId, status);
        return Ok(list);
    }

    [HttpGet("admin/payments")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAdminPaymentList(
        [FromQuery] int? month, [FromQuery] string? status,
        [FromQuery] string? building, [FromQuery] string? search)
    {
        var list = await _paymentBUS.GetPaymentsForAdminAsync(month, status, building, search);
        return Ok(list);
    }

    [HttpPut("admin/payments/{id}/confirm")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ConfirmPayment(string id, [FromBody] PaymentConfirmDTO dto)
    {
        await _paymentBUS.ConfirmPaymentAsync(id, dto);
        return Ok(new { message = "Ghi nhận thanh toán thành công!" });
    }

    [HttpDelete("admin/payments/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteBill(string id)
    {
        await _paymentBUS.DeletePaymentAsync(id);
        return Ok(new { message = "Đã xóa hóa đơn" });
    }

    [HttpPost("admin/payments/auto-generate")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GenerateBills([FromQuery] int month, [FromQuery] int year)
    {
        if (year == 0) year = DateTime.Now.Year;
        int count = await _paymentBUS.GenerateMonthlyBillsAsync(month, year);
        return Ok(new { message = $"Đã tạo thành công {count} hóa đơn tiền phòng cho tháng {month}/{year}!" });
    }
}