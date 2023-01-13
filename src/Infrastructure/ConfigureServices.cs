using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieApi.Application.Common.Interfaces;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Infrastructure.Files;
using MovieApi.Infrastructure.Identity;
using MovieApi.Infrastructure.Persistence;
using MovieApi.Infrastructure.Persistence.Interceptors;
using MovieApi.Infrastructure.Persistence.Services;
using MovieApi.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("MovieApiDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}