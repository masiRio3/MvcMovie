using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Models.SeedData;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("fr")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture= new RequestCulture("en-US"),
    SupportedCultures=supportedCultures,
    SupportedUICultures=supportedCultures
});



using (var scoppe= app.Services.CreateScope())
{
    var servicees = scoppe.ServiceProvider;

    SeedData.Initialize(servicees);
}

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
