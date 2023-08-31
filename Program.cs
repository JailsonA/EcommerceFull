using EcommerceFull.Data;
using Microsoft.EntityFrameworkCore;
using PayPal.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// add DBContext 
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//add DBLayer
builder.Services.AddScoped<DBLayer>();
//add DBAutent
builder.Services.AddScoped<DBAutent>();
//add DBUtils
builder.Services.AddScoped<DBUtils>();
//add section
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
