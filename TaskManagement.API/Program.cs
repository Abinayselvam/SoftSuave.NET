
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Service;
using TaskManagement.Data.Context;
using TaskManagement.Data.IRepositories;
using TaskManagement.Data.Repositories;
using TaskMangement.Infrastructure.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//db injection
// DbContext (connection string from appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Application service
builder.Services.AddScoped<ProjectService>();

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
