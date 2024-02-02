using financial_management_api.Api.Data;
using financial_management_api.Services;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configure and register EmailSettings from appsettings.json
        services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

        // Add DbContext for Entity Framework
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
        //services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        //    .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));

        // Add MVC services if you're using controllers and views
        // services.AddControllersWithViews();
    }

    [Obsolete]
    public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
