using DormitoryManagementSystem.API.Models;
using DormitoryManagementSystem.DTO.Admins;
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
            var response = await HttpService.Client.PostAsJsonAsync("api/auth/login", request, JsonOptions);
            if (!response.IsSuccessStatusCode)
            {
                    string errorMessage = "Không thể đăng nhập";
                    try
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(errorContent))
                        {
                            try
                            {
                                var errorObj = JsonSerializer.Deserialize<Dictionary<string, object>>(errorContent, JsonOptions);
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
                
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = detailedMessage
                };
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = $"Không thể kết nối đến máy chủ. API có thể chưa chạy hoặc địa chỉ không đúng. Chi tiết: {ex.Message}"
                };
            }
            catch (TaskCanceledException ex)
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = "Kết nối bị timeout. Vui lòng kiểm tra API đã chạy chưa hoặc thử lại sau."
                };
            }
            catch (Exception ex)
            {
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

        public static async Task<RoomReadDTO?> GetRoomByIdAsync(string roomId)
        {
            try
            {
                var response = await HttpService.Client.GetAsync($"api/room/{roomId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RoomReadDTO>(JsonOptions);
                }
            }
            catch (Exception)
            {
                // Xử lý lỗi
            }
            return null;
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

        public static async Task<List<AdminReadDTO>> GetAdminsAsync()
        {
            try
            {
                var admins = await HttpService.Client.GetFromJsonAsync<List<AdminReadDTO>>("api/admin", JsonOptions);
                return admins ?? new List<AdminReadDTO>();
            }
            catch
            {
                return new List<AdminReadDTO>();
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

        public static async Task<ContractReadDTO?> GetContractByIdAsync(string contractId)
        {
            try
            {
                var response = await HttpService.Client.GetAsync($"api/contracts/{contractId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ContractReadDTO>(JsonOptions);
                }
            }
            catch (Exception)
            {
                // Handle error
            }
            return null;
        }

        public static async Task<(bool success, string? errorMessage)> UpdateContractAsync(string contractId, ContractUpdateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PutAsJsonAsync($"api/contracts/{contractId}", dto, JsonOptions);
                
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return (false, errorContent);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public static async Task<(bool success, string? errorMessage)> DeleteContractAsync(string contractId)
        {
            try
            {
                var response = await HttpService.Client.DeleteAsync($"api/contracts/{contractId}");
                
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return (false, errorContent);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private static ContractResponse MapContract(ContractReadDTO dto)
        {
            return new ContractResponse
            {
                ContractId = dto.ContractID,
                StudentId = dto.StudentID,
                StudentName = dto.StudentName,
                RoomId = dto.RoomID,
                RoomNumber = dto.RoomNumber,
                StaffUserID = dto.StaffUserID,
                StartDate = dto.StartTime.ToDateTime(TimeOnly.MinValue),
                EndDate = dto.EndTime.ToDateTime(TimeOnly.MinValue),
                Status = dto.Status,
                CreatedDate = dto.CreatedDate
            };
        }

        public static async Task<List<PendingContractResponse>> GetPendingContractsAsync(string search)
        {
            var query = BuildQuery(("search", string.IsNullOrWhiteSpace(search) ? null : search));
            var contracts = await HttpService.Client.GetFromJsonAsync<List<ContractReadDTO>>(
                $"api/contracts/pending{query}", JsonOptions);

            if (contracts == null) return new List<PendingContractResponse>();

            // Tải danh sách phòng MonthlyFee
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

            // Tải danh sách hợp đồng để thông tin sinh viên và phòng
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
                PaymentID = payment.PaymentID,
                ContractID = payment.ContractID,
                BillMonth = payment.BillMonth,
                PaymentAmount = payment.PaymentAmount,
                PaidAmount = payment.PaidAmount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                Description = payment.Description,
                StudentId = contract?.StudentID ?? string.Empty,
                StudentName = contract?.StudentName ?? string.Empty,
                RoomNumber = contract?.RoomNumber ?? string.Empty,
                Month = payment.BillMonth,
                Year = payment.PaymentDate.Year,
                TotalAmount = payment.PaymentAmount,
                Status = payment.PaymentStatus.Equals("Paid", StringComparison.OrdinalIgnoreCase) ? "Đã thanh toán" : 
                        payment.PaymentStatus.Equals("Unpaid", StringComparison.OrdinalIgnoreCase) ? "Chờ thanh toán" :
                        payment.PaymentStatus.Equals("Late", StringComparison.OrdinalIgnoreCase) ? "Quá hạn" :
                        payment.PaymentStatus
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

            // Tải danh sách phòng để thông tin số phòng
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
                RoomID = dto.RoomID,
                RoomNumber = roomNumber ?? dto.RoomID,
                ReportedByUserID = dto.ReportedByUserID,
                ViolationType = dto.ViolationType,
                ViolationDate = dto.ViolationDate,
                PenaltyFee = dto.PenaltyFee,
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

        // Các phương thức tạo mới
        public static async Task<(bool Success, string? ErrorMessage)> CreateRoomAsync(RoomCreateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PostAsJsonAsync("api/room", dto, JsonOptions);
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                
                var errorMessage = await ExtractErrorMessageAsync(response, "Thêm phòng thất bại");
                return (false, errorMessage);
            }
            catch (Exception ex)
            {
                return HandleHttpException(ex);
            }
        }

        public static async Task<(bool Success, string? ErrorMessage)> UpdateRoomAsync(string roomId, RoomUpdateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PutAsJsonAsync($"api/room/{roomId}", dto, JsonOptions);
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                
                var errorMessage = await ExtractErrorMessageAsync(response, "Cập nhật phòng thất bại");
                return (false, errorMessage);
            }
            catch (Exception ex)
            {
                return HandleHttpException(ex);
            }
        }

        public static async Task<(bool Success, string? ErrorMessage)> DeleteRoomAsync(string roomId)
        {
            try
            {
                var response = await HttpService.Client.DeleteAsync($"api/room/{roomId}");
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                
                var errorMessage = await ExtractErrorMessageAsync(response, "Xóa phòng thất bại");
                return (false, errorMessage);
            }
            catch (Exception ex)
            {
                return HandleHttpException(ex);
            }
        }

        public static async Task<PaymentReadDTO?> GetPaymentByIdAsync(string paymentId)
        {
            try
            {
                var response = await HttpService.Client.GetAsync($"api/payments/{paymentId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PaymentReadDTO>(JsonOptions);
                }
            }
            catch (Exception)
            {
                // Xử lý lỗi
            }
            return null;
        }

        public static async Task<(bool Success, string? ErrorMessage)> CreatePaymentAsync(PaymentCreateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PostAsJsonAsync("api/payments", dto, JsonOptions);
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                
                var errorMessage = await ExtractErrorMessageAsync(response, "Tạo thanh toán thất bại");
                return (false, errorMessage);
            }
            catch (Exception ex)
            {
                return HandleHttpException(ex);
            }
        }

        public static async Task<(bool Success, string? ErrorMessage)> UpdatePaymentAsync(string paymentId, PaymentUpdateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PutAsJsonAsync($"api/payments/{paymentId}", dto, JsonOptions);
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
            }
                
                var errorMessage = await ExtractErrorMessageAsync(response, "Cập nhật thanh toán thất bại");
                return (false, errorMessage);
            }
            catch (Exception ex)
            {
                return HandleHttpException(ex);
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

        public static async Task<ViolationReadDTO?> GetViolationByIdAsync(string id)
        {
            try
            {
                return await HttpService.Client.GetFromJsonAsync<ViolationReadDTO>($"api/violations/{id}", JsonOptions);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<(bool Success, string? ErrorMessage)> UpdateViolationAsync(string id, ViolationUpdateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PutAsJsonAsync($"api/violations/{id}", dto, JsonOptions);
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                
                var errorMessage = await ExtractErrorMessageAsync(response, "Cập nhật vi phạm thất bại");
                return (false, errorMessage);
            }
            catch (Exception ex)
            {
                return HandleHttpException(ex);
            }
        }

        public static async Task<(bool success, string? errorMessage)> CreateContractAsync(ContractCreateDTO dto)
        {
            try
            {
                var response = await HttpService.Client.PostAsJsonAsync("api/contracts", dto, JsonOptions);
                
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return (false, errorContent);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
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

        private static async Task<string> ExtractErrorMessageAsync(System.Net.Http.HttpResponseMessage response, string defaultMessage)
        {
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
                            return errorObj["message"]?.ToString() ?? defaultMessage;
                        }
                        return errorContent.Trim('"');
                    }
                    catch
                    {
                        return errorContent.Trim('"');
                    }
                }
            }
            catch
            {
                // Bỏ qua
            }
            return $"Lỗi: {response.StatusCode}";
        }

        private static (bool Success, string? ErrorMessage) HandleHttpException(Exception ex)
        {
            return ex switch
            {
                System.Net.Http.HttpRequestException httpEx => (false, $"Không thể kết nối đến máy chủ: {httpEx.Message}"),
                System.Net.Sockets.SocketException socketEx => (false, $"Không thể kết nối đến máy chủ. API có thể chưa chạy: {socketEx.Message}"),
                TaskCanceledException => (false, "Kết nối bị timeout. Vui lòng thử lại sau."),
                _ => (false, $"Lỗi: {ex.Message}")
            };
        }
    }
}

