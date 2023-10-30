using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Sureze.Domain.Contextes;
using Sureze.Domain.Contracts.Repositories;
using Sureze.Helpers;
using Sureze.Methods;
using Sureze.Repositories;
using Sureze.Services;
using Volo.Abp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<IRepository, EfRepository>();
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddScoped<IServiceFactory, ServiceFactory>();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<PatientsClass>();
builder.Services.AddSingleton<StateContainer>();



var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.MapControllers();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
