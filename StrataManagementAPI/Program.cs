using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StrataManagementAPI.DataAccess;
using StrataManagementAPI.Models;
using StrataManagementAPI.Repositories;
using StrataManagementAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add repositories
builder.Services.AddSingleton<IBuildingRepository>(provider =>
    new BuildingRepository(provider.GetRequiredService<IConfiguration>()));

builder.Services.AddSingleton<IOwnerRepository>(provider =>
    new OwnerRepository(provider.GetRequiredService<IConfiguration>()));

builder.Services.AddSingleton<ITenantRepository>(provider =>
    new TenantRepository(provider.GetRequiredService<IConfiguration>()));

builder.Services.AddSingleton<IMaintenanceRequestRepository>(provider =>
    new MaintenanceRequestRepository(provider.GetRequiredService<IConfiguration>()));

builder.Services.AddSingleton<IUserRepository>(provider =>
    new UserRepository(provider.GetRequiredService<IConfiguration>()));

// Add services
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBuildingMemberService, BuildingMemberService>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Bind JWT settings
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("Jwt"));

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));

    options.AddPolicy("BuildingMember", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Owner") ||
            context.User.IsInRole("Tenant")));
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
