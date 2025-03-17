using StrataManagementAPI.DataAccess;
using StrataManagementAPI.Repositories;
using StrataManagementAPI.Services;

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

// Add services
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBuildingMemberService, BuildingMemberService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
