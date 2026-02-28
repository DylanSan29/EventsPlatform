using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

// --- NAMESPACES ---
using ManagementService.Api.Infrastructure.Data;
using ManagementService.Api.Infrastructure.Repositories;
using ManagementService.Api.Application;
using ManagementService.Api.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Management Service API", Version = "v1" });
});

// --- DB CONTEXT ---
builder.Services.AddDbContext<ManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- INJECTION ---
builder.Services.AddScoped<IManagementRepository, ManagementRepository>();
builder.Services.AddScoped<IManagementService, ManagementServiceImpl>();

// --- AUTH ---
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth:Authority"];
        options.Audience = "management-service"; // Update audience!
        options.RequireHttpsMetadata = false;
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Management API v1"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();