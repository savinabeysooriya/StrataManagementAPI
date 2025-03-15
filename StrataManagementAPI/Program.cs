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

// Add services
builder.Services.AddScoped<IBuildingService, BuildingService>();

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
