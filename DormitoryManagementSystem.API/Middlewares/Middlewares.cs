using System.Net;
using System.Text.Json;
using DormitoryManagementSystem.DTO.Errors;

namespace DormitoryManagementSystem.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi hệ thống: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            // lỗi 500
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Lỗi hệ thống. Vui lòng liên hệ Admin.";

            // Xử lý các lỗi từ bus/dao
            switch (exception)
            {
                case KeyNotFoundException: // Lỗi không tìm thấy (404)
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;

                case ArgumentException:    // Lỗi tham số (400)
                case InvalidOperationException: // Lỗi logic nghiệp vụ (400)
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;

                case UnauthorizedAccessException: // Lỗi quyền (401)
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    message = exception.Message;
                    break;
            }

            context.Response.StatusCode = statusCode;
            var response = new ErrorResponse { StatusCode = statusCode, Message = message };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}