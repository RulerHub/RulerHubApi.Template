using Microsoft.EntityFrameworkCore;

using RulerHub.Api.Infrastructure.Data;

namespace RulerHub.Api.Extensions;

public static class DbContextExtension
{
    public static IServiceCollection AddDbContextExtension(this IServiceCollection services, IConfiguration configuration)
    {
        var ConnectionStrings = configuration.GetSection("ConnectionStrings");

        var connectionString = ConnectionStrings["DefaultConnection"]
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
}
