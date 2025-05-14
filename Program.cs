using Microsoft.EntityFrameworkCore;
using ThuyTo.Models;
using Microsoft.Extensions.Options;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("ERROR");
builder.Services.AddDbContext<ThuyToContext>(options => 
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

/*var mailsettings = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings> (mailsettings);*/

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
// builder.Services.AddSassCompiler();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(cfg =>
{
    cfg.Cookie.Name = "ThuyTo";             // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
    cfg.IdleTimeout = TimeSpan.FromMinutes(30);    // Thời gian tồn tại của Session
    cfg.Cookie.HttpOnly = true;
    cfg.Cookie.IsEssential = true;
});
builder.Services.AddNotyf(config => 
{ 
    config.DurationInSeconds = 10; 
    config.IsDismissable = true; 
    config.Position = NotyfPosition.TopRight; 
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/NotFound";
        // Trả về NotFound hoặc Middleware khác
        await context.Response.WriteAsync("Not Found");
    }
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.UseNotyf();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

//Scaffold-DbContext "Server=.\SQLExpress;Database=ThuyTo;Trusted_Connection=True;TrustServerCertificate=True; Connection Timeout=3600" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
