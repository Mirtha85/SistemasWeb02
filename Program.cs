using Microsoft.EntityFrameworkCore;
using SistemasWeb01.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BethesdaPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BethesdaPieShopDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoriaRepositorio, categoriaRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, productoRepositorio>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddDbContext<BethesdaPieShopDbContext>(options => {
    options.UseSqlite(connectionString);
});
//builder.Services.AddDbContext<BethesdaPieShopDbContext>(options => {
//    options.UseSqlite(
//        builder.Configuration["ConnectionStrings:BethesdaPieShopDbContextConnection"]);
//});

builder.Services.AddDefaultIdentity<IdentityUser>(
    //options => options.SignIn.RequireConfirmedAccount = true // para verificar el correo
    ).AddEntityFrameworkStores<BethesdaPieShopDbContext>();



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

app.UseAuthentication();
app.UseAuthorization();
//app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapBlazorHub();

DbInitializer.Seed(app);
app.Run();
