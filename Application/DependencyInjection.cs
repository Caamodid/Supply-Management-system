using System.Reflection;
using Application.Common.Mapping;
using Application.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    /// <summary>
    /// Configures Application-layer services and behaviors.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // ----------------------------------------------------
            // 1️⃣ Register MediatR (CQRS)
            // ----------------------------------------------------
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // ----------------------------------------------------
            // 2️⃣ Register AutoMapper
            // ----------------------------------------------------
            //  Works for AutoMapper v12 and v13
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // If you’re using profiles in a specific namespace (like Application.Common.Mapping)
            // make sure they are all included:
            // services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // ----------------------------------------------------
            // 3️⃣ Register FluentValidation Validators
            // ----------------------------------------------------
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // ----------------------------------------------------
            // 4️⃣ Register MediatR Pipeline Behaviors
            // ----------------------------------------------------
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            // Optionally: Add logging, performance, or transaction behaviors
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

            // ----------------------------------------------------
            // 5️⃣ Return configured service collection
            // ----------------------------------------------------
            return services;
        }
    }
}
