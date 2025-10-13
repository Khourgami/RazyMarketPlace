// RazySoft.Market.Admin.Web/Program.cs (Updated for all services)

using RazySoft.Market.Admin.Application.Interfaces.Services;
using RazySoft.Market.Admin.Application.Services;
using RazySoft.Market.Admin.Infrastructure;
using RazySoft.Market.Admin.Web.Services;
using RazySoft.Market.Admin.Web.Services.UiContracts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// --- Infrastructure and Application Layer Registrations ---
// This registers the AdminDbContext (EF Core) from the Infrastructure layer
builder.Services.AddAdminInfrastructure(configuration);

// Application Service Registrations (MOCK IMPLEMENTATIONS FOR BUILD)
// Replace these with actual Infrastructure implementations when building the solution
builder.Services.AddScoped<IPartyService, PartyService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
// --- End Application Services ---

// UI Services Registration (Wrapper classes for Application services, handling presentation logic/errors)
builder.Services.AddScoped<IPartyUiService, PartyUiService>();
builder.Services.AddScoped<IProductUiService, ProductUiService>();
builder.Services.AddScoped<IInvoiceUiService, InvoiceUiService>();
builder.Services.AddScoped<ITenantUiService, TenantUiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
