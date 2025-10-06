using Microsoft.EntityFrameworkCore;
using RazySoft.MarketSync.Api.Data;
using RazySoft.MarketSync.Api.Middleware;
using RazySoft.MarketSync.Api.Repositories;
using RazySoft.MarketSync.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IPartyRepository, PartyRepository>();
builder.Services.AddScoped<IPartyService, PartyService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseTenantDeviceValidation();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
