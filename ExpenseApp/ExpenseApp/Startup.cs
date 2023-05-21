using ExpenseApp.Data;
using ExpenseApp.Repositories;
using ExpenseApp.Services;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Load connection string from appsettings.json
        var connectionString = _configuration.GetConnectionString("ExpenseDb");

        // Configure the ExpenseContext
        services.AddDbContext<ExpenseContext>(options =>
            options.UseSqlServer(connectionString));

        // Register repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();

        // Register services
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IExpenseService, ExpenseService>();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
