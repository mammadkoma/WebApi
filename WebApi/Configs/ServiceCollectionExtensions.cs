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

    internal static IServiceCollection AddIdentityAndOptions(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>();
        //services.Configure<IdentityOptions>(options =>
        //{
        //    // Password settings
        //    options.Password.RequiredLength = 6;
        //    options.Password.RequireDigit = false;
        //    options.Password.RequireLowercase = true;
        //    options.Password.RequireUppercase = false;
        //    options.Password.RequireNonAlphanumeric = false;

        //    // Lockout settings.
        //    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //    //options.Lockout.MaxFailedAccessAttempts = 5;
        //    //options.Lockout.AllowedForNewUsers = true;
        //});
        return services;
    }
}