using Autofac;
using Autofac.Extensions.DependencyInjection;
using DomainLayer.DomainModel;
using RepositoryLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository;
using ServiceLayer.Services;
using EcomOnline.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Web.Mvc;
using RazorViewEngine = Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine;
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);

//builder.RegisterType<UserRepository>().As<IUserRepository>();
//builder.RegisterType<UserService>().As<IUserService>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
    containerBuilder.RegisterType<UserService>().As<IUserService>();
});




// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


//builder.Services.Configure<RazorViewEngineOptions>(options =>
//{
//    options.ViewLocationExpanders.Add(new CustomViewLocationExpander());
//});


//builder.Services.Configure<RazorViewEngineOptions>(options =>
//{
//    options.ViewLocationFormats.Clear();
//    options.ViewLocationFormats.Add("/Themes/ThemeA/{1}/{0}.cshtml");
//    options.ViewLocationFormats.Add("/Themes/ThemeA/Shared/{0}.cshtml");
//    options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
//    options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
//});





var app = builder.Build();








//var viewEngines = ViewEngines.Engines;


//var viewEngines = ViewEngines.Engines;
//var razorViewEngine = viewEngines.OfType<RazorViewEngine>().FirstOrDefault();
//if (razorViewEngine != null)
//{
//    razorViewEngine.ViewLocationFormats = new[]
//     {
//                "~/Views/{1}/{0}.cshtml",
//                "~/Views/Shared/{0}.cshtml",
//                "~/NewViewLocation/{0}.cshtml"
//            };
//}







// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
