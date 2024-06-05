
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using taskify.Models;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

builder.Services.AddControllersWithViews();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));


builder.Services.AddDbContext<AppContext>(options =>
{
    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
.AddEntityFrameworkStores<AppContext>()
.AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.LogoutPath = "/Auth/Logout";
});



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
