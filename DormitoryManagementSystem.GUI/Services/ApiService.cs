using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.DTO.Buildings;
using DormitoryManagementSystem.DTO.Contracts;
using DormitoryManagementSystem.DTO.Payments;
using DormitoryManagementSystem.DTO.Rooms;
using DormitoryManagementSystem.DTO.Violations;
using DormitoryManagementSystem.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.GUI.Services
{
    internal static class ApiService
    {
        private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            try
            {
                // Log để debug
                var baseUrl = HttpService.Client.BaseAddress?.ToString() ?? "unknown";
                System.Diagnostics.Debug.WriteLine($"[ApiService] Attempting login to: {baseUrl}api/auth/login");
                
                var response = await HttpService.Client.PostAsJsonAsync("api/auth/login", request, JsonOptions);
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = "Không thể đăng nhập";
                    try
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(errorContent))
                        {
                            // Try to parse as JSON error object
                            try
                            {
                                var errorObj = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(errorContent, JsonOptions);
                                if (errorObj != null && errorObj.ContainsKey("message"))
                                {
                                    errorMessage = errorObj["message"]?.ToString() ?? errorMessage;
                                }
                                else
                                {
                                    errorMessage = errorContent.Trim('"');
                                }
                            }
                            catch
                            {
                                errorMessage = errorContent.Trim('"');
                            }
                        }
                    }
                    catch
                    {
                        errorMessage = $"Lỗi kết nối: {response.StatusCode}";
                    }

                    return new LoginResponse
                    {
                        IsSuccess = false,
                        Message = errorMessage
                    };
                }

                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>(JsonOptions);
                if (loginResponse?.IsSuccess == true && loginResponse.User != null)
                {
                    var session = new UserSession(
                        loginResponse.User.UserId,
                        loginResponse.User.Username,
                        loginResponse.User.Role);
                    GlobalState.SetUser(session, loginResponse.Token);
                    HttpService.SetAuthorization(loginResponse.Token);
                }

                return loginResponse;
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                string detailedMessage = "Không thể kết nối đến máy chủ.";
                
                if (ex.InnerException != null)
                {
                    detailedMessage += $" {ex.InnerException.Message}";
                }
                else
                {
                    detailedMessage += $" {ex.Message}";
                }
                
                var baseUrl = HttpService.Client.BaseAddress?.ToString() ?? "unknown";
                detailedMessage += $" Vui lòng kiểm tra API đã chạy chưa và đảm bảo đúng địa chỉ ({baseUrl}).";
                System.Diagnostics.Debug.WriteLine($"[ApiService] HttpRequestException: {detailedMessage}");
                
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = detailedMessage
                };
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ApiService] SocketException: {ex.Message}");
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = $"Không thể kết nối đến máy chủ. API có thể chưa chạy hoặc địa chỉ không đúng. Chi tiết: {ex.Message}"
                };
            }
            catch (System.Threading.Tasks.TaskCanceledException ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ApiService] TaskCanceledException (Timeout): {ex.Message}");
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = "Kết nối bị timeout. Vui lòng kiểm tra API đã chạy chưa hoặc thử lại sau."
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ApiService] Exception: {ex.GetType().Name} - {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"[ApiService] StackTrace: {ex.StackTrace}");
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = $"Lỗi: {ex.GetType().Name} - {ex.Message}"
                };
            }
        }

        public static void Logout()
        {
            GlobalState.Clear();
            HttpService.SetAuthorization(null);
        }

        public static async Task<List<RoomResponse>> GetRoomsAsync(string building, string status, string search)
        {
            var query = BuildQuery(
                ("building", NormalizeFilter(building)),
                ("status", NormalizeFilter(status)),
                ("search", string.IsNullOrWhiteSpace(search) ? null : search));

            var response = await HttpService.Client.GetAsync($"api/room{query}");
            response.EnsureSuccessStatusCode();

            var rooms = await response.Content.ReadFromJsonAsync<List<RoomReadDTO>>(JsonOptions)
                ?? new List<RoomReadDTO>();

            return rooms.Select(MapRoom).ToList();
        }

        public static async Task<BuildingKpiResponse> GetBuildingKPIsAsync()
        {
            return await HttpService.Client.GetFromJsonAsync<BuildingKpiResponse>("api/dashboard/buildings", JsonOptions)
                ?? new BuildingKpiResponse();
        }

        public static async Task<List<BuildingReadDTO>> GetBuildingsAsync()
        {
            try
            {
                var buildings = await HttpService.Client.GetFromJsonAsync<List<BuildingReadDTO>>("api/buildings", JsonOptions);
                return buildings ?? new List<BuildingReadDTO>();
            }
            catch
            {
                return new List<BuildingReadDTO>();
            }
        }

        public static async Task<List<ContractResponse>> GetContractsAsync(string status, string search)
        {
            var query = BuildQuery(
                ("status", NormalizeFilter(status)),
                ("search", string.IsNullOrWhiteSpace(search) ? null : search));

            var contracts = await HttpService.Client.GetFromJsonAsync<List<ContractReadDTO>>(
                $"api/contracts{query}", JsonOptions);

            return contracts?.Select(MapContract).ToList() ?? new List<ContractResponse>();
        }

        private static ContractResponse MapContract(ContractReadDTO dto)
        {
            return new ContractResponse
            {
                ContractId = dto.ContractID,
                StudentId = dto.StudentID,
                StudentName = dto.StudentName,
                RoomNumber = dto.RoomNumber,
                StartDate = dto.StartTime.ToDateTime(TimeOnly.MinValue),
                EndDate = dto.EndTime.ToDateTime(TimeOnly.MinValue),
                Status = dto.Status
            };
        }

        public static async Task<List<PendingContractResponse>> GetPendingContractsAsync(string search)
        {
            var query = BuildQuery(("search", string.IsNullOrWhiteSpace(search) ? null : search));
            var contracts = await HttpService.Client.GetFromJsonAsync<List<ContractReadDTO>>(
                $"api/contracts/pending{query}", JsonOptions);

            if (contracts == null) return new List<PendingContractResponse>();

            // Load rooms để map MonthlyFee
            var roomsResponse = await HttpService.Client.GetFromJsonAsync<List<RoomReadDTO>>(
                "api/room", JsonOptions);
            var roomLookup = roomsResponse?.ToDictionary(r => r.RoomID, r => r.Price, StringComparer.OrdinalIgnoreCase)
                ?? new Dictionary<string, decimal>();

            return contracts.Select(c => MapPendingContract(c, roomLookup)).ToList();
        }

        private static PendingContractResponse MapPendingContract(ContractReadDTO dto, Dictionary<string, decimal> roomLookup)
        {
            roomLookup.TryGetValue(dto.RoomID, out var monthlyFee);
            return new PendingContractResponse
            {
                ContractId = dto.ContractID,
                StudentCode = dto.StudentID,
                StudentName = dto.StudentName,
                RoomNumber = dto.RoomNumber,
                StartDate = dto.StartTime.ToDateTime(TimeOnly.MinValue),
                EndDate = dto.EndTime.ToDateTime(TimeOnly.MinValue),
                MonthlyFee = monthlyFee,
                SubmittedAt = dto.CreatedDate
            };
        }

        public static async Task<bool> ApproveContractAsync(string contractId)
        {
            if (string.IsNullOrWhiteSpace(contractId)) return false;
            var response = await HttpService.Client.PostAsync($"api/contracts/{contractId}/approve", null);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> RejectContractAsync(string contractId)
        {
            if (string.IsNullOrWhiteSpace(contractId)) return false;
            var response = await HttpService.Client.PostAsync($"api/contracts/{contractId}/reject", null);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<PaymentResponse>> GetPaymentsAsync(string status, string search)
        {
            var query = BuildQuery(
                ("status", NormalizeFilter(status)),
                ("search", string.IsNullOrWhiteSpace(search) ? null : search));

            var payments = await HttpService.Client.GetFromJsonAsync<List<PaymentReadDTO>>(
                $"api/payments{query}", JsonOptions);

            if (payments == null) return new List<PaymentResponse>();

            // Load contracts để map thông tin student và room
            var contractsResponse = await HttpService.Client.GetFromJsonAsync<List<ContractReadDTO>>(
                "api/contracts", JsonOptions);
            var contractLookup = contractsResponse?.ToDictionary(c => c.ContractID, StringComparer.OrdinalIgnoreCase) 
                ?? new Dictionary<string, ContractReadDTO>();

            return payments.Select(p => MapPayment(p, contractLookup)).ToList();
        }

        private static PaymentResponse MapPayment(PaymentReadDTO payment, Dictionary<string, ContractReadDTO> contractLookup)
        {
            contractLookup.TryGetValue(payment.ContractID, out var contract);
            return new PaymentResponse
            {
                Id = payment.PaymentID,
                BillCode = payment.PaymentID,
                StudentId = contract?.StudentID ?? string.Empty,
                StudentName = contract?.StudentName ?? string.Empty,
                RoomNumber = contract?.RoomNumber ?? string.Empty,
                Month = payment.BillMonth,
                Year = payment.PaymentDate.Year,
                TotalAmount = payment.PaymentAmount,
                PaidAmount = payment.PaidAmount,
                PaymentDate = payment.PaymentStatus.Equals("Paid", StringComparison.OrdinalIgnoreCase) ? payment.PaymentDate : null,
                Status = payment.PaymentStatus.Equals("Paid", StringComparison.OrdinalIgnoreCase) ? "Đã thanh toán" : "Chờ thanh toán"
            };
        }

        public static async Task<PaymentKpiResponse> GetPaymentKPIsAsync()
        {
            return await HttpService.Client.GetFromJsonAsync<PaymentKpiResponse>("api/payments/kpis", JsonOptions)
                ?? new PaymentKpiResponse();
        }

        public static async Task<bool> ConfirmPaymentAsync(string paymentId)
        {
            if (string.IsNullOrWhiteSpace(paymentId)) return false;
            var response = await HttpService.Client.PostAsync($"api/payments/{paymentId}/confirm", null);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<ViolationResponse>> GetViolationsAsync(string status, string search)
        {
            var query = BuildQuery(
                ("status", NormalizeFilter(status)),
                ("search", string.IsNullOrWhiteSpace(search) ? null : search));

            var violations = await HttpService.Client.GetFromJsonAsync<List<ViolationReadDTO>>(
                $"api/violations{query}", JsonOptions);

            if (violations == null) return new List<ViolationResponse>();

            // Load rooms để map room number
            var roomsResponse = await HttpService.Client.GetFromJsonAsync<List<RoomReadDTO>>(
                "api/room", JsonOptions);
            var roomLookup = roomsResponse?.ToDictionary(r => r.RoomID, r => r.RoomNumber.ToString(), StringComparer.OrdinalIgnoreCase)
                ?? new Dictionary<string, string>();

            return violations.Select(v => MapViolation(v, roomLookup)).ToList();
        }

        private static ViolationResponse MapViolation(ViolationReadDTO dto, Dictionary<string, string> roomLookup)
        {
            roomLookup.TryGetValue(dto.RoomID, out var roomNumber);
            return new ViolationResponse
            {
                ViolationId = dto.ViolationID,
                StudentId = dto.StudentID ?? string.Empty,
                StudentName = dto.StudentName ?? dto.StudentID ?? string.Empty,
                RoomNumber = roomNumber ?? dto.RoomID,
                ViolationType = dto.ViolationType,
                ReportDate = dto.ViolationDate,
                Status = dto.Status
            };
        }

        public static async Task<ViolationKpiResponse> GetViolationKPIsAsync()
        {
            return await HttpService.Client.GetFromJsonAsync<ViolationKpiResponse>("api/violations/kpis", JsonOptions)
                ?? new ViolationKpiResponse();
        }

        public static async Task<StatisticsResponse?> GetStatisticsAsync(DateTime from, DateTime to)
        {
            var query = BuildQuery(
                ("from", from.ToString("yyyy-MM-dd")),
                ("to", to.ToString("yyyy-MM-dd")));

            return await HttpService.Client.GetFromJsonAsync<StatisticsResponse>($"api/statistics{query}", JsonOptions);
        }

        public static async Task<DashboardKpiResponse> GetDashboardKPIsAsync(string? building, DateTime[] dateRange)
        {
            var (from, to) = NormalizeDateRange(dateRange);
            var query = BuildQuery(
                ("building", NormalizeFilter(building)),
                ("from", from.ToString("yyyy-MM-dd")),
                ("to", to.ToString("yyyy-MM-dd")));

            return await HttpService.Client.GetFromJsonAsync<DashboardKpiResponse>($"api/dashboard/kpis{query}", JsonOptions)
                ?? new DashboardKpiResponse();
        }

        public static async Task<DashboardChartsResponse> GetDashboardChartsDataAsync(string? building, DateTime[] dateRange)
        {
            var (from, to) = NormalizeDateRange(dateRange);
            var query = BuildQuery(
                ("building", NormalizeFilter(building)),
                ("from", from.ToString("yyyy-MM-dd")),
                ("to", to.ToString("yyyy-MM-dd")));

            return await HttpService.Client.GetFromJsonAsync<DashboardChartsResponse>($"api/dashboard/charts{query}", JsonOptions)
                ?? new DashboardChartsResponse();
        }

        public static async Task<List<AlertResponse>> GetDashboardAlertsAsync()
        {
            var alerts = await HttpService.Client.GetFromJsonAsync<List<AlertResponse>>("api/dashboard/alerts", JsonOptions);
            return alerts ?? new List<AlertResponse>();
        }

        public static async Task<List<ActivityResponse>> GetRecentActivityAsync(int limit)
        {
            var query = BuildQuery(("limit", limit.ToString()));
            var activities = await HttpService.Client.GetFromJsonAsync<List<ActivityResponse>>(
                $"api/dashboard/activities{query}", JsonOptions);
            return activities ?? new List<ActivityResponse>();
        }

        // Create methods
        public static async Task<(bool Success, string? ErrorMessage)> CreateRoomAsync(RoomCreateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PostAsJsonAsync("api/room", dto, JsonOptions);
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                
                // Extract error message from response
                string errorMessage = "Thêm phòng thất bại";
                try
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(errorContent))
                    {
                        try
                        {
                            var errorObj = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(errorContent, JsonOptions);
                            if (errorObj != null && errorObj.ContainsKey("message"))
                            {
                                errorMessage = errorObj["message"]?.ToString() ?? errorMessage;
                            }
                            else
                            {
                                errorMessage = errorContent.Trim('"');
                            }
                        }
                        catch
                        {
                            errorMessage = errorContent.Trim('"');
                        }
                    }
                }
                catch
                {
                    errorMessage = $"Lỗi: {response.StatusCode}";
                }
                
                return (false, errorMessage);
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                return (false, $"Không thể kết nối đến máy chủ: {ex.Message}");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return (false, $"Không thể kết nối đến máy chủ. API có thể chưa chạy: {ex.Message}");
            }
            catch (System.Threading.Tasks.TaskCanceledException)
            {
                return (false, "Kết nối bị timeout. Vui lòng thử lại sau.");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public static async Task<bool> CreatePaymentAsync(PaymentCreateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PostAsJsonAsync("api/payments", dto, JsonOptions);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> CreateViolationAsync(ViolationCreateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PostAsJsonAsync("api/violations", dto, JsonOptions);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> CreateContractAsync(ContractCreateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PostAsJsonAsync("api/contracts", dto, JsonOptions);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private static string NormalizeFilter(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            return value.StartsWith("tất cả", StringComparison.OrdinalIgnoreCase) ? string.Empty : value;
        }

        private static (DateTime from, DateTime to) NormalizeDateRange(DateTime[] range)
        {
            DateTime from = range.Length > 0 ? range[0] : new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime to = range.Length > 1 ? range[1] : DateTime.Now;
            if (from > to)
            {
                (from, to) = (to, from);
            }

            return (from, to);
        }

        private static string BuildQuery(params (string key, string? value)[] parameters)
        {
            var parts = parameters
                .Where(p => !string.IsNullOrWhiteSpace(p.value))
                .Select(p => $"{p.key}={Uri.EscapeDataString(p.value!)}")
                .ToList();

            return parts.Count == 0 ? string.Empty : $"?{string.Join("&", parts)}";
        }

        private static RoomResponse MapRoom(RoomReadDTO room)
        {
            return new RoomResponse
            {
                RoomId = room.RoomID,
                RoomNumber = room.RoomNumber,
                BuildingId = room.BuildingID,
                Building = room.BuildingID,
                RoomType = GetRoomType(room.Capacity),
                CurrentOccupants = room.CurrentOccupancy,
                MaxOccupants = room.Capacity,
                Status = room.Status,
                Price = room.Price
            };
        }

        private static string GetRoomType(int capacity) =>
            capacity switch
            {
                <= 2 => "Phòng đôi",
                <= 4 => "Phòng 4",
                <= 6 => "Phòng 6",
                _ => $"Phòng {capacity}"
            };
    }
}

