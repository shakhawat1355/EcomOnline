using Autofac;
using Autofac.Extensions.DependencyInjection;
using DomainLayer.DomainModel;
using RepositoryLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository;
using ServiceLayer.Services;

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

var app = builder.Build();





using (var scope = app.Services.CreateScope())
{
    var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
    // Insert a new user
    var newUser = new User
    {
        Name = "John Doe 2",
        age = 30,
        Email = "john@example.com",
        Password = "password123"
    };

    //userService.RegisterUser(newUser);
    userRepository.AddUser(newUser);
    // Retrieve the user by ID
    var retrievedUser = userService.GetUserById(1);

    // Use the retrieved user
    if (retrievedUser != null)
    {
        Console.WriteLine($"Retrieved User: ID={retrievedUser.Id}, Name={retrievedUser.Name}");
    }
    else
    {
        Console.WriteLine("User not found.");
    }
}






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
