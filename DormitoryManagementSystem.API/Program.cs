using DormitoryManagementSystem.API.Extensions; // Gọi Extension vừa tạo
using DormitoryManagementSystem.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// ====================================================
// 1. ADD SERVICES (Sử dụng Extension Methods)
// ====================================================

builder.Services.AddControllers()
       .AddJsonOptions(options =>
       {
           // options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter()); // Uncomment nếu cần
       });

builder.Services.AddEndpointsApiExplorer();

// Gọi các hàm cấu hình từ ServiceExtensions.cs
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureIdentity(builder.Configuration); // JWT
builder.Services.ConfigureSwagger();
builder.Services.ConfigureDependencyInjection(); // AutoMapper, DAO, BUS
builder.Services.ConfigureCors();

var app = builder.Build();

// ====================================================
// 2. CONFIGURE PIPELINE
// ====================================================

// Middleware xử lý lỗi toàn cục (Global Exception Handling)
app.UseMiddleware<GlobalExceptionMiddleware>();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

// Auth Pipeline
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();