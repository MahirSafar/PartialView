using Microsoft.EntityFrameworkCore;
using Pustok.App.DAL.Context;
using Pustok.App.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
    //.AddNewtonsoftJson(options =>
    //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    //);
builder.Services.AddAutoMapper(opt => { }, typeof(MapperProfile).Assembly);
builder.Services.AddDbContext<PustokDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
});
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
