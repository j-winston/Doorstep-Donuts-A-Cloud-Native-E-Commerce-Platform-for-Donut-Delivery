using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IDonutRepository, MockDonutRepository>();

builder.Services.AddDbContext<DoorStepDonutsDbContext>(options =>
{
    //options.UseSqlServer(
    //        builder.Configuration["ConnectionStrings: DoorStepDonutsDbContextConnection"]);

    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware pipeline
// Static files 
app.UseStaticFiles();

// Exception display 
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Endpoint middleware
app.MapDefaultControllerRoute();

app.Run();

