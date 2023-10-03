using DotNetCoreMVCDemo.Data.Repository;
using DotNetCoreMVCDemo.DomainLayer.Entity;
using DotNetCoreMVCDemo.DomainLayer.Interfaces;
using DotNetCoreMVCDemo.InfrastructureLayer.Data;
using DotNetCoreMVCDemo.InfrastructureLayer.Repositories;
using DotNetCoreMVCDemo.Middleware;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

//SP: Add db connection string.
builder.Services.AddDbContext<DotNetCoreMVCDemoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DotNetCoreMVCDemoContext") ?? throw new InvalidOperationException("Connection string 'DotNetCoreMVCDemoContext' not found.")));


//SP: To solve the cshtml refresh problem  you can refresh your views or pages and get change in browser at run time. 
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Add services for the controller and views.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<DotNetCoreMVCDemoContext, DotNetCoreMVCDemoContext>();
builder.Services.AddScoped<TicketRepository, TicketRepository>();
builder.Services.AddScoped<MovieRepository, MovieRepository>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

WebApplication app = builder.Build();

//SP: Add Middleware with both methods
app.UseMyMiddleware();
//app.UseMiddleware<MyMiddleware>();

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
