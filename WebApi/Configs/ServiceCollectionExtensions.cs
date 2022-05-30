namespace WebApi.Configs;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddDataBase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        return services;
    }
}