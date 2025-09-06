
using EmployeeManagement.Application.Interface;
using EmployeeManagement.Application.Interface.IRepo;
using EmployeeManagement.Application.Interface.IService;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//inject db context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//mapping
//builder.Services.AddAutoMapper(typeof(AutoMapping));
//inject ropes and services
//builder.Services.AddScoped<IProfileService, ProfileService>();
//builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

//builder.Services.AddScoped<IProjectService, ProjectService>();
//builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

//builder.Services.AddScoped<IDeptRepository, DeptRepository>();
//builder.Services.AddScoped<IDeptService, DeptService>();

//builder.Services.AddScoped<IEmpRepository, EmployeeRepository>();
//builder.Services.AddScoped<IEmpService, EmpService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
