using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.Mapping;
using BoardGameHub.Core.Services;
using BoardGameHub.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameHub.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShopServices, ShopServices>();
            services.AddScoped<IAdminServices, AdminServices>();

            services.AddMvc(options =>
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

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
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<BoardGameHubDbContext>();
            
            return services;
        }

        public static async Task SeedRolesAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var roleManager = scope.ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "User", "Shop" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task SeedUsersAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await CreateUser(userManager, "main@abv.bg", "Admin");
            await CreateUser(userManager, "user@abv.bg", "User");
            await CreateUser(userManager, "shop@abv.bg", "Shop");
        }

        private static async Task CreateUser(UserManager<IdentityUser> userManager, string email, string role)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new IdentityUser { UserName = email, Email = email };
                await userManager.CreateAsync(user, "123456");
            }

            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
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
