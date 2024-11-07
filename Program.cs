using e_commerce.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IDonutRepository, MockDonutRepository>();

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

