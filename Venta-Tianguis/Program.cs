using Venta_Tianguis.BusinessSvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Venta_Tianguis.Data;
using Venta_Tianguis.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Venta_TianguisContextConnection") ?? throw new InvalidOperationException("Connection string 'Venta_TianguisContextConnection' not found.");

builder.Services.AddDbContext<Venta_TianguisContext>(options =>
  {  options.UseSqlServer(connectionString);
      options.UseLazyLoadingProxies();
});

builder.Services.AddDefaultIdentity<Venta_TianguisUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Venta_TianguisContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGarageSaleService, GarageSaleServiceDb>();
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
app.UseAuthentication();;

app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapRazorPages());
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
