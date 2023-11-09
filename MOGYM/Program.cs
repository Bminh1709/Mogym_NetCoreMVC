using Microsoft.EntityFrameworkCore;
using MOGYM.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
{
    // Map to appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("MogymConnectingString"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Singleton 
builder.Services.AddSingleton<MyDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "TraineeArea",
    areaName: "Trainee",
    pattern: "Trainee/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "TrainerArea",
    areaName: "Trainer",
    pattern: "Trainer/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "AdminArea",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
