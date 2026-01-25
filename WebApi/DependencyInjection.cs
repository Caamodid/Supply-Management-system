using Application;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;
using WebApi.Permissions;

namespace WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // ============================
            // Database
            // ============================
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // ============================
            // Identity
            // ============================
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            // ============================
            // JWT Settings
            // ============================
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

            // ============================
            // Authentication + JWT
            // ============================
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };

                // ============================
                // JWT EVENTS (Unified JSON errors)
                // ============================
                options.Events = new JwtBearerEvents
                {
                    // Token expired
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception is SecurityTokenExpiredException)
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    },

                    // 401 - Not authenticated
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";

                        var response = await ResponseWrapper<object>.FailureAsync(
                            new List<string> { "Authentication required. Please login." },
                            "Unauthorized",
                            StatusCodes.Status401Unauthorized
                        );

                        var json = JsonSerializer.Serialize(response);
                        await context.Response.WriteAsync(json);
                    },

                    // 403 - Forbidden (no role / no permission)
                    OnForbidden = async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        context.Response.ContentType = "application/json";

                        var response = await ResponseWrapper<object>.FailureAsync(
                            new List<string> { "Access denied. You do not have permission to perform this action." },
                            "Forbidden",
                            StatusCodes.Status403Forbidden
                        );

                        var json = JsonSerializer.Serialize(response);
                        await context.Response.WriteAsync(json);
                    }
                };
            });

            // ============================
            // JWT Service
            // ============================
            services.AddScoped<IJwtService, JwtService>();

            // ============================
            // Application & Infrastructure
            // ============================
            services.AddInfrastructure(configuration);
            services.AddApplicationServices(configuration);

            // ============================
            // Permissions Authorization
            // ============================
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

            // ============================
            // CORS
            // ============================
            // ============================
            // CORS (FIXED)
            // ============================
            services.AddCors(options =>
            {
                options.AddPolicy("KahiyeApp", policy =>
                {
                    policy
                        .WithOrigins(
                            "http://localhost",
                            "http://localhost:3000",
                            "http://127.0.0.1",
                            "http://localhost:5173" // keep if you still use Vite sometimes
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });


            // ============================
            // Controllers & Swagger
            // ============================
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Description = "Enter: Bearer {token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }

        // ============================
        // Identity Seeder
        // ============================
        public static async Task UseIdentitySeederAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                var dbContext = services.GetRequiredService<AppDbContext>();

                logger.LogInformation("🔹 Starting Identity seeding...");
                await IdentitySeed.SeedRolesAndUsersAsync(userManager, roleManager, dbContext);
                logger.LogInformation("✅ Identity seeding completed successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "❌ Error during Identity seeding.");
            }
        }
    }
}
