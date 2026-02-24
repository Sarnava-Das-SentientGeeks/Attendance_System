using WebApplication1.Data;
//Imports namespace where ApplicationDbContext exists
//Without this AddDbContext<ApplicationDbContext> will not compile
//It allows database classes from the Data folder

var builder = WebApplication.CreateBuilder(args);
//It loads the appsettings.json, environment variables
//It prepares dependency injection container and prepares logging
//This is starting engine of the app


builder.Services.AddRazorPages();
//Everything inside builder.Services is registered into the DI container
//It enables Razor pages support without which razor pages .cshtml will not work
//It enables Razor view engine, page routing, model binding, page handlers(OnGet,OnPost)

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
//Adds database services to the DI container
//Registers ApplicationDbContext for dependency injection
//Configures it to use SQL Server and gets connection string from appsettings.json


var app = builder.Build();
//This compiles all service registrations and prepares the middleware pipeline
//It creates the app object

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //If environment is not development then it shows custom error page(/Error)
    
    app.UseHsts();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //Forces HTTPS for 30 days for improving security in production
}

app.UseHttpsRedirection();
//http:// is redirected to https://
//It is important for security, login systems, cookies


app.UseRouting();
//Without this url routing won't work i.e /Index won't map to your page

app.UseAuthorization();
//It activates authorization middleware
//Even if we are not using login still it prepares [Authorize] attribute, role-based access


app.MapStaticAssets();
//It helps to use the static files in wwwroot folder
//It uses the CSS,Bootstrap,jQuery,JS

app.MapRazorPages()
   .WithStaticAssets();
//It enables Razor pages routing
//Links static assets with Razor pages
//It allows to access .cshtml pages via localhost url

app.Run();
//This is the final line nothing runs after this
//It starts Kestrel web server and listens for HTTP requests


//Flow when we open https://localhost:xxxx/Index
//1)UseRouting() matches the URL
//2)MapRazorPages() finds the page
//3)PageModel is created
//4)ApplicationDbContext is injected
//5)Database operations happen
//6)Response is returned

