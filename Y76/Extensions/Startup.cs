using Microsoft.EntityFrameworkCore;
using Y76.Data;
using Y76.Repository;

namespace Y76.Extensions
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();

            services.AddControllers();

            return services;
        }
    }
}
