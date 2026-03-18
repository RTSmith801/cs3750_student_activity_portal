using StudentActivityPortal.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();

builder.Services.AddScoped<ActivityDAL>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    return new ActivityDAL(config.GetConnectionString("DefaultConnection")!);
});

// Enable Session
builder.Services.AddSession();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// ✅ Session middleware should come AFTER routing, BEFORE endpoints
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();