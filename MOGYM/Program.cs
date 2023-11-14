using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
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
        option.LoginPath = "/Home/SignIn";
        option.ExpireTimeSpan = TimeSpan.FromDays(2);
    });

builder.Services.AddDbContext<MyDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("MogymConnectingString"));
    });

//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
//    {
//        options.SignIn.RequireConfirmedAccount = false;
//        options.User.RequireUniqueEmail = true;
//    }).AddEntityFrameworkStore<MyDbContext>();

// Register Services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<DbContext, MyDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
builder.Services.AddTransient<FileUploadService>();

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

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Code for seeding roles
//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

//    var roles = new[] { "Admin", "Trainer", "Trainee" };

//    foreach (var role in roles)
//    {
//        if (!await roleManager.RoleExistsAsync(role))
//        {
//            await roleManager.CreateAsync(new IdentityRole(role));
//        }
//    }
//}

app.Run();
