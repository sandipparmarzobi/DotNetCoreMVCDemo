using DotNetCoreMVCDemo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetCoreMVCDemo.Data;

var builder = WebApplication.CreateBuilder(args);

//SP: Add db connection string.
builder.Services.AddDbContext<DotNetCoreMVCDemoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DotNetCoreMVCDemoContext") ?? throw new InvalidOperationException("Connection string 'DotNetCoreMVCDemoContext' not found.")));

//SP: To solve the cshtml refresh problem  you can refresh your views or pages and get change in browser at run time. 
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();
var allowedHost = app.Configuration["AllowedHosts"];
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//SP: Controller Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
