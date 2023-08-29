using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShoppingCart.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
//builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
//builder.Configuration.GetSection("ConnectionStrings:SqlConnection").ToString();
string connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<AppDbContext>(m => m.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'SqlConnection' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDistributedSqlServerCache(m =>
{
    m.ConnectionString = connectionString;
    m.SchemaName = "dbo";
    m.TableName = "SessionData";
});

// singleton
// scope
// transient

builder.Services.AddSession(m =>
{
    m.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
_context.Database.Migrate();

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
//test comments
