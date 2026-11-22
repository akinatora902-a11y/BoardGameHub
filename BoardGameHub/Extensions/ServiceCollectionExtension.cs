using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.Mapping;
using BoardGameHub.Core.Services;
using BoardGameHub.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BoardGameHub.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShopServices, ShopServices>();
            services.AddScoped<IAdminServices, AdminServices>();

            return services;
        }
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<BoardGameHubDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
        public static IServiceCollection AddApplicationMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(ShopProfile).Assembly);   
                cfg.AddMaps(typeof(Program).Assembly);       
            });

            services.AddLogging(logging =>
                logging.AddFilter("LuckyPennySoftware.AutoMapper.License", LogLevel.None));

            return services;
        }
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<IdentityUser>(options => ConfigureIdentityOptions(options, configuration))
               .AddEntityFrameworkStores<BoardGameHubDbContext>();
            
            return services;
        }

        private static void ConfigureIdentityOptions(IdentityOptions options, IConfiguration configuration)
        {
            options.Password.RequireLowercase =
                configuration.GetValue<bool>("Identity:Password:RequireLowercase");
            options.Password.RequireDigit =
                configuration.GetValue<bool>("Identity:Password:RequireDigit");
            options.Password.RequireUppercase =
                configuration.GetValue<bool>("Identity:Password:RequireUppercase");
            options.Password.RequiredUniqueChars =
                configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");
            options.Password.RequiredLength =
                configuration.GetValue<int>("Identity:Password:RequiredLength");
            options.Password.RequireNonAlphanumeric =
                configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

            options.SignIn.RequireConfirmedAccount =
                configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
            options.User.RequireUniqueEmail =
                configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
        }
    }
}
