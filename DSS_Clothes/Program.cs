using DSS_Clothes.Repository;
using DSS_Clothes.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr") ?? throw new InvalidOperationException("Connection string 'ConnectionStr' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IBrand, BrandRepository>();
builder.Services.AddTransient<IStore, StoreRepository>();
builder.Services.AddTransient<IClothe, ClotheRepository>();
builder.Services.AddTransient<IDesigner, DesignerRepository>();

// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
