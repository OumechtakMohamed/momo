using ExpenseApp.Data;
using ExpenseApp.Repositories;
using ExpenseApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configure the ExpenseContext
            services.AddDbContext<ExpenseContext>(options =>
                options.UseSqlServer("Data Source=localhost;Initial Catalog=ExpenseDb;Integrated Security=True;TrustServerCertificate=True"));

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
}
