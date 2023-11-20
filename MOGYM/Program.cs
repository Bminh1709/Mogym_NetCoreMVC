using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MOGYM.Data;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Infracstructure.Repositories;
using MOGYM.Infracstructure.Services;
using MOGYM.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.ExpireTimeSpan = TimeSpan.FromDays(2);
        option.LoginPath = new PathString("/Home/SignIn");
        option.AccessDeniedPath = new PathString("/Home/Error/403");
    });

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MogymConnectingString"));
});

// Register Services
builder.Services.AddScoped<DbContext, MyDbContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
//builder.Services.AddScoped<IAdminRepository, AdminRepository>();
//builder.Services.AddScoped<IBranchRepository, BranchRepository>();
//builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
builder.Services.AddTransient<FileUploadService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

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

app.UseAuthentication();

app.UseAuthorization();

app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
