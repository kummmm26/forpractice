using Microsoft.Extensions.FileSystemGlobbing.Internal;
using eCommerceWebApp.Dal;
using eCommerceWebApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//session default timeout = 20mins 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.IsEssential = true; // that means only server can ready it
    options.Cookie.HttpOnly = true;
});
//Authentication using google
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme= CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}).AddGoogle(options =>
{
    IConfigurationSection googleAuthNSection =
    builder.Configuration.GetSection("Authentication:Google");
    options.ClientId = googleAuthNSection["ClientId"];
    options.ClientSecret = googleAuthNSection["ClientSecret"];
    options.ClaimActions.MapJsonKey("urn:google:picture", "picture"); // This data comes from the user google profile
    options.ClaimActions.MapJsonKey("urn:google:email", "email");
}).AddCookie();


builder.Services.AddDbContext<ECommerceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("eCommerceConStr"));
});
builder.Services.AddTransient<ICommonRepository<Category>, CommonRepository<Category>>();
builder.Services.AddTransient<ICommonRepository<Product>, CommonRepository<Product>>();
builder.Services.AddTransient<ICommonRepository<CartDetail>, CommonRepository<CartDetail>>();
builder.Services.AddTransient<INewCartRepository, NewCartRepository>();
builder.Services.AddControllersWithViews();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
   // app.UseBrowserLink();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();    
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "ProductsManager",
        areaName: "Products",
        pattern: "Products/{controller=Home}/{action=Index}/{id?}"
    );
	endpoints.MapAreaControllerRoute(
		name: "CartsManager",
		areaName: "Carts",
		pattern: "Carts/{controller=Home}/{action=MyCart}/{id?}"
	);
    endpoints.MapAreaControllerRoute(
       name: "SecurityManager",
       areaName: "Security",
       pattern: "Security/{controller=Home}/{action=Login}"
   );
    endpoints.MapAreaControllerRoute(
        name: "CategoriesManager",
        areaName: "Categories",
        pattern: "Categories/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );


});


app.Run();

// https://localhost:44372/
