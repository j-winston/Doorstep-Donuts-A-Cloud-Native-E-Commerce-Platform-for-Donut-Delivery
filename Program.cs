using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();

//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IDonutRepository, MockDonutRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDonutRepository, DonutRepository>();


builder.Services.AddDbContext<DoorStepDonutsDbContext>(options =>
{
    //options.UseSqlServer(
    //        builder.Configuration["ConnectionStrings: DoorStepDonutsDbContextConnection"]);

    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware pipeline
app.UseStaticFiles();

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

