using AutoMapper;
using DormitoryManagementSystem.BUS.Implementations;
using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DAO.Context;
using DormitoryManagementSystem.DAO.Implementations;
using DormitoryManagementSystem.DAO.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Database Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in appsettings.json");
}
builder.Services.AddDbContext<PostgreDbContext>(options =>
    options.UseNpgsql(connectionString));

// AutoMapper
builder.Services.AddAutoMapper(typeof(DormitoryManagementSystem.Mappings.MappingProfile));

// DAOs
builder.Services.AddScoped<IUserDAO, UserDAO>();
builder.Services.AddScoped<IRoomDAO, RoomDAO>();
builder.Services.AddScoped<IBuildingDAO, BuildingDAO>();
builder.Services.AddScoped<IContractDAO, ContractDAO>();
builder.Services.AddScoped<IStudentDAO, StudentDAO>();
builder.Services.AddScoped<INewsDAO, NewsDAO>();
builder.Services.AddScoped<IPaymentDAO, PaymentDAO>();
builder.Services.AddScoped<IViolationDAO, ViolationDAO>();
builder.Services.AddScoped<IAdminDAO, AdminDAO>();
builder.Services.AddScoped<IStatisticsDAO, StatisticsDAO>();

// BUSs
builder.Services.AddScoped<IUserBUS, UserBUS>();
builder.Services.AddScoped<IRoomBUS, RoomBUS>();
builder.Services.AddScoped<IBuildingBUS, BuildingBUS>();
builder.Services.AddScoped<IContractBUS, ContractBUS>();
builder.Services.AddScoped<IStudentBUS, StudentBUS>();
builder.Services.AddScoped<INewsBUS, NewsBUS>();
builder.Services.AddScoped<IPaymentBUS, PaymentBUS>();
builder.Services.AddScoped<IViolationBUS, ViolationBUS>();
builder.Services.AddScoped<IAdminBUS, AdminBUS>();
builder.Services.AddScoped<IStatisticsBUS, StatisticsBUS>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
