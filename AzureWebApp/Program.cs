using AzureWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Endpoint=https://vf-appconfig-1.azconfig.io;Id=FWRi-l9-s0:o5JuVknRx5M/kXMEP4Re;Secret=EI8RBDKu9AmtCARnEYVmvdd2Chvv/qJC0bRqyyzDzyM=";

builder.Host.ConfigureAppConfiguration(opt => opt.AddAzureAppConfiguration(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();