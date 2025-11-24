using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Contracts;
using DormitoryManagementSystem.DTO.Payments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentBUS _paymentBUS;
        private readonly IContractBUS _contractBUS;

        public PaymentsController(IPaymentBUS paymentBUS, IContractBUS contractBUS)
        {
            _paymentBUS = paymentBUS;
            _contractBUS = contractBUS;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentReadDTO>>> GetPayments(
            [FromQuery] string? status,
            [FromQuery] string? search)
        {
            var payments = (await _paymentBUS.GetAllPaymentsAsync()).ToList();

            if (!string.IsNullOrWhiteSpace(status) && !status.StartsWith("tất cả", StringComparison.OrdinalIgnoreCase))
            {
                payments = payments
                    .Where(p => MatchesStatus(p.PaymentStatus, status))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                payments = payments
                    .Where(p =>
                        p.PaymentID.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        p.ContractID.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(payments
                .OrderByDescending(p => p.PaymentDate.Year)
                .ThenByDescending(p => p.BillMonth)
                .ThenByDescending(p => p.PaymentDate));
        }

        [HttpGet("kpis")]
        public async Task<ActionResult<PaymentKpiResponse>> GetPaymentKpis()
        {
            var payments = (await _paymentBUS.GetAllPaymentsAsync()).ToList();

            var collected = payments.Where(p => p.PaymentStatus.Equals("Paid", StringComparison.OrdinalIgnoreCase));
            var pending = payments.Where(p => p.PaymentStatus.Equals("Unpaid", StringComparison.OrdinalIgnoreCase));
            var overdue = payments.Where(p => IsOverdue(p.PaymentStatus));

            var response = new PaymentKpiResponse
            {
                CollectedAmount = collected.Sum(p => p.PaymentAmount),
                CollectedCount = collected.Count(),
                PendingAmount = pending.Sum(p => p.PaymentAmount),
                PendingCount = pending.Count(),
                OverdueAmount = overdue.Sum(p => p.PaymentAmount),
                OverdueCount = overdue.Count()
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentCreateDTO dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Payment data is required" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var paymentId = await _paymentBUS.AddPaymentAsync(dto);
                return CreatedAtAction(nameof(GetPayments), new { id = paymentId }, new { id = paymentId, message = "Payment created successfully" });
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
                return StatusCode(500, new { message = $"Error creating payment: {ex.Message}" });
            }
        }

        [HttpPost("{id}/confirm")]
        public async Task<IActionResult> ConfirmPayment(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Invalid payment id");

            var payment = await _paymentBUS.GetPaymentByIDAsync(id);
            if (payment == null)
                return NotFound();

            var updateDto = new PaymentUpdateDTO
            {
                PaidAmount = payment.PaymentAmount,
                PaymentMethod = string.IsNullOrWhiteSpace(payment.PaymentMethod) ? "Cash" : payment.PaymentMethod,
                PaymentStatus = "Paid",
                PaymentDate = DateTime.Now,
                Description = "Confirmed via API"
            };

            await _paymentBUS.UpdatePaymentAsync(id, updateDto);
            return Ok();
        }

        private static bool MatchesStatus(string status, string filter)
        {
            if (filter.Equals("đã thanh toán", StringComparison.OrdinalIgnoreCase))
                return status.Equals("Paid", StringComparison.OrdinalIgnoreCase);

            if (filter.Equals("chờ thanh toán", StringComparison.OrdinalIgnoreCase))
                return status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase);

            if (filter.Equals("quá hạn", StringComparison.OrdinalIgnoreCase))
                return IsOverdue(status);

            return status.Equals(filter, StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsOverdue(string status) =>
            status.Equals("Late", StringComparison.OrdinalIgnoreCase);
    }
}

