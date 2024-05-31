using Innovation_Admin.UI.Common;
using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Services.IRepositories;
using Innovation_Admin.UI.Services.Repositories;
using Microsoft.Extensions.Configuration;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var Configuration = builder.Configuration;

// ApiBaseUrl Keys
builder.Services.Configure<ApiBaseUrl>(Configuration.GetSection("ApiBaseUrl"));
builder.Services.AddScoped<IAuthenticationService, Authentication>();

builder.Services.AddScoped<ISysPrefCompanies, SysPrefCompanies>();
builder.Services.AddScoped<ISysPrefGeneralBehaviouries, SysPrefGeneralBehaviouries>();

builder.Services.AddScoped<IAdminUser, AdminUser>();
builder.Services.AddScoped<IAdminRoles, AdminRoles>();
builder.Services.AddScoped<IAccountManager, AccountManager>();

builder.Services.AddScoped<IPharmacyGroup, PharmacyGroups>();
builder.Services.AddScoped<ISysPrefGeneralBehaviouries, SysPrefGeneralBehaviouries>();

builder.Services.AddScoped<ISysPrefFinancials, SysPrefFinancials>();




builder.Services.AddScoped<Common>();





builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
