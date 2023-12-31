

using System.Net;
using App.Models.AppDbContext;
using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    //tao mot cai engine de tim cac trang razor khi trong view khong co thi se tim dem cac trong view cua controller tu tao
    // {0} -> ten action
    // {1} -> ten controller
    // {2} -> ten Area

    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});


builder.Services.AddSingleton<ProductService, ProductService>();
builder.Services.AddSingleton<PlanetService,PlanetService>();
builder.Services.AddDbContext<AppDbContext>(options =>{
    string connectString = builder.Configuration.GetConnectionString("AppMvcConnectString");
    options.UseSqlServer(connectString);
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

app.MapAreaControllerRoute(
    name:"product",
    pattern: "{controller}/{action=Index}/{id?}",
    areaName : "ProductManage"
);

//su dung tren cac controller khong co area
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
