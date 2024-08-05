using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RestDBcontext>(options => options.UseSqlServer("Data Source = (localdb)\\ProjectModels; Initial Catalog = Restaurant; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate=False; Application Intent = ReadWrite; Multi Subnet Failover=False"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<RestDBcontext>();

#region Services
builder.Services.AddScoped<IHallService, HallService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrdered_ItemsService, Ordered_ItemsService>();
builder.Services.AddScoped<IProfitService, ProfitService>();
builder.Services.AddScoped<IReceiptService, ReceiptService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IStorageRoomService, StorageRoomService>();
builder.Services.AddScoped<ITableService, TableService>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
