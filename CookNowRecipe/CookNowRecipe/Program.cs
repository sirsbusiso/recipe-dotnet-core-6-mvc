using CookNowRecipe.BulderLayer;
using CookNowRecipe.BulderLayer.Interface;
using CookNowRecipe.BusinessServiceLayer;
using CookNowRecipe.BusinessServiceLayer.Interface;
using CookNowRecipe.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("ConnString");
builder.Services.AddDbContext<RecipeDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<IAccountBuilder, AccountBuilder>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IRecipeBuilder, RecipeBuilder>();
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});





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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}/{slung?}");

app.Run();
