using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDonutRepository, DonutRepository>();

// Add services for a single shopping cart to be used by all requests
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DoorStepDonutsDbContext>(options =>
{
    //options.UseSqlServer(
    //        builder.Configuration["ConnectionStrings: DoorStepDonutsDbContextConnection"]);

    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
});


var app = builder.Build();

// Middleware pipeline
app.UseStaticFiles();
app.UseSession();

// Exception display 
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Default convention based routing middleware
app.MapDefaultControllerRoute();

// Sessions 
app.UseSession();

// Seed data
DbInitializer.Seed(app);

app.Run();

