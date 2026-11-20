using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.Mapping;
using BoardGameHub.Core.Services;
using BoardGameHub.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BoardGameHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<BoardGameHubDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BoardGameHubDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IShopServices, ShopServices>();
            builder.Services.AddScoped<IAdminServices, AdminServices>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(ShopProfile).Assembly, typeof(Program).Assembly);
                cfg.AddMaps(typeof(AdminProfile).Assembly, typeof(Program).Assembly);
            });
            builder.Logging.AddFilter("LuckyPennySoftware.AutoMapper.License", LogLevel.None);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
