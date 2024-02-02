using financial_management_api.Api.Data;
using financial_management_api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Adding Entity Framework DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Middleware and Routing Configuration
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Custom Error Handling Middleware
app.UseErrorHandlingMiddleware();

// Endpoint Configuration
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Running the Application
app.Run();
