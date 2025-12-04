using System.Text;
using System.Text.Json;
using DormitoryManagementSystem.BUS.Implementations;
using DormitoryManagementSystem.BUS.Implements;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Implementations;
using DormitoryManagementSystem.DAO.Implements;
using DormitoryManagementSystem.DAO.Interfaces;
using DormitoryManagementSystem.DTO.Errors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace DormitoryManagementSystem.API.Extensions
{
    public static class ServiceExtensions
    {
        // Database
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextFactory<PostgreDbContext>(options =>
                options.UseNpgsql(connectionString));
        }

        // JWT Authentication & Authorization
        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var secretKey = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            if (string.IsNullOrEmpty(secretKey)) throw new InvalidOperationException("JWT Key is missing in appsettings.json");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                // Custom Response cho lỗi 401/403
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize(new ErrorResponse { StatusCode = 401, Message = "Bạn chưa đăng nhập hoặc Token không hợp lệ." });
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        context.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize(new ErrorResponse { StatusCode = 403, Message = "Bạn không có quyền truy cập vào chức năng này." });
                        return context.Response.WriteAsync(result);
                    }
                };
            });

            services.AddAuthorization();
        }

        // Swagger
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dormitory API", Version = "v1" });

             

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Nhập Token vào ô bên dưới."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] {}
                    }
                });
            });
        }

        // Dependency Injection (BUS & DAO)
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(DormitoryManagementSystem.Mappings.MappingProfile));

            // DAOs
            services.AddScoped<IUserDAO, UserDAO>();
            services.AddScoped<IRoomDAO, RoomDAO>();
            services.AddScoped<IBuildingDAO, BuildingDAO>();
            services.AddScoped<IContractDAO, ContractDAO>();
            services.AddScoped<IStudentDAO, StudentDAO>();
            services.AddScoped<INewsDAO, NewsDAO>();
            services.AddScoped<IPaymentDAO, PaymentDAO>();
            services.AddScoped<IViolationDAO, ViolationDAO>();
            services.AddScoped<IAdminDAO, AdminDAO>();
            services.AddScoped<IStatisticsDAO, StatisticsDAO>();
            services.AddScoped<IDashboardDAO, DashboardDAO>();

            // BUSs
            services.AddScoped<IUserBUS, UserBUS>();
            services.AddScoped<IRoomBUS, RoomBUS>();
            services.AddScoped<IBuildingBUS, BuildingBUS>();
            services.AddScoped<IContractBUS, ContractBUS>();
            services.AddScoped<IStudentBUS, StudentBUS>();
            services.AddScoped<INewsBUS, NewsBUS>();
            services.AddScoped<IPaymentBUS, PaymentBUS>();
            services.AddScoped<IViolationBUS, ViolationBUS>();
            services.AddScoped<IAdminBUS, AdminBUS>();
            services.AddScoped<IStatisticsBUS, StatisticsBUS>();
            services.AddScoped<IDashboardBUS, DashboardBUS>();
        }

        // CORS
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
    }
}