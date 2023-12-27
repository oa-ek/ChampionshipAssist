using Azure;
using ChampionshipAssist.Core.Context;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using ChampionshipAssist.Persistence.Repositories;
using ChampionshipAssist.WebApp.Controllers;
using ChampionshipAssist.WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using System.Text.Json.Serialization;
using static ChampionshipAssist.WebApp.Controllers.ReviewApiController;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ChampionshipAssistDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<User>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 4;
        }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ChampionshipAssistDbContext>();

        builder.Services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("ApplicationCorsPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });
        });

        builder.Services.AddRazorPages();

        AddRepositories(builder);

        builder.Services.AddControllersWithViews();

        // Move the following lines before builder.Build()

        // Configure the HTTP request pipeline.
        var app = builder.Build();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors("ApplicationCorsPolicy"); // Enable CORS

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Map API controllers

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            endpoints.MapRazorPages();
        });

        app.Run();
    }

    private static void AddRepositories(WebApplicationBuilder builder)
    {
        AddRepository<Tournament>(builder);
        AddRepository<Review>(builder);
        AddRepository<User>(builder);
    }

    private static void AddRepository<T>(WebApplicationBuilder builder)
        where T : class =>
        builder.Services.AddScoped<IRepository<T>>(provider =>
            new GenericRepository<T>(provider.GetService<ChampionshipAssistDbContext>()!));
}