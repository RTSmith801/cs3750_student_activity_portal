using StudentActivityPortal.Data;

var builder = WebApplication.CreateBuilder(args);

// ======================
// SERVICES
// ======================

// Add MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

// Register ADO.NET Data Access Layer
builder.Services.AddScoped<ActivityDAL>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    return new ActivityDAL(config.GetConnectionString("DefaultConnection")!);
});

builder.Services.AddScoped<UserDAL>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    return new UserDAL(config.GetConnectionString("DefaultConnection")!);
});

// Enable Session
builder.Services.AddSession();


// ======================
// BUILD APP
// ======================

var app = builder.Build();


// ======================
// MIDDLEWARE PIPELINE
// ======================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();


// ======================
// ROUTING
// ======================

// Default route → Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// ======================
// RUN APP
// ======================

app.Run();