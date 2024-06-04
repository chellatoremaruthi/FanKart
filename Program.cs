using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FanKart.Areas.Identity.Data;
using FanKart.Services;
using FanKart.Services.Interfaces;
using FanKart;
using FanKart.FanKartDbModels;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FanKartDbContextConnection") ?? throw new InvalidOperationException("Connection string 'FanKartDbContextConnection' not found.");
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
{
    connectionString = builder.Configuration.GetConnectionString("FankartDbContextConnectionProd") ?? throw new InvalidOperationException("Connection string 'BeautifyMeDbContextConnection' not found.");
}
builder.Services.AddDbContext<FanKartDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<FanKartDbContext>();

builder.Services.AddDbContext<FanKartContext>(options =>
{
    options.UseSqlServer(connectionString);
}, ServiceLifetime.Scoped);

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
{
    builder.Services.BuildServiceProvider().GetService<FanKartContext>().Database.Migrate();
    builder.Services.BuildServiceProvider().GetService<FanKartDbContext>().Database.Migrate();
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddScoped<IOTPGenerator, OTPGenerator>();
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IOrderService, OrderService>();
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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Landing}/{action=Index}/{id?}");


app.Run();
