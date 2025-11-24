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
        public async Task<ActionResult<IEnumerable<PaymentResponse>>> GetPayments(
            [FromQuery] string? status,
            [FromQuery] string? search)
        {
            var payments = await LoadPaymentsAsync();

            if (!string.IsNullOrWhiteSpace(status) && !status.StartsWith("tất cả", StringComparison.OrdinalIgnoreCase))
            {
                payments = payments
                    .Where(p => MatchesStatus(p.Status, status))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                payments = payments
                    .Where(p =>
                        p.BillCode.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        p.StudentId.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        p.StudentName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        p.RoomNumber.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(payments
                .OrderByDescending(p => p.Year)
                .ThenByDescending(p => p.Month)
                .ThenByDescending(p => p.PaymentDate ?? DateTime.MinValue));
        }

        [HttpGet("kpis")]
        public async Task<ActionResult<PaymentKpiResponse>> GetPaymentKpis()
        {
            var payments = await LoadPaymentsAsync();

            var collected = payments.Where(p => p.Status.Equals("Paid", StringComparison.OrdinalIgnoreCase));
            var pending = payments.Where(p => p.Status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase));
            var overdue = payments.Where(p => IsOverdue(p.Status));

            var response = new PaymentKpiResponse
            {
                CollectedAmount = collected.Sum(p => p.TotalAmount),
                CollectedCount = collected.Count(),
                PendingAmount = pending.Sum(p => p.TotalAmount),
                PendingCount = pending.Count(),
                OverdueAmount = overdue.Sum(p => p.TotalAmount),
                OverdueCount = overdue.Count()
            };

            return Ok(response);
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

        private async Task<List<PaymentResponse>> LoadPaymentsAsync()
        {
            // Chạy tuần tự để tránh concurrent access trên cùng DbContext instance
            var payments = await _paymentBUS.GetAllPaymentsAsync();
            var contracts = await _contractBUS.GetAllContractsAsync();

            var contractLookup = contracts.ToDictionary(c => c.ContractID, c => c);

            return payments
                .Select(p =>
                {
                    contractLookup.TryGetValue(p.ContractID, out var contract);
                    return MapPayment(p, contract);
                })
                .ToList();
        }

        private static PaymentResponse MapPayment(PaymentReadDTO payment, ContractReadDTO? contract) => new()
        {
            Id = payment.PaymentID,
            BillCode = payment.PaymentID,
            StudentId = contract?.StudentID ?? string.Empty,
            StudentName = contract?.StudentName ?? contract?.StudentID ?? string.Empty,
            RoomNumber = contract?.RoomNumber ?? string.Empty,
            Month = payment.BillMonth,
            Year = payment.PaymentDate.Year,
            TotalAmount = payment.PaymentAmount,
            PaidAmount = payment.PaidAmount,
            PaymentDate = payment.PaymentStatus.Equals("Unpaid", StringComparison.OrdinalIgnoreCase)
                ? null
                : payment.PaymentDate,
            Status = payment.PaymentStatus
        };

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

