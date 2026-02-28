using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

// --- 1. CHANGED: Use GuestService Namespaces ---
using GuestService.Api.Infrastructure.Data;
using GuestService.Api.Infrastructure.Repositories;
using GuestService.Api.Application;
using GuestService.Api.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Guest Service API", Version = "v1" });
});

// --- 2. CHANGED: Use GuestDbContext ---
builder.Services.AddDbContext<GuestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// --- 3. CHANGED: Register Guest Repository & Service ---
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IGuestService, GuestServiceImpl>(); 

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth:Authority"];
        // --- 4. CHANGED: Update Audience for this specific service ---
        options.Audience = "guest-service"; 
        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Guest Service API v1");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();